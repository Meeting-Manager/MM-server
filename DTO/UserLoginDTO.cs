using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class UserLoginDTO
    {
        public UserLoginDTO()
        {

        }
        public string Name { get; set; }
        public string Password { get; set; }
        public string CustomerName { get; set; }
    }
}
