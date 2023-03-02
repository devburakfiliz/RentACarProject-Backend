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
                                 
                                 CarId = car.Id,
                                 BrandId=brand.Id,
                                 ColorId=color.Id,
                                 BrandName = brand.brandName,
                                 ColorName = color.colorName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear =  car.ModelYear,
                                 Description = car.Description,
                                 ModelName = car.ModelName,
                                 ImagePath = (from img in context.CarImages
                                               where img.CarId == car.Id
                                               select img.ImagePath).FirstOrDefault()

                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByBrand(int brandId)
        {
            using (CarContex context = new CarContex())
            {
                var result = from car in context.Cars
                             join brand in context.Brands on car.BrandId equals brand.Id
                             join color in context.Colors on car.ColorId equals color.Id
                             where car.BrandId == brandId
                             select new CarDetailDto
                             {
                                 CarName = brand.brandName,
                                 CarId = car.Id,
                                 BrandId = brand.Id,
                                 ColorId = color.Id,
                                 BrandName = brand.brandName,
                                 ColorName = color.colorName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 Description = car.Description,
                                 ModelName = car.ModelName,
                                 ImagePath = (from img in context.CarImages
                                              where img.CarId == car.Id
                                              select img.ImagePath).FirstOrDefault()

                             };
                return result.ToList();
            }
        }
    }
}
