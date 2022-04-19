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
    public class OrderController : ControllerBase
    {
        Order model = new Order();

        [HttpGet]
        [Route("getorder")]
        public IActionResult GetOrderById(int orderId)
        {
            try
            {
                return Ok(model.GetOrder(orderId));
            }
            catch(Exception es)
            {
                return BadRequest(es.Message);
            }
        }

        [HttpGet]
        [Route("getcustomerorderhistory")]
        public IActionResult GetOrderHistory(int customerId)
        {
            try
            {
                return Ok(model.GetCustomerOrderHistory(customerId));
            }
            catch (Exception es)
            {
                return BadRequest(es.Message);
            }
        }

        [HttpPost]
        [Route("addorder")]
        public IActionResult AddOrder(Order newOrder)
        {
            try
            {
                return Created("", model.addOrder(newOrder));
            }
            catch (Exception es)
            {
                return BadRequest(es.Message);
            }
        }
    }
}