using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackWorkProject.WebUI.Data;
using TrackWorkProject.WebUI.Entities;
using TrackWorkProject.WebUI.Models;

namespace TrackWorkProject.WebUI.Controllers
{
    public class DirectorateController : Controller
    {
        private readonly AppDbContext _context;

        public DirectorateController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {var response= _context.Directorates.Include(d=>d.Duties).Select(d=>new DirectorateDutiesViewModel { 
        Id = d.Id,
        Name = d.Name,
        Duties = d.Duties.ToList()


        }).ToList();
            return View(response);
        }
        public IActionResult Create() => View();
        [HttpPost]

        public IActionResult Create(Directorate directorate)
        {
            if (!ModelState.IsValid) return View(directorate);
            directorate.CreatedDate = DateTime.Now;
            _context.Directorates.Add(directorate);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var directorate = _context.Directorates.Find(id);
            if (directorate == null)
            {
                return NotFound();
            }
            return View(directorate);
        }
        [HttpPost]
        public IActionResult Edit(Directorate directorate)
        {
            if (ModelState.IsValid)
            {
                _context.Directorates.Update(directorate);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(directorate);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var directorate = _context.Directorates.Find(id);
            if (directorate == null)
            {
                return NotFound();
            }
            return View(directorate);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var directorate = _context.Directorates.Find(id);
            if (directorate == null)
            {
                return NotFound();
            }
            _context.Directorates.Remove(directorate);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
