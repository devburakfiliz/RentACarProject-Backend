using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
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

        public IResult Add(Car entity)
        {
            if (entity.Description.Length<3)
            {
                return new ErrorResult(Messages.CarNameInValid);
            }
            _carDal.Add(entity);
            return new SuccessResult(Messages.CarAdded);
        }

        public void Delete(Car entity)
        {
            _carDal.Delete(entity);
        }

        public List<Car> GetAll()
        { 
            return _carDal.GetAll();
        }

        public List<Car> GetByBrandId()
        {
            return _carDal.GetByBrandId();
        }

        public List<Car> GetByColorId()
        {
            return _carDal.GetByColorId();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public void Update(Car entity)
        {
             _carDal.Update(entity);
        }
    }
}
