using Business.Abstract;
using Business.BussinessAspect;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {

        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
           _carDal = carDal;
        }


        [SecuredOperation("car.add,admin")]
        //[ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car entity)
        {
           

            _carDal.Add(entity);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car entity)
        {
            _carDal.Delete(entity);
            return new SuccessResult( Messages.CarDeleted);
        }

        [CacheAspect]
        public IDataResult <List<Car>> GetAll()
        {
      
               return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
           
        }

        [CacheAspect]
        public IDataResult <List<CarDetailDto>> GetByBrandId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByBrand(id));
        }

        [CacheAspect]
        public IDataResult< List<CarDetailDto>> GetByColorId(int colorid)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails().Where(c=>c.ColorId==colorid).ToList());

        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
          
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarsListed);

        }

        public IResult Update(Car entity)
        {
             _carDal.Update(entity);
            return new SuccessResult(Messages.CarUpdated);
        }
        public IDataResult <Car>  GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.GetById(p => p.CarId == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsById(int carid)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails().Where(c => c.CarId == carid).ToList());
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorAndBrand(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(
               _carDal.GetCarDetails()
               .Where(c => c.BrandId == brandId && c.ColorId == colorId).ToList());
        }
    }
}
