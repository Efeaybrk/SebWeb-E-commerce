using Microsoft.AspNetCore.Mvc;
using Seb.DataAccess.Data;
using Seb.DataAccess.Repository.IRepository;
using Seb.Models;


namespace Seb.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.CategoryName == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CategoryName", "Sipariş Sayısı Kategori Adı ile aynı olamaz");
            }
            if (category.CategoryName != null && category.CategoryName.ToLower() == "test")
            {
                ModelState.AddModelError("", "test");
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(category);
                _unitOfWork.Save();
                TempData["başarılı"] = "Kategori başarıyla oluşturuldu.";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? CategoryID)
        {
            if (CategoryID == null || CategoryID == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.CategoryID == CategoryID);


            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(category);
                _unitOfWork.Save();
                TempData["başarılı"] = "Kategori başarıyla güncellendi.";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? CategoryID)
        {
            if (CategoryID == null || CategoryID == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.CategoryID == CategoryID);


            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? CategoryID)
        {
            Category category = _unitOfWork.Category.Get(u => u.CategoryID == CategoryID);
            if (category == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(category);
            _unitOfWork.Save();
            TempData["başarılı"] = "Kategori başarıyla silindi.";
            return RedirectToAction("Index");


        }
    }
}
