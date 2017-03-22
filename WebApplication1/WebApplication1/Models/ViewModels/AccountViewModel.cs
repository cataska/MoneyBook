using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Validations;

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
        [DisplayFormat(DataFormatString = "yyyy-MM-dd", ApplyFormatInEditMode=true)]
        [ValidCreatedDate(ErrorMessage = "日期不可大於今天")]
        public DateTime Created { get; set; }

        [Display(Name = "備註")]
        [Required]
        [StringLength(100)]
        public string Note { get; set; }
    }
}