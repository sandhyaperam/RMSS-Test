using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryApplication.Areas.Admin.Models
{
    public class StateModel
    {
        public List<SelectListItem> Countrys { get; set; }
        public int? Countryid { get; set; }
        public string StateName { get; set; }
    }
}

