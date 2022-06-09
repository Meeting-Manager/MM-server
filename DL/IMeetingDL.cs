using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IMeetingDL
    {
        public Task<List<Meeting>> GetAllMeetings();


        public Task PostMeeting(Meeting meeting);


        public Task PutMeeting(int id, Meeting meeting);

        public Task DeleteMeeting(int id);

    }
}
