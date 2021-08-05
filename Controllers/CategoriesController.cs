using FoodDeliveryBackend.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDeliveryBackend.Models;
using Microsoft.AspNetCore.Authorization;

namespace FoodDeliveryBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly IAuthenticateService _authService;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        
        public IActionResult Index()
        {
            try
            {
                return Ok(_service.GetCategories());
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet("{id}")]
        public IActionResult GetCategory([FromRoute] int id)
        {
            try
            {
                return Ok(_service.GetCategory(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody] Category category)
        {
            try
            {
                _service.AddCategory(category);
                return Ok(new {Success = "Successfully added new record"});
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPut]
        public IActionResult UpdateCategory([FromBody] Category category)
        {
            try
            {
                _service.UpdateCategory(category);
                return Ok(new {Success = "Successfully updated record"});
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
                _service.DeleteCategory(id);
                return Ok(new {Success = "Successfully deleted record"});
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
    }
}
