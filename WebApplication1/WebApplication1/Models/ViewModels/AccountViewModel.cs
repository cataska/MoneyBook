using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.ViewModels
{
    public enum CategoryEnum
    {
        支出,
        收入
    }

    public class AccountViewModel
    {
        [Display(Name = "類別")]
        public CategoryEnum Category { get; set; }

        [Display(Name = "金額")]
        [Required]
        [Range(1, int.MaxValue)]
        public float Value { get; set; }

        [Display(Name = "日期")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        [Display(Name = "備註")]
        [StringLength(100)]
        public string Note { get; set; }
    }
}