using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
    public class Cars
    {
        public int carId { get; set; }
        public string modelName { get; set; }
        public string brandName { get; set; }
        public DateTime published { get; set; }
        public int total { get; set; }
        public string makeName { get; set; }
        public string scale { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public Cars()
        {
            this.Users = new HashSet<User>(); // this hashset is to ommit the duplicate data 
        }

    }
}
