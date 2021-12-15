using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToReadApi.Models
{
    public class ToReadItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsRead { get; set; }
        public string Opinion { get; set; }
        public string Comment { get; set; }
    }

}
