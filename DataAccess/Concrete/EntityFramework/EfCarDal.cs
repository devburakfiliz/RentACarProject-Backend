using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        
        public void Add(Car entity)
        {
            using (CarContex context = new CarContex())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
            
        }

        public void Delete(Car entity)
        {
            using (CarContex context = new CarContex())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarContex contex = new CarContex())
            {
                return filter == null
                    ? contex.Set<Car>().ToList()
                    : contex.Set<Car>().Where(filter).ToList();

            }
        }

        public List<Car> GetByBrandId(Expression<Func<Car, bool>> filter = null)
        {
            using (CarContex context = new CarContex())
            {
                return context.Set<Car>().Where(filter).ToList();

            }




        }

        public List<Car> GetByColorId(Expression<Func<Car, bool>> filter = null)
        {
            using (CarContex context = new CarContex())
            {
                return context.Set<Car>().Where(filter).ToList();

            }
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {

            using (CarContex context =new CarContex()) 
            {
                return context.Set<Car>().FirstOrDefault(filter);
            }
            

        }

        public void Update(Car entity)
        {
            using (CarContex context = new CarContex())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
