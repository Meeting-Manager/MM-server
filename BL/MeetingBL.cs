using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class MeetingBL : IMeetingBL
    {
        IMeetingDL meetingDL;

        public MeetingBL(IMeetingDL meetingDL)
        {
            this.meetingDL = meetingDL;
        }
        public async Task<List<Meeting>> GetAllMeetings()
        {
            return await meetingDL.GetAllMeetings();
        }

        public async Task PostMeeting(Meeting meeting)
        {
            await meetingDL.PostMeeting(meeting);
        }

        public async Task PutMeeting(int id, Meeting meeting)
        {
            await meetingDL.PutMeeting(id, meeting);
        }

        public async Task DeleteMeeting(int id)
        {
            await meetingDL.DeleteMeeting(id);
        }
    }
}
