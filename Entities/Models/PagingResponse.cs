using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class PagingResponse<T> where T : class
    {
        public List<T> Developers { get; set; }
    }
}
