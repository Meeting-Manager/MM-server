using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class Meeting
    {
        public Meeting()
        {
            MeetingUsers = new HashSet<MeetingUser>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string MeetingName { get; set; }
        public string Protocol { get; set; }

        public virtual ICollection<MeetingUser> MeetingUsers { get; set; }
    }
}
