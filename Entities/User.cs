using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class User
    {

        public User()
        {
            MeetingUsers = new HashSet<MeetingUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string IdentityNumber { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public int? CustomerId { get; set; }
        public string Salt { get; set; }

        public virtual Customer Customer { get; set; }
         [JsonIgnore]
        public virtual ICollection<MeetingUser> MeetingUsers { get; set; }
        [NotMapped]
        public string Token{ get; set; }
       
    }
}
