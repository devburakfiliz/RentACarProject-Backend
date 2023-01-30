using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public void Add(Car entity)
        {
            if (entity.Description.Length>=2 && entity.DailyPrice>0)
            {
                _carDal.Add(entity);
            }
            else
            {
                throw new Exception("ARABA ÖZELLİKLERİ YANLIŞ");
            }
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

        public void Update(Car entity)
        {
             _carDal.Update(entity);
        }
    }
}
