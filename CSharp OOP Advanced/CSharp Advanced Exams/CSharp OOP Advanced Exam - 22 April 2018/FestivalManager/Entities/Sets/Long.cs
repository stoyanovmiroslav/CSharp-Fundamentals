using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalManager.Entities.Sets
{
    public class Long : Set
    {
        public Long(string name) 
            : base(name, new TimeSpan(0, 60, 0))
        {
        }
    }
}
