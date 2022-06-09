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
    public class CustomerBL : ICustomerBL
    {
        ICustomerDL customerDL;
        IConfiguration configuration;
        IPasswordHashHelper passwordHashHelper;
        public CustomerBL(ICustomerDL customerDL, IConfiguration configuration, IPasswordHashHelper passwordHashHelper)
        {
            this.customerDL = customerDL;
            this.configuration = configuration;
            this.passwordHashHelper = passwordHashHelper;
        }
        public async Task<List<Customer>> GetAllCustomers()
        {
            return await customerDL.GetAllCustomers();
        }

        public async Task PostCustomer(Customer customer)
        {
            customer.Salt = passwordHashHelper.GenerateSalt(8);
            customer.Password = passwordHashHelper.HashPassword(customer.Password, customer.Salt, 1000, 8);
            await customerDL.PostCustomer(customer);
        }
        public async Task PutCustomer(int id, Customer customer)
        {
            customer.Salt = passwordHashHelper.GenerateSalt(8);
            customer.Password = passwordHashHelper.HashPassword(customer.Password, customer.Salt, 1000, 8);
            await customerDL.PutCustomer(id, customer);
        }
    
        public async Task<Customer> GetCustomerByID(int id)
        {
            return await customerDL.GetCustomerByID(id);
        }
        
        public async Task<Customer> Login(string name, string password)
        {

            Customer customer = await customerDL.Login(name);
            string hashedpassword = passwordHashHelper.HashPassword(password, customer.Salt, 1000, 8);
            if (customer == null) return null;
            if (hashedpassword.Equals(customer.Password.TrimEnd()))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(configuration.GetSection("key").Value);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, customer.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                customer.Token = tokenHandler.WriteToken(token);
                return WithoutPassword(customer);
            }
            else
                return null;
        }



        private static Customer WithoutPassword(Customer customer)
        {
            customer.Password = null;
            return customer;
        }


    }

}
