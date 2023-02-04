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
        IDataResult <List<CarDetailDto>> GetCarDetails();
        IDataResult <List<Car>> GetAll();
        IDataResult <List<Car>> GetByColorId();
        IDataResult <List<Car>> GetByBrandId();

        IResult Update(Car entity);
        IResult Delete(Car entity);
        IResult Add ( Car entity );
    }
}
