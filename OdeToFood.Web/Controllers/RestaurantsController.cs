using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData db;

        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;
        }
        // GET: Restaurants
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var model = db.Get(id);

            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        public ActionResult Create ()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaunrant)
        {
            if (String.IsNullOrEmpty(restaunrant.Name))
            {
                ModelState.AddModelError(nameof(restaunrant.Name), "The name is required");
            }

            if (ModelState.IsValid)
            {
                db.Add(restaunrant);
                return RedirectToAction("Details", new { id = restaunrant.Id });
            }
                        
            return View();
        }

        
        public ActionResult Edit (int id)
        {

            var model = db.Get(id);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaunrant)
        {
            if (ModelState.IsValid)
            {
                db.Update(restaunrant);
                TempData["Message"] = "The record has been updated";
                return RedirectToAction("Details", new { id = restaunrant.Id }); 
            }

            return View();
        }

        public ActionResult Delete(int id)
        {

            var model = db.Get(id);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                db.Delete(id);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}