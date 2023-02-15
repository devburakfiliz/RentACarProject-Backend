using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims); // kullanıcı sıfre ve ıd gırdıgınde  apiye yolladı ilgılı kullanıcı ıcın verı tabanında kullanıcı clıamlarını bulup json web token uretıp onu yollayacak

    }
}
