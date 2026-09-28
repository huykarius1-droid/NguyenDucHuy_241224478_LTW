using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TvcLesson7DataValidation_Annotation.Models
{
    public class TvcMember
    {
        public int Id { get; set; }

        [DisplayName("Tài khoản")]
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Tài khoản phải có độ dài từ 3-20 ký tự")]
        public string TvcUserName { get; set; } = string.Empty;

        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Hãy nhập mật khẩu")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Mật khẩu phải có tối thiểu 8 ký tự")]
        [DataType(DataType.Password)]
        public string TvcPassword { get; set; } = string.Empty;

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email không được để trống")]
        [DataType(DataType.EmailAddress)]
        public string TvcEmail { get; set; } = string.Empty;

        [DisplayName("Số điện thoại")]
        [RegularExpression(@"^0\d{9}$", ErrorMessage = "Số điện thoại phải là 10 ký tự số, bắt đầu bằng 0")]
        public string TvcPhone { get; set; } = string.Empty;
    }
}