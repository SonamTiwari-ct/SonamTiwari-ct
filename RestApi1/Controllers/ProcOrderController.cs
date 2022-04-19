using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApi1.Services;
using RestApi1.Domain;

namespace RestApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcOrderController : Controller
    {
        protected readonly IProcOrderservice _procOrderservice;
        public ProcOrderController(IProcOrderservice procOrderservice)
        {
            _procOrderservice = procOrderservice;
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddOrder([FromBody] Orders obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
           var res= _procOrderservice.AddOrder(obj);
           return Ok(res);
         }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
       public async Task<IActionResult> GetAllOrder()
        {
            var order = _procOrderservice.GetAllOrder();
            return Ok(order);
        }
       
        [HttpGet]
        [Route("ByEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOrderByEmail(string Email)
        {
            var order = _procOrderservice.GetOrderByEmail(Email);
            return Ok(order);
        }
        
        [HttpGet]
        [Route("ByUserId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult>GetOrderByUserId(int UserId)
        { 
            var order = _procOrderservice.GetOrderByUserId(UserId);
            return Ok(order);
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult UpdateOrder([FromBody] Orders order)
        {
            var res = _procOrderservice.UpdateOrder(order);
            return Ok(res);
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public  IActionResult DeleteOrder(int UserId)
        {
        var Result = _procOrderservice.DeleteOrder(UserId);
            return Ok(Result);
        }
       

    }
}
