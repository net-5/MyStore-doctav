using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Services;
using Store.Domain.Entities;

namespace FirstProject.MVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        // GET: Categories
        public ActionResult Index()
        {
            var allCategories = categoryService.GetAllCategories();
            return View(allCategories);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            Categories category = categoryService.GetCategoryById(id);
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categories model)
        {
            if(ModelState.IsValid)
            {
                var addedCategory = categoryService.AddCategory(model);
                if (addedCategory ==null)
                {
                    ModelState.AddModelError("Categoryname","Category name must be Unique!");
                    return View(model);
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                return View(model);
            }
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            var category = categoryService.GetCategoryById(id);
            return View(category);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Categories model)
        {
            if (ModelState.IsValid)
            {
                var existingCategory = categoryService.GetCategoryById(id);
                TryUpdateModelAsync(existingCategory);
                categoryService.UpdateCategory(existingCategory);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Categories/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}