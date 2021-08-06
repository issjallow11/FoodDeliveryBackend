using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FoodDeliveryBackend.Models
{
    public class FoodItem
    {
        [Key]
        public int id { get; set; }
        
        
        public string Image { get; set; }

        
        public string Name { get; set; }    
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        
        [NotMapped]
        public string ImageSrc { get; set; }

        [Required]
        public int price { get; set; }
        
        public string description { get; set; }
         
        public string category { get; set; }
        
        //[ForeignKey("CategoryId")]
       // public Category Category { get; set; }

       

    }
}
