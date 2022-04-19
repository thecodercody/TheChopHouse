using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheChopHouse.Models;

namespace TheChopHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        Customer model = new Customer();

        [HttpGet]
        [Route("getcustomer")]
        public IActionResult GetCustomerById(int customerId)
        {
            try
            {
                return Ok(model.GetCustomer(customerId));
            }
            catch(Exception es)
            {
                return BadRequest(es.Message);
            }
        }

        [HttpGet]
        [Route("customerlist")]
        public IActionResult GetCustomerHistory()
        {
            return Ok(model.CustomerList());
        }

        [HttpGet]
        [Route("customerinvoice")]
        public IActionResult CustomerInvoice(int customerId)
        {
            try
            {
                return Ok(model.customerInvoice(customerId));
            }
            catch (Exception es)
            {
                return BadRequest(es.Message);
            }
        }

        [HttpPost]
        [Route("addcustomer")]
        public IActionResult AddCustomer(Customer newCustomer)
        {
            try
            {
                return Created("", model.addCustomer(newCustomer));
            }
            catch (System.Exception es)
            {
                return BadRequest(es.Message);
            }
        }
    }
}