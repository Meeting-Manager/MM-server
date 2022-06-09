using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
   public class MeetingDL:IMeetingDL
    {
        MeetingManagementContext meetingManagementContext;
        public MeetingDL(MeetingManagementContext meetingManagementContext)
        {
            this.meetingManagementContext = meetingManagementContext;
        }


        public async Task<List<Meeting>> GetAllMeetings()
        {
            return await meetingManagementContext.Meetings.Include(m=>m.MeetingUsers).ThenInclude(x => x.User).ToListAsync();
        }

        public async Task PostMeeting(Meeting meeting)
        {
            await meetingManagementContext.Meetings.AddAsync(meeting);
            await meetingManagementContext.SaveChangesAsync();
        }

        public async Task PutMeeting(int id, Meeting meeting)
        {
            Meeting m = await meetingManagementContext.Meetings.FindAsync(id);
            meetingManagementContext.Entry(m).CurrentValues.SetValues(meeting);
            await meetingManagementContext.SaveChangesAsync();
        }
        public async Task DeleteMeeting(int id)
        {
            Meeting meetingtoDelete = await meetingManagementContext.Meetings.FindAsync(id);
            meetingManagementContext.Meetings.Remove(meetingtoDelete);
            await meetingManagementContext.SaveChangesAsync();
        }
    }
}
