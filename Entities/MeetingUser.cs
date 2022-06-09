using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class MeetingUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MeetingId { get; set; }
        [JsonIgnore]
        public virtual Meeting Meeting { get; set; }
        
        public virtual User User { get; set; }
    }
}
