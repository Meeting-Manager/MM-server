using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MeetingDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string MeetingName { get; set; }
        public string Protocol { get; set; }
        public ICollection<string> MeetingUsers { get; set; }
    }
}
