﻿using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface ICustomerDL
    {
        public Task<List<Customer>> GetAllCustomers();
        public Task PostCustomer(Customer customer);
        public Task<Customer> GetCustomerByID(int id);
        public Task PutCustomer(int id, Customer customer);
        public Task<Customer> Login(string name);


    }
}