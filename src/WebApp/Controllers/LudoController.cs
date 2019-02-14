using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class LudoController : Controller
    {
        // GET: Ludo
        public ActionResult Index()
        {
            return View();
        }

        // GET: Ludo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ludo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ludo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Ludo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ludo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Ludo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ludo/Delete/5
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