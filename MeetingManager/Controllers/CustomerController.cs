using BL;
using DTO;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeetingManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerBL customerBL;
        ILogger logger;


        public CustomerController(ICustomerBL customerBL, ILogger<CustomerController> logger)
        {
            this.logger = logger;
            this.customerBL = customerBL;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<List<Customer>> Get()
        {
            return await customerBL.GetAllCustomers();
        }


        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<Customer> Get(int id)
        {
            return await customerBL.GetCustomerByID(id);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task Post([FromBody] Customer customer)
        {
            await customerBL.PostCustomer(customer);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Customer value)
        {
            await customerBL.PutCustomer(id, value);
        }

        // DELETE api/<CustomerController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        [HttpPost("Login")]
        [AllowAnonymous]

        public async Task<ActionResult<Customer>> Login([FromBody] CustomerLoginDTO customer)
        {
            logger.LogInformation("customerName:" + customer.Name + "  password:" + customer.Password);
            Customer c = await customerBL.Login(customer.Name, customer.Password);
            if (c == null)
                return NoContent();
            else
                return Ok(c);
        }
    }
}
