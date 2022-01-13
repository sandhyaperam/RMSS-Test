using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.Areas.Admin.Models
{
    public class CountryModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Country Name", AllowEmptyStrings = false)]

        public String Name { get; set; }
        //   [DataType(DataType.MultilineText)]
     
    }
}
