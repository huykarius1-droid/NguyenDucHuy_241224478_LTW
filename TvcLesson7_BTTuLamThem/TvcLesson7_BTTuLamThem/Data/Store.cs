using TvcLesson7_BTTuLamThem.Models;

namespace TvcLesson7_BTTuLamThem.Data;

public static class Store
{
    public static List<Category> Categories = new()
    {
        new Category { Id = 1, Name = "Điện thoại" },
        new Category { Id = 2, Name = "Laptop" },
        new Category { Id = 3, Name = "Phụ kiện" },
    };

    public static List<Product> Products = new();

    public static int NextProductId() =>
        Products.Count == 0 ? 1 : Products.Max(p => p.Id) + 1;
}