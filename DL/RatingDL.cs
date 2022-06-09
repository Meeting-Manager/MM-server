using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class RatingDL:IRatingDL
    {
        MeetingManagementContext meetingManagementContext;

        public RatingDL(MeetingManagementContext meetingManagementContext)
        {
            this.meetingManagementContext = meetingManagementContext;
        }
        public async Task RatingPost(Rating value)
        {
            await meetingManagementContext.Ratings.AddAsync(value);
            await meetingManagementContext.SaveChangesAsync();
        }
    }
}
