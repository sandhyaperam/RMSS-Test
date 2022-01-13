using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.Models
{
    public class AdminLogin
    {
        [Required(ErrorMessage = "Please Provide Username", AllowEmptyStrings = false)]

        public String UserName { get; set; }

        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public String Password { get; set; }
    }
}
