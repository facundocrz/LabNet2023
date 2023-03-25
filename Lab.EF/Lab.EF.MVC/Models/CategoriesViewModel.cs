using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab.EF.MVC.Models
{
    public class CategoriesViewModel
    {

        [Required] public int ID { get; set; }

        [Required] public string CategoryName { get; set; }

        public string Description { get; set; }
    }
}