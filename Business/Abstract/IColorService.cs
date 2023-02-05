using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {

        IDataResult<List<Color>> GetAll();
        IResult Update(Color entity);
        IResult Delete(Color entity);
        IResult Add(Color entity);
    }
}
