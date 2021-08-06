using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryBackend.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }


        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }


        [Required]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }
        
        [Required]
        public string FoodItemName { get; set; }

        [Required]
        public string Status { get; set; }
        
        
        
    }
}
