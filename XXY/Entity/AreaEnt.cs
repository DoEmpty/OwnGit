using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class AreaEnt
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ParentID { get; set; }
        public int Level { get; set; }
    }
}
