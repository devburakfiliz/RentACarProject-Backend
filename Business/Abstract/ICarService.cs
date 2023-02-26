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
 
        IDataResult <List<CarDetailDto>> GetByBrandId(int id);
        IDataResult <List<CarDetailDto>> GetByColorId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailsById(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColorAndBrand(int brandId,int colorId);

        IDataResult <Car> GetById(int id);

        IResult Update(Car entity);
        IResult Delete(Car entity);
        IResult Add ( Car entity );
    }
}
