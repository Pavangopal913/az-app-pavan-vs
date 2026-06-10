using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvc.StorageAccount.Demo.Services;

namespace Mvc.StorageAccount.Demo.Controllers
{
    public class AttendeeRegistrationController : Controller
    {
        private readonly ITableStorageService _tableStorageService;

        public AttendeeRegistrationController(ITableStorageService tableStorageService)
        {
            _tableStorageService = tableStorageService;
        }

        // GET: AttendeeRegistrationController
        public async Task<IActionResult> IndexAsync()
        {
            var data = await _tableStorageService.GetAttendees();
            return View(data);
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
