using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Item
    {
        public string Type { get; set; }
        public float Value { get; set; }
        public DateTime Created { get; set; }
        public string Note { get; set; }
    }
}