using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        
        List<OperationClaim> GetClaims(User entity);
        IResult Add(User entity);
        IResult Update(User entity);
        IResult UpdatePassword(User entity, string password);
        IResult Delete(User entity);
        IDataResult<User> GetByMail(string email);
        IDataResult<User> GetById(int id);

    }
}
