using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FoodDeliveryBackend.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [JsonIgnore]public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        [NotMapped]
        public string Name => FirstName + " " + LastName;


    }
}
