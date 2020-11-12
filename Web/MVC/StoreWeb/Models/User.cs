using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using StoreDB.Models;

namespace StoreWeb.Models
{
    public class User
    {
        public int id { get; set; }

        [Required]
        public int locationId { get; set; }
        public Location location { get; set; }

        [Required]
        [RegularExpression("[\\d]")]
        public string name { get; set; }

        [Required]
        [RegularExpression(@"^[a-z0-9.]+@[a-z0-9]+[\.][a-z]")]
        public string email { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }

        public StoreDB.Models.User.userType type { get; set; }

        public List<Order> orders { get; set; }

        public Cart cart { get; set; }
    }
}
