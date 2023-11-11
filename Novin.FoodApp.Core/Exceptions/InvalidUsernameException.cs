using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novin.FoodApp.Core.Exceptions
{
    public class InvalidUsernameException:Exception
    {
        public InvalidUsernameException() 
            :base("شماره تماس شما صحیح وارد نشده است")
        { 

        }
    }
}
