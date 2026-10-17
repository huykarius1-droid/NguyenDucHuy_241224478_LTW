using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvcLesson09Layout_Lab.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [StringLength(100, ErrorMessage = "Tên danh mục không vượt quá 100 ký tự")]
        public string Name { get; set; }

        public byte Status { get; set; } = 1; // Mặc định 1

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; } = DateTime.Now; // Mặc định ngày hiện tại
    }
}