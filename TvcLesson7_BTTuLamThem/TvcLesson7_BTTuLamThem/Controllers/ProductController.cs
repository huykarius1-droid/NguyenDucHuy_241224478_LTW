using TvcLesson7_BTTuLamThem.Data;
using TvcLesson7_BTTuLamThem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TvcLesson7_BTTuLamThem.Controllers;

public class ProductController : Controller
{
    private readonly IWebHostEnvironment _env;
    public ProductController(IWebHostEnvironment env) => _env = env;

    private void LoadCategories(int? selected = null) =>
        ViewBag.Categories = new SelectList(Store.Categories, "Id", "Name", selected);

    private async Task<string> SaveImage(IFormFile file)
    {
        var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
        var path = Path.Combine(_env.WebRootPath, "products", fileName);
        using var stream = new FileStream(path, FileMode.Create);
        await file.CopyToAsync(stream);
        return fileName;
    }

    private bool IsImage(IFormFile file)
    {
        var ext = Path.GetExtension(file.FileName).ToLower();
        return new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" }.Contains(ext);
    }

    public IActionResult Index()
    {
        ViewBag.Categories = Store.Categories;
        return View(Store.Products);
    }

    public IActionResult Create()
    {
        LoadCategories();
        return View(new Product());
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product model)
    {
        ModelState.Remove(nameof(Product.Image));

        if (model.ImageFile == null)
            ModelState.AddModelError("ImageFile", "Vui lòng chọn ảnh sản phẩm");
        else if (!IsImage(model.ImageFile))
            ModelState.AddModelError("ImageFile", "File phải là ảnh (jpg, png, gif, webp)");

        if (model.CategoryId != null && !Store.Categories.Any(c => c.Id == model.CategoryId))
            ModelState.AddModelError("CategoryId", "Danh mục không tồn tại");

        if (!ModelState.IsValid)
        {
            LoadCategories(model.CategoryId);
            return View(model);
        }

        model.Image = await SaveImage(model.ImageFile!);
        model.Id = Store.NextProductId();
        Store.Products.Add(model);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var p = Store.Products.FirstOrDefault(x => x.Id == id);
        if (p == null) return NotFound();
        LoadCategories(p.CategoryId);
        return View(p);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Product model)
    {
        var old = Store.Products.FirstOrDefault(x => x.Id == model.Id);
        if (old == null) return NotFound();

        ModelState.Remove(nameof(Product.Image));

        if (model.ImageFile != null && !IsImage(model.ImageFile))
            ModelState.AddModelError("ImageFile", "File phải là ảnh (jpg, png, gif, webp)");

        if (model.CategoryId != null && !Store.Categories.Any(c => c.Id == model.CategoryId))
            ModelState.AddModelError("CategoryId", "Danh mục không tồn tại");

        if (!ModelState.IsValid)
        {
            model.Image = old.Image;
            LoadCategories(model.CategoryId);
            return View(model);
        }

        if (model.ImageFile != null) old.Image = await SaveImage(model.ImageFile);
        old.Name = model.Name;
        old.Price = model.Price;
        old.SalePrice = model.SalePrice;
        old.Description = model.Description;
        old.CategoryId = model.CategoryId;
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Details(int id)
    {
        var p = Store.Products.FirstOrDefault(x => x.Id == id);
        if (p == null) return NotFound();
        ViewBag.CategoryName = Store.Categories.FirstOrDefault(c => c.Id == p.CategoryId)?.Name;
        return View(p);
    }

    public IActionResult Delete(int id)
    {
        var p = Store.Products.FirstOrDefault(x => x.Id == id);
        if (p == null) return NotFound();
        ViewBag.CategoryName = Store.Categories.FirstOrDefault(c => c.Id == p.CategoryId)?.Name;
        return View(p);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var p = Store.Products.FirstOrDefault(x => x.Id == id);
        if (p != null) Store.Products.Remove(p);
        return RedirectToAction(nameof(Index));
    }
}