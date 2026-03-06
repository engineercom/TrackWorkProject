using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrackWorkProject.WebUI.Data;
using TrackWorkProject.WebUI.Entities;
using TrackWorkProject.WebUI.Models;

namespace TrackWorkProject.WebUI.Controllers;

public class PersonelController : Controller
{
    private readonly AppDbContext _context;

    public PersonelController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var personels = _context.Personels
            .Include(p => p.PersonelDuties)
            .ThenInclude(pd => pd.Duty)
            .Where(p => !p.IsDeleted)
            .ToList();

        var viewModel = personels.Select(p => new PersonelDutiesViewModel
        {
            Id = p.Id,
            FullName = p.FullName,
            Duties = p.PersonelDuties.Select(pd => pd.Duty).ToList()
        }).ToList();
        return View(viewModel);
    }
    public IActionResult PassiveList()
    {
        var personels = _context.Personels
                .Include(p => p.PersonelDuties)
                .ThenInclude(pd => pd.Duty)
                .Where(p => p.IsDeleted)
                .ToList();
        if (personels == null)
        {
            return NotFound();
        }
        var viewModel = personels.Select(p => new PersonelDutiesViewModel
        {
            Id = p.Id,
            FullName = p.FullName,
            Duties = p.PersonelDuties.Select(pd => pd.Duty).ToList()
        }).ToList();

        return View(nameof(Index), viewModel);
    }
    public IActionResult Passive(int id)
    {

        var personel = _context.Personels.Find(id);
        if (personel == null)
        {
            return NotFound();
        }
        if (personel.IsDeleted)
        {
            personel.IsDeleted = false;
        }
        else {

            personel.IsDeleted = true;
        }

            _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
    public IActionResult Create()
    {
        ViewBag.AllDuties = _context.Duties.ToList();
        return View();
    }
    [HttpPost]

    public IActionResult Create(Personel personel, int[] dutyIds)
    {
        if (ModelState.IsValid)
        {

            _context.Personels.Add(personel);
            _context.SaveChanges();
            foreach (var dutyId in dutyIds)
            {
                var personelDuty = new PersonelDuty
                {
                    PersonelId = personel.Id,
                    DutyId = dutyId
                };
                _context.PersonelDuties.Add(personelDuty);

            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        ViewBag.AllDuties = _context.Duties.ToList();
        return View(personel);
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var personel = _context.Personels
            .Include(p => p.PersonelDuties)
            .FirstOrDefault(p => p.Id == id);
        ViewBag.AllDuties = _context.Duties.ToList();

        if (personel == null)
        {
            return NotFound();
        }
        return View(personel);
    }
    [HttpPost]
    public IActionResult Edit(Personel personel, int[] dutyIds)
    {
        var personelDb = _context.Personels
            .Include(p => p.PersonelDuties)
            .FirstOrDefault(p => p.Id == personel.Id);

        if (personelDb is null) return NotFound();

        if (ModelState.IsValid)
        {
            //personel bilgisi güncelle
            personelDb.FullName = personel.FullName;
            //eski görevleri sil
            personelDb.PersonelDuties.Clear();
            //yeni görevleri ekle
            foreach (var dutyId in dutyIds)
            {
                personelDb.PersonelDuties.Add(new PersonelDuty
                {
                    DutyId = dutyId,
                    PersonelId = personel.Id
                });
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(personel);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var personel = _context.Personels.Find(id);
        if (personel == null)
        {
            return NotFound();
        }
        return View(personel);
    }
    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var personel = _context.Personels.Find(id);
        if (personel == null)
        {
            return NotFound();
        }
        _context.Personels.Remove(personel);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}