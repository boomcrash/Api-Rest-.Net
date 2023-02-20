using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrochbet.Controllers
{
    public class CarritoController : Controller
    {
        // GET: CarritoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CarritoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CarritoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarritoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarritoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CarritoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarritoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CarritoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
