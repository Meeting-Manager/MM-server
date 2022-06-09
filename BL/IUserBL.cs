using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IUserBL
    {
        public Task<User> Login(string name, string password, string customerName);
        public Task<List<User>> GetByCustomerId(int customerId);
        public Task UserPost(User user);
        public Task UserPut(int id, User user);
        public Task userDelete(int id);



    }
}
