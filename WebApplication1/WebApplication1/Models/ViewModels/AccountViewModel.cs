using System;

namespace WebApplication1.Models.ViewModels
{
    public class AccountViewModel
    {
        public string Type { get; set; }
        public float Value { get; set; }
        public DateTime Created { get; set; }
        public string Note { get; set; }
    }
}