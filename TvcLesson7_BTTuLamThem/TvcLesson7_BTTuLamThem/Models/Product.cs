using System.ComponentModel.DataAnnotations;

namespace TvcLesson7_BTTuLamThem.Models;

public class Product : IValidatableObject
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
    [StringLength(150, MinimumLength = 6,
        ErrorMessage = "Tên sản phẩm phải từ 6 đến 150 ký tự")]
    public string Name { get; set; } = "";

    // Lưu tên file ảnh sau khi upload
    public string Image { get; set; } = "";

    [Required(ErrorMessage = "Vui lòng nhập giá")]
    [Range(100000, float.MaxValue, ErrorMessage = "Giá phải từ 100.000 trở lên")]
    public float? Price { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập giá khuyến mãi")]
    public float? SalePrice { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập mô tả")]
    [StringLength(1500, ErrorMessage = "Mô tả không được vượt quá 1500 ký tự")]
    public string Description { get; set; } = "";

    [Required(ErrorMessage = "Vui lòng chọn danh mục")]
    public int? CategoryId { get; set; }

    // Chỉ dùng để nhận file từ form
    public IFormFile? ImageFile { get; set; }

    private static readonly string[] BadWords = { "die", "admin", "fack" };

    public IEnumerable<ValidationResult> Validate(ValidationContext context)
    {
        if (SalePrice < 0)
            yield return new ValidationResult(
                "Giá khuyến mãi không được âm", new[] { nameof(SalePrice) });

        // Giá KM phải thấp hơn giá chuẩn ít nhất 10%
        if (Price.HasValue && SalePrice.HasValue && SalePrice > Price * 0.9f)
            yield return new ValidationResult(
                "Giá khuyến mãi phải nhỏ hơn giá chuẩn ít nhất 10%",
                new[] { nameof(SalePrice) });

        if (!string.IsNullOrEmpty(Description) &&
            BadWords.Any(w => Description.Contains(w, StringComparison.OrdinalIgnoreCase)))
            yield return new ValidationResult(
                "Mô tả chứa từ nhạy cảm, vui lòng chỉnh sửa lại",
                new[] { nameof(Description) });
    }
}