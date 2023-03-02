using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IDataResult<List<Payment>> GetAll();
        IResult Pay(Payment entity);
        IResult Add(Payment entity);
        IResult Delete(Payment entity);
        IResult Update(Payment entity);
    }
}
