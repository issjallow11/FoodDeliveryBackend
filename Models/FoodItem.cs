using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryBackend.Models
{
    public class FoodItem
    {
        [Key]
        public int id { get; set; }
        
        [Required]
        public string Image { get; set; }

        [Required]
        public string Name { get; set; }


        [Required]
        public int price { get; set; }

        public List<Category> Categories { get; set; }
    }
}
