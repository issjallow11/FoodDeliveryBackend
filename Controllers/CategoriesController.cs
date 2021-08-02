using FoodDeliveryBackend.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDeliveryBackend.Models;

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
        
    }
}
