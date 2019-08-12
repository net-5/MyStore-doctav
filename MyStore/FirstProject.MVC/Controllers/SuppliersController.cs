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
    public class SuppliersController : Controller
    {
        private readonly ISupplierService supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            this.supplierService = supplierService;
        }
        // GET: Suppliers
        public ActionResult Index()
        {
            List<Suppliers> allSuppliers = supplierService.GetAllSuppliers();
            return View(allSuppliers);
        }

        // GET: Suppliers/Details/5
        public ActionResult Details(int id)
        {
            Suppliers mySupplier = supplierService.GetSupplierById(id);
            return View(mySupplier);
        }

        // GET: Suppliers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Suppliers model)
        {
            if (ModelState.IsValid)
            {
                if (supplierService.IsUniqueName(model.Companyname))
                {
                    supplierService.Add(model);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("Companyname", "Company name must be unique!");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }

        }

        // GET: Suppliers/Edit/5
        public ActionResult Edit(int id)
        {
            Suppliers supplierToUpdate = supplierService.GetSupplierById(id);
            return View(supplierToUpdate);
        }

        // POST: Suppliers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Suppliers model)
        {

            if (ModelState.IsValid)
            {

                Suppliers existingSupplier = supplierService.GetSupplierById(id);
                TryUpdateModelAsync(existingSupplier);
                supplierService.Update(existingSupplier);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
            
        }




        // GET: Suppliers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Suppliers/Delete/5
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