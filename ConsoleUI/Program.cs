using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName+" / "+car.ColorName+" / "+ car.BrandName+" / "+car.DailyPrice);
            }

            //carManager.Add(new Car() {

            //BrandId=1,
            //ColorId=2,
            //DailyPrice=500,
            //ModelYear="2023",
            //Description="B"

            //});

            //UpdateCar(carManager);
            //DeleteCar(carManager);

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

        }

        private static void UpdateCar(CarManager carManager)
        {
            carManager.Update(new Car()
            {
                Id = 1,
                Description = "Volvo",
                BrandId = 5,
                DailyPrice = 500,
                ColorId = 2,
                ModelYear = "2021"
            });
        }

        private static void DeleteCar(CarManager carManager)
        {
            carManager.Delete(new Car()
            {
                Id = 5

            });
        }
    }
}
