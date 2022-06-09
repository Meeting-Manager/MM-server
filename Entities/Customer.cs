using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
        [NotMapped]
        public string Token { get; set; }
    }
}
