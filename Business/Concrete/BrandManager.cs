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
    public class BrandManager : IBrandService
    {
        
        

            IBrandDal _brandDal;
            public BrandManager(IBrandDal userDal)
            {
                _brandDal = userDal;
            }





            public IResult Add(Brand entity)
            {
                _brandDal.Add(entity);
                return new SuccessResult(Messages.BrandAdded);
            }

            public IResult Delete(Brand entity)
            {
                _brandDal.Delete(entity);
                return new SuccessResult(Messages.BrandDeleted);
            }

            public IDataResult<List<Brand>> GetAll()
            {
                if (DateTime.Now.Hour == 20)
                {

                    return new ErrorDataResult<List<Brand>>(Messages.BrandsListed);
                }
                else
                {

                    return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandsListed);
                }
            }

            public IResult Update(Brand entity)
            {
                _brandDal.Update(entity);
                return new SuccessResult(Messages.BrandUpdated);
            }
        }
    }
