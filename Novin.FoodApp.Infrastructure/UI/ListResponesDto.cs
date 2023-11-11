using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novin.FoodApp.Infrastructure.UI
{
    public class ListResponesDto
    {
        public int TotalCount { get; set; }
        public List<T>? Data { get; set; }
    }

}
