using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab.EF.WebApi.Models
{
    public class ShippersViewModel
    {
        public int ID { get; set; }

        [Required] public string CompanyName { get; set; }

        public string Phone { get; set; }
    }
}