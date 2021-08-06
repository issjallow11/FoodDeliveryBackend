using FoodDeliveryBackend.Data.Services;
using FoodDeliveryBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet]

        public IActionResult Index()
        {
            try
            {
                return Ok(_service.GetOrders());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory([FromRoute] int id)
        {
            try
            {
                return Ok(_service.GetOrder(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult AddOrder([FromBody] Order order)
        {
            try
            {
                _service.AddOrder(order);
                return Ok(new { Success = "Successfully added new record" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateCategory([FromBody] Order order)
        {
            try
            {
                _service.UpdateOrder(order);
                return Ok(new { Success = "Successfully updated record" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteCategory([FromRoute] int id)
        {
            try
            {
                _service.DeleteOrder(id);
                return Ok(new { Success = "Successfully deleted record" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
