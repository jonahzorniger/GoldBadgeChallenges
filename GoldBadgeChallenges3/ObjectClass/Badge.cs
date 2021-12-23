using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectClass
{
    public class Badge
    {
        public Badge() { }

        public Badge (int id, List<string> doorList)
        {
            BadgeID = id;
            DoorList = doorList;
        }

    
        //unique identifier

        public int BadgeID { get; set; }
        public List<string> DoorList { get; set; }
        
    }
}
