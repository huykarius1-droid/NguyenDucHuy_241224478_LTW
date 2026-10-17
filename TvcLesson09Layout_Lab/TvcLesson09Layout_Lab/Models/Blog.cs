using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvcLesson09Layout_Lab.Models
{
    [Table("Blog")]
    public class Blog
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tiêu đề bài viết không được để trống")]
        [StringLength(100)]
        public string Name { get; set; }

        public byte Status { get; set; } = 1; // Mặc định 1

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [StringLength(100)]
        public string Image { get; set; }

        [StringLength(350)]
        public string Description { get; set; }
    }
}