using FoodDeliveryBackend.Data.Services;
using FoodDeliveryBackend.Data.ViewModels;
using FoodDeliveryBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticateService _service;

        public AuthController(IAuthenticateService service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public IActionResult Register([FromBody] User user)
        {
            try
            {
                _service.Register(user);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("[action]")]
        public IActionResult Authenticate([FromBody] AuthUser user)
        {
            try
            {
                var token = _service.Authenticate(user);
                if (token == null)
                {
                    return Unauthorized("invalid credentials");
                }
                return Ok(token);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
