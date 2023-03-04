using Business.Abstract;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }




        [ValidationAspect(typeof(RentalValidator))]

        public IResult Add(Rental entity)
        {

            var carToRent = _rentalDal.Get(r => r.CarId == entity.CarId && r.ReturnDate == null);
            if (carToRent == null)
            {
                _rentalDal.Add(entity);
                return new SuccessResult(Messages.RentalAdded);
            }
            return new ErrorResult(Messages.RentalFailed);
        }

        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {

            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);

        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.CarsListed);

        }

        public IResult RulesForAdding(Rental entity)
        {
            var result = BusinessRules.Run(
                CheckIfThisCarIsAlreadyRentedInSelectedDateRange(entity),
                CheckIfReturnDateIsBeforeRentDate(entity.ReturnDate, entity.RentDate)
                );
            if (result != null)
            {
                return result;
            }


            return new SuccessResult("Ödeme Sayfasına Yönlendiriliyorsunuz.");
            
        }

        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult(Messages.RentalUpdated);
        }

        private IResult CheckIfThisCarIsAlreadyRentedInSelectedDateRange(Rental entity)
        {
            var result = _rentalDal.Get(r =>
            r.CarId == entity.CarId
            && (r.RentDate.Date == entity.RentDate.Date
            || (r.RentDate.Date < entity.RentDate.Date
            && (r.ReturnDate == null
            || ((DateTime)r.ReturnDate).Date > entity.RentDate.Date))));

            if (result != null)
            {
                return new ErrorResult(Messages.ThisCarIsAlreadyRentedInSelectedDateRange);
            }
            return new SuccessResult();
        }

        private IResult CheckIfThisCarHasBeenReturned(Rental entity)
        {
            var result = _rentalDal.Get(r => r.CarId == entity.CarId && r.ReturnDate == null);

            if (result != null)
            {
                if (entity.ReturnDate == null || entity.ReturnDate > result.RentDate)
                {
                    return new ErrorResult(Messages.ThisCarIsAlreadyRentedInSelectedDateRange);
                }
            }
            return new SuccessResult();




        }
        private IResult CheckIfReturnDateIsBeforeRentDate(DateTime? returnDate, DateTime rentDate)
        {
            if (returnDate != null)
                if (returnDate < rentDate)
                {
                    return new ErrorResult(Messages.ThisCarIsAlreadyRentedInSelectedDateRange);
                }
            return new SuccessResult();
        }
    }
}
