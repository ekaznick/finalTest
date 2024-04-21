using finalTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace finalTest.Controllers
{
    public class HomeController : Controller
    {
        private IEntertainmentRepository _repo; 
        public HomeController(IEntertainmentRepository temp) 
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Entertainers()
        {
            var viewAll = _repo.Entertainers.ToList();

            return View(viewAll);
        }


        [HttpGet]
        public IActionResult AddEnt()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEnt(Entertainer e)
        {
            if (ModelState.IsValid)
            {
                _repo.AddEntertainer(e);
                return RedirectToAction("Entertainers");
            }

            return View(new Entertainer());
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var entertainer = _repo.GetEntertainer(id);

            return View(entertainer); 
        }

        [HttpGet]
        public IActionResult EditEnt(int id)
        {
            var entertainer = _repo.GetEntertainer(id);

            return View(entertainer);
        }

        [HttpPost]
        public IActionResult EditEnt(int id, Entertainer e)
        {
            if (!ModelState.IsValid)
            {
                return View(e);  
            }
            _repo.UpdateEntertainer(e);  
            return RedirectToAction("Details", new { id = e.EntertainerId });  
        }

        [HttpGet]
        public IActionResult DeleteConfirm(int id)
        {
            var entertainer = _repo.GetEntertainer(id);
            if (entertainer == null)
            {
                return NotFound();
            }
            return View(entertainer);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(Entertainer entertainer)
        {
            _repo.DeleteEntertainer(entertainer);

            return RedirectToAction("Entertainers");
        }
    }
}
