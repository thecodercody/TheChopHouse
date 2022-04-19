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
    public class ItemController : ControllerBase
    {
        Item model = new Item();

        //[HttpGet]
        //[Route("getitems")]

        

        /*
        [HttpPost]
        [Route("AddItem")]
        public IActionResult AddItem(Item newItem)
        {
            try
            {
                return Created("", model.AddItem(newItem));
            }
            catch (System.Exception es)
            {
                return BadRequest(es.Message);
            }
        }


        [HttpDelete]
        [Route("deleteitem")]
        public IActionResult DeleteItem(int empNo)
        {
            try
            {
                return Accepted(model.DeleteItem(item_id));
            }
            catch (System.Exception es)
            {
                return BadRequest(es.Message);
            }
        }

        [HttpPut]
        [Route("updateitem")]
        public IActionResult UpdateItem(Item updates)
        {
            try
            {
                return Accepted(model.UpdateItem(updates));
            }
            catch (System.Exception es)
            {
                return BadRequest(es.Message);
            }
        }
        */
    }
}
