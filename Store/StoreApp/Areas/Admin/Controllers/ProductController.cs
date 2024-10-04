using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model = _manager.ProductService.GetAllProducts(false);

            return View(model);
        }
        public IActionResult Create()
        {
            ViewBag.Categories= GetCategoriesSelectList();
            
            
            return View();
        }

        private SelectList GetCategoriesSelectList()
        {
            return new SelectList(_manager.CategoryService.GetAllCategories(false),
            "CategoryId",
            "CategoryName",1);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] ProductDTO_ForInsertion productDto)
        {
            if (ModelState.IsValid)
            {
                _manager.ProductService.CreateProduct(productDto);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Update([FromRoute(Name ="id")]int id)
        {
            ViewBag.Categories= GetCategoriesSelectList();
            var model= _manager.ProductService.GetOneProductForUpdate(id,false);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromForm] ProductDTO_ForUpdate product)
        {
            if(ModelState.IsValid)
            {
                _manager.ProductService.UpdateOneProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete([FromRoute(Name ="id")]int id)
        {
            _manager.ProductService.DeleteOneProduct(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
