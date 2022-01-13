using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.Areas.Admin.Models
{
    public class BranchModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Branchname", AllowEmptyStrings = false)]

        public String Name { get; set; }
     //   [DataType(DataType.MultilineText)]
        public String Address { get; set; }

        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Please Enter Valid Mobile Number.")]
        public string Mobile { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
    }
    public class PagedBranchModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Branchname", AllowEmptyStrings = false)]

        public String Name { get; set; }
        [DataType(DataType.MultilineText)]
        public String Address { get; set; }

        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Please Enter Valid Mobile Number.")]
        public string Mobile { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        public List<BranchModel> BranchModel { get; set; }

    }
}
