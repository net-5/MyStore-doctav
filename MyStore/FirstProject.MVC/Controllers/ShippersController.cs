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
    public class ShippersController : Controller
    {
        private readonly IShipperService shipperService;

        public ShippersController(IShipperService shipperService)
        {
            this.shipperService = shipperService;
        }

        // GET: Shippers
        public ActionResult Index()
        {
            var myShippers = shipperService.GetAllShippers();
            return View(myShippers);
        }

        // GET: Shippers/Details/5
        public ActionResult Details(int id)
        {
            var myShipper = shipperService.GetShippersById(id);
            return View(myShipper);
        }

        // GET: Shippers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shippers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Shippers model)
        {
            if (ModelState.IsValid)
            {
                var addedShipper = shipperService.AddShipper(model);
                if (addedShipper == null)
                {
                    ModelState.AddModelError("Companyname", "Shipper name must be unique!");
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

        // GET: Shippers/Edit/5
        public ActionResult Edit(int id)
        {
            var shipper = shipperService.GetShippersById(id);
            return View(shipper);
        }

        // POST: Shippers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Shippers model)
        {
            if (ModelState.IsValid)
            {
                TryUpdateModelAsync(model);
                shipperService.UpdateShipper(model);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
        }

        // GET: Shippers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Shippers/Delete/5
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