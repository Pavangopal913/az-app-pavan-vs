using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mvc.StorageAccount.Demo.Controllers
{
    public class AttendeeRegistrationController : Controller
    {
        // GET: AttendeeRegistrationController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AttendeeRegistrationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AttendeeRegistrationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AttendeeRegistrationController/Create
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

        // GET: AttendeeRegistrationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AttendeeRegistrationController/Edit/5
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

        // GET: AttendeeRegistrationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AttendeeRegistrationController/Delete/5
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
