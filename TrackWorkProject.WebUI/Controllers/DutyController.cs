using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrackWorkProject.WebUI.Data;
using TrackWorkProject.WebUI.Entities;

namespace TrackWorkProject.WebUI.Controllers
{
    public class DutyController : Controller
    {
        private readonly AppDbContext _context;

        public DutyController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var response=_context.Duties
                .Include(d => d.Directorate)
                .Include(d=>d.PersonelDuties)
                .ThenInclude(pd=>pd.Personel)
                .ToList();

            return View(response);
        }
        public IActionResult Create() 
        {

            ViewBag.Directorates = new SelectList(_context.Directorates,"Id","Name");

            return View(); 
        } 
        [HttpPost]

        public IActionResult Create(Duty duty)
        {
            if (!ModelState.IsValid) return View(duty);
            duty.CreatedDate = DateTime.Now;
            _context.Duties.Add(duty);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));


        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var duty = _context.Duties.Find(id);
            if (duty == null)
            {
                return NotFound();
            }
            return View(duty);
        }
        [HttpPost]
        public IActionResult Edit(Duty duty)
        {
            if (ModelState.IsValid)
            {
                _context.Duties.Update(duty);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(duty);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var duty = _context.Duties.Find(id);
            if (duty == null)
            {
                return NotFound();
            }
            return View(duty);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var duty = _context.Duties.Find(id);
            if (duty == null)
            {
                return NotFound();
            }
            _context.Duties.Remove(duty);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
