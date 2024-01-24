using System.ComponentModel.DataAnnotations;

namespace _0122.Models.ViewModels
{
    public class MemberVm
    {
        [Display(Name = "姓名:")]
        public string? Name { get; set; }

        [Display(Name = "電子郵件:")]
        public string? Email { get; set; }

        [Display(Name = "年紀:")]
        public int Age { get; set; }
    }
}
