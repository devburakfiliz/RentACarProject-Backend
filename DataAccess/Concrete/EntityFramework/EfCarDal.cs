using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContex>, ICarDal
    {
     
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarContex context = new CarContex())
            {
                var result = from car in context.Cars
                             join brand in context.Brands on car.BrandId equals brand.Id
                             join color in context.Colors on car.ColorId equals color.Id
                             select new CarDetailDto
                             {
                                 CarName = brand.brandName,
                                 BrandName = brand.brandName,
                                 ColorName = color.colorName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear =  car.ModelYear,
                                 Description = car.Description
                                 
                             };
                return result.ToList();


            }
        }
    }
}
