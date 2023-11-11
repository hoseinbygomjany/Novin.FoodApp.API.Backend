using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novin.FoodApp.Infrastructure.UI
{
    public class ListRequestDto
    {
        public int Page { get; set; } = 0;
        public int PageSize { get; set; } = 10;
        public string OrderField { get; set; }="Id";
        public string OrderType { get; set; } = "DESC";
        public string Filter { get; set; } = "";
    }
}
