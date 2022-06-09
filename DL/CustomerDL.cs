using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class CustomerDL: ICustomerDL
    {
        MeetingManagementContext meetingManagementContext;
        public CustomerDL(MeetingManagementContext meetingManagementContext)
        {
            this.meetingManagementContext = meetingManagementContext;
        }

        public async Task<Customer> Login(string name)
        {
            return await meetingManagementContext.Customers.Where(customer => customer.Name == name).FirstOrDefaultAsync();
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await meetingManagementContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerByID(int id)
        {
            return await meetingManagementContext.Customers.Where(customer => customer.Id == id).FirstOrDefaultAsync();

        }

        public async Task PostCustomer(Customer customer)
        {
            await meetingManagementContext.Customers.AddAsync(customer);
            await meetingManagementContext.SaveChangesAsync();
        }

        public async Task PutCustomer(int id, Customer customer)
        {
            Customer c = await meetingManagementContext.Customers.FindAsync(id);
            meetingManagementContext.Entry(c).CurrentValues.SetValues(customer);
            await meetingManagementContext.SaveChangesAsync();
        }


    }
}
