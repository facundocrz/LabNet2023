using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab.EF.WebApi.Models
{
    public class CategoriesViewModel
    {
        public int ID { get; set; }

        [Required] public string CategoryName { get; set; }

        public string Description { get; set; }
    }
}