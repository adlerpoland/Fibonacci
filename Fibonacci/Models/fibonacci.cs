using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fibonacci.Models
{
    public class fibonacci
    {
        public int ID { get; set; }

        [Required]
        [DisplayName("Data name")]
        public String name { get; set; }

        [Required]
        [DisplayName("Value")]
        public int n { get; set; }

        [DisplayName("Username")]
        public string UserName { get; set; }
    }
}