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


            //carManager.Add(new Car() {

            //BrandId=1,
            //ColorId=2,
            //DailyPrice=500,
            //ModelYear="2023",
            //Description="B"

            //});

            carManager.Update(new Car() {
                Id=1,
                Description="Volvo",
                BrandId=5,
                DailyPrice=500,
                ColorId=2,
                ModelYear="2021"
            });
            carManager.Delete(new Car()
            {
                Id = 1

            });


            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

        }
    }
}
