using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DWC.Blazor.Models
{
    public class PagingResponse<T> where T : class
    {
        public List<T> Developers { get; set; }
    }
}
