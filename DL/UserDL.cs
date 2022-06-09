using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class UserDL: IUserDL
    {
        MeetingManagementContext meetingManagementContext;
        public UserDL(MeetingManagementContext meetingManagementContext)
        {
            this.meetingManagementContext = meetingManagementContext;
        }

        public async Task<User> Login(string name, string customerName)
        {
            return await meetingManagementContext.Users.Where(user => user.Name == name && user.Customer.Name == customerName).Include(s => s.Customer).Include(s => s.MeetingUsers).FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetByCustomerId(int customerId)
        {
            return await meetingManagementContext.Users.Where(user => user.CustomerId == customerId)/*?.Include(s => s.Customer)*/.ToListAsync();
        }

        

        public async Task UserPost(User user)
        {
            await meetingManagementContext.Users.AddAsync(user);
            await meetingManagementContext.SaveChangesAsync();
        }

        public async Task UserPut(int id, User user)
        {
            User u = await meetingManagementContext.Users.FindAsync(id);
            meetingManagementContext.Users.Remove(u);
            await meetingManagementContext.SaveChangesAsync();
        }
        public async Task userDelete(int id)
        {
            User user = await meetingManagementContext.Users.FindAsync(id);
            meetingManagementContext.Users.Remove(user);
            await meetingManagementContext.SaveChangesAsync();
        }

    }
}
