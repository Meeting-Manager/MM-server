using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        public UserDTO()
        {
           
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string IdentityNumber { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public int? CustomerId { get; set; }
        public bool IsActive { get; set; }
        public string Recording { get; set; }
        public string Salt { get; set; }
        public string Token { get; set; }
        public string CustomerName { get; set; }
        public string MeetingUserId { get; set; }
        

    }
}
