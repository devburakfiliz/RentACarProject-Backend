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

            //GetDetails(carManager);
            //AddCar(carManager);
            UpdateCar(carManager);
            //DeleteCar(carManager);


        }

        private static void GetDetails(CarManager carManager)
        {
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(result.Message);
                    Console.WriteLine(car.CarName + " / " + car.BrandName);
                }
            }

            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void AddCar(CarManager carManager)
        {
            var result = carManager.Add(new Car()
            {


                BrandId = 2,
                ColorId = 5,
                DailyPrice = 300,
                ModelYear = "2023",
                Description = "Clio beyaz"


            });
            Console.WriteLine(result.Message);
        }

        private static void UpdateCar(CarManager carManager)
        {
            var result =carManager.Update(new Car()
            {
                Id = 4,
                Description = "Volvo",
                BrandId = 5,
                DailyPrice = 500,
                ColorId = 2,
                ModelYear = "2021"
            });
            Console.WriteLine(result.Message);
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
