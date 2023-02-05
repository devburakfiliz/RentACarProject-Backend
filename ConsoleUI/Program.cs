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
            UserManager userManager = new UserManager(new EfUserDal());
            CarManager carManager = new CarManager(new EfCarDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            //GetDetails(carManager);
            //AddCar(carManager);
            //UpdateCar(carManager);
            //DeleteCar(carManager);
            // AddUser(userManager);

            var result = rentalManager.Add(new Rental()
            {


                CarId=1007,
                CustomerId=2,
                RentDate=DateTime.Now
                
                
              


            });
            Console.WriteLine(result.Message);


        }

        private static void AddUser(UserManager userManager)
        {
            var result = userManager.Add(new User()
            {


                Name = "Burak",
                LastName = "Filiz",
                Email = "dev.burakfiliz@gmail.com",
                Password = "h2145bew"


            });
            Console.WriteLine(result.Message);
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
