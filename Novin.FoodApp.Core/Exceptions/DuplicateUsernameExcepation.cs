using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novin.FoodApp.Core.Exceptions
{
    public class DuplicateUsernameExcepation:Exception
    {
        public DuplicateUsernameExcepation()
            :base("شماره همراه تکرای است")
        {
            
        }

    }
}
