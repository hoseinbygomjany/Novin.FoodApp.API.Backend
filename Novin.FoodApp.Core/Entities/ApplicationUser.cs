using Novin.FoodApp.Core.Enumes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Novin.FoodApp.Core.Entities
{
    public class ApplicationUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        [JsonIgnore]
        public ApplicationUserType Type { get; set; }
        public bool Verified { get; set; } = false;
        [JsonIgnore]
        public string VerificationCode { get; set; }

        public string UserType
        {
            get
            {
                switch (this.Type)
                {
                    case ApplicationUserType.systemAdmin:
                        return "مدریت سیستم";
                        break;
                    case ApplicationUserType.RestaurantOwner:
                        return "رستوران داران";
                        break;
                    case ApplicationUserType.Customer:
                        return "مشتری ها";
                        break;
                    default:
                        break;
                }
                return "ناشناس";
            }
        }
        
    }
}
