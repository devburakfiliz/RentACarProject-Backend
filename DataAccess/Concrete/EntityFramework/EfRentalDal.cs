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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarContex>, IRentalDal
    {

        public List<RentalDto> Getrentals()
        {
            using (CarContex context = new CarContex())
            {
                var result = from rental in context.Rentals
                             join brand in context.Brands on rental.CarId equals brand.Id
                             join user in context.Users on rental.CustomerId equals user.Id

                             select new RentalDto
                             {
                                 BrandName = brand.brandName,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                                


                               

                             };
                return result.ToList();


            }
        }
    }
}

