using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FoodDeliveryBackend.Data;
using FoodDeliveryBackend.Data.ViewModels;
using FoodDeliveryBackend.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemController : ControllerBase
    {
        
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public FoodItemController(AppDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }
        // GET: api/FoodItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodItem>>> GetFoodItems()
        {
            return await _context.FoodItems
                .Select(x => new FoodItem() { 
                    id = x.id,
                    Name = x.Name,
                    price = x.price,
                    Image = x.Image,
                    Description = x.Description,
                    ImageSrc = String.Format("{0}://{1}{2}/Images/{3}",Request.Scheme,Request.Host,Request.PathBase,x.Image)
                })
                .ToListAsync();
        }

        // GET: api/FoodItem/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/FoodItem
        [HttpPost]
        public async Task<ActionResult<FoodItem>> PostFoodItem([FromForm]FoodItem foodItem)
        {

            try
            {
                foodItem.Image = await SaveImage(foodItem.ImageFile);
                _context.FoodItems.Add(foodItem);
                await _context.SaveChangesAsync();

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
          
        }

        // PUT: api/FoodItem/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/FoodItem/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        
        private bool FoodItemExists(int id)
        {
            return _context.FoodItems.Any(e => e.id==id);
        }

        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string image = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            image = image+ DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", image);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return image;
        }

        [NonAction]
        public void DeleteImage(string image)
        {
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", image);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }
        
        
    }
}
