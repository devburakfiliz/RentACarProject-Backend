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
        [ValidationAspect(typeof(CarValidator))]
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
        public IDataResult <List<Car>> GetByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId== id));
        }

        [CacheAspect]
        public IDataResult< List<Car>> GetByColorId(int colorid)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId ==  colorid));

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
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == id));
        }
         
    }
}
