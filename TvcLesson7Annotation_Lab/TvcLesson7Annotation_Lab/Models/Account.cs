using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TvcLesson7Annotation_Lab.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [
            Display(Name = "Họ và tên"),
            Required(ErrorMessage = "Họ và tên không được để trống"),
            MinLength(6, ErrorMessage = "Họ và tên có ít nhất là 6 ký tự"),
            MaxLength(20, ErrorMessage = "Họ và tên có tối đa 20 ký tự")
        ]
        public string FullName { get; set; } = string.Empty;
        [Display(Name = "Nhập địa chỉ Email")]
        [Required(ErrorMessage = "Địa chỉ Email không được để trống")]
        [EmailAddress(ErrorMessage = "Địa chỉ Email không đúng định dạng")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Nhập số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [Remote(action: "VerifyPhone", controller :"Account")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; } = string.Empty;

        [Display(Name = "Nhập địa chỉ thường trú")]
        [Required(ErrorMessage = "Địa chỉ thường trú không được để trống")]
        [StringLength(35, MinimumLength = 5, ErrorMessage = " Mật khẩu phải có tối thiểu 5 ký tự và tối đa 35 ký tự")]

        public string Address { get; set; } = string.Empty;

        [Display(Name = "Ảnh đại diện ")]
        public string Avatar { get; set; } = string.Empty;

        [Display(Name = "Nhập ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Display(Name = "Giới tính")]
        public string Gender { get; set; } = string.Empty;

        [Display(Name = "Nhập mật khẩu")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải có tối thiểu 6 ký tự")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Link facebook cá nhân")]
        [Required(ErrorMessage = "Link facebook cá nhân không được để trống")]
        [Url(ErrorMessage = "Url phải đúng định dạng bao gồm http hoặc https, tên miền VD: https://facebook.com/itvnsoft")]
        public string Facebook { get; set; } = string.Empty;
    }
}
