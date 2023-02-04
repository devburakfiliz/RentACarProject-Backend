using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<CarDetailDto> GetCarDetails();
        public List<Car> GetAll();
        public List<Car> GetByColorId();
        public List<Car> GetByBrandId();
       
        void Update(Car entity);
        void Delete(Car entity);
        IResult Add ( Car entity );
    }
}
