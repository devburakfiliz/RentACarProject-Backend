using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {

        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }





        public IResult Add(User entity)
        {
            _userDal.Add(entity);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(User entity)
        {
            _userDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour == 20)
            {

                return new ErrorDataResult<List<User>>(Messages.MaintenanceTime);
            }
            else
            {

                return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.CarsListed);
            }
        }

        public IResult Update(User entity)
        {
            _userDal.Update(entity);
            return new SuccessResult(Messages.Updated);
        }
    }
}
