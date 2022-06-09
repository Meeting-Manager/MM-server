using AutoMapper;
using DL;
using Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace BL
{
    public class UserBL : IUserBL
    {
        IUserDL userDL;
        IConfiguration configuration;
        IPasswordHashHelper passwordHashHelper;


        public UserBL(IUserDL userDL, IConfiguration configuration, IPasswordHashHelper passwordHashHelper)
        {
            this.userDL = userDL;
            this.configuration = configuration;
            this.passwordHashHelper = passwordHashHelper;
        }
        public async Task<User> Login(string name, string password, string customerName)
        {

            User user = await userDL.Login(name, customerName);
            string hashedpassword = passwordHashHelper.HashPassword(password, user.Salt, 1000, 8);
            if (user == null) return null;
            if (hashedpassword.Equals(user.Password.TrimEnd()))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(configuration.GetSection("key").Value);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);
                return WithoutPassword(user);
            }
            else
                return null;
        }
        public static List<User> WithoutPasswords(List<User> users)
        {
            return users.Select(x => WithoutPassword(x)).ToList();
        }


        public static User WithoutPassword(User user)
        {
            user.Password = null;
            return user;
        }

        public async Task<List<User>> GetByCustomerId(int customerId)
        {

            return await userDL.GetByCustomerId(customerId);
        }

        public async Task UserPost(User user)
        {
            user.Salt = passwordHashHelper.GenerateSalt(8);
            user.Password = passwordHashHelper.HashPassword(user.Password, user.Salt, 1000, 8);
            await userDL.UserPost(user);
        }
        public async Task UserPut(int id, User user)
        {
            user.Salt = passwordHashHelper.GenerateSalt(8);
            user.Password = passwordHashHelper.HashPassword(user.Password, user.Salt, 1000, 8);
            await userDL.UserPut(id, user);
        }

        public async Task userDelete(int id)
        {
            await userDL.userDelete(id);
        }
    }
}
