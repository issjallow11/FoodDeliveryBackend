using FoodDeliveryBackend.Data.Services;
using FoodDeliveryBackend.Data.ViewModels;
using FoodDeliveryBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDeliveryBackend.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace FoodDeliveryBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticateService _service;
        private readonly JwtService _jwtService;


        public AuthController(IAuthenticateService service,JwtService jwtService)
        {
            _service = service;
            _jwtService = jwtService;
        }

        [HttpPost("[action]")]
        public IActionResult Register([FromBody]RegisterDto dto )
        {
            try
            {
                
                var register = new User()
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Email = dto.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                    Role = dto.Role
                };
                
                
                _service.Register(register);
                return Ok("success");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("user")]
        //[Authorize]
        public IActionResult Index()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var user = _service.GetById(userId);
                
                return Ok(user);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        

        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] AuthUser dto)
        {
            try
            {
                
                /*var token = _service.Authenticate(user);
                if (token == null)
                {
                    return Unauthorized("invalid credentials");
                }
                return Ok(token);*/
                
                var user = _service.GetByEmail(dto.Email);
                if (user == null)
                {
                    return BadRequest("invalid credentials");
                }

                if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                {
                    return BadRequest("invalid credentials");
                }
                

                var jwt = _jwtService.Generate(user.Id);
                
                Response.Cookies.Append("jwt",jwt,new CookieOptions
                {
                    HttpOnly = true
                });

                return Ok(new
                {
                    jwt
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");

            return Ok("Success");
        }
        
    }
}
