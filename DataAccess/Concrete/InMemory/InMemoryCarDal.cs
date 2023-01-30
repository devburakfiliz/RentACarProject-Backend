using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    
    public class InMemoryCarDal 
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            
            _cars = new List<Car> {
                new Car{Id=1,BrandId=1,ColorId=1,ModelYear="2020",DailyPrice=300,Description="Renault Clio Beyaz renk"},
                new Car{Id=2,BrandId=2,ColorId=1,ModelYear="2019",DailyPrice=250,Description="Fiat Egea Beyaz renk"},
                new Car{Id=3,BrandId=3,ColorId=2,ModelYear="2022",DailyPrice=400,Description="Ford Ranger Kırmızı renk"},
                new Car{Id=4,BrandId=4,ColorId=2,ModelYear="2022",DailyPrice=500,Description="Ford Mustang Kırmızı renk"},
                new Car{Id=5,BrandId=1,ColorId=3,ModelYear="2020",DailyPrice=300,Description="Renault Clio Siyah renk",}
                
            };

            
        }
        
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car DeleteCar = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(DeleteCar);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }

     

        public void Update(Car car)
        {
            Car carUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carUpdate.Id = car.Id;
            carUpdate.BrandId = car.BrandId;
            carUpdate.ColorId = car.ColorId;
            carUpdate.DailyPrice = car.DailyPrice;
            carUpdate.Description = car.Description;
            carUpdate.ModelYear = car.ModelYear;
        }

        
    }
}
