using Core.Aspects.Autofac.Caching;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarContex>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarContex context = new CarContex())

            {
                var result = from r in context.Rentals
                             join cu in context.Customers on r.CustomerId equals cu.Id
                             join u in context.Users on cu.UserId equals u.Id
                             join c in context.Cars on r.CarId equals c.CarId
                             join b in context.Brands on c.BrandId equals b.Id
                         
                             select new RentalDetailDto
                             {
                                 CarId = r.CarId,
                                 BrandName = b.brandName,
                                 CustomerName = u.FirstName + " " + u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 ImagePath = (from img in context.CarImages
                                              where img.CarId == c.CarId
                                              select img.ImagePath).FirstOrDefault(),
                                 DailyPrice = c.DailyPrice,
                                 ModelName=c.ModelName


                             };
                return result.ToList();
            }
        }
    }
}

