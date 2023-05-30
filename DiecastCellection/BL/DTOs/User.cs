using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
    public class User
    {
        public int uid { get; set; }
        public string uname { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public int totalCar { get; set; }

        public virtual ICollection<Cars> Cars { get; set; }

        public User()
        {
            this.Cars = new HashSet<Cars>(); // Hashset for omiting the duplicate 
        }

    }
}