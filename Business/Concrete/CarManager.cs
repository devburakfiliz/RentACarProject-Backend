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

        public IResult Delete(Car entity)
        {
            _carDal.Delete(entity);
            return new SuccessResult( Messages.Deleted);
        }

        public IDataResult <List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==20)
            {
             
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            else
            {
               
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
            }
        }

        public IDataResult <List<Car>> GetByBrandId()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetByBrandId(), Messages.CarsListed);
        }

        public IDataResult< List<Car>> GetByColorId()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetByColorId(), Messages.CarsListed);

        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour==9)
            {
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarsListed);

            }

            return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);

            
        }

        public IResult Update(Car entity)
        {
             _carDal.Update(entity);
            return new SuccessResult(Messages.Updated);
        }
    }
}
