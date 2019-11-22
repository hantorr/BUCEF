using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BUCEF.Models.BD;

namespace BUCEF.Controllers
{
    public class PersonaNaturalController : Controller
    {
        private readonly BucContext _context;

        public PersonaNaturalController(BucContext context)
        {
            _context = context;
        }

        // GET: PersonaNatural
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonaNatural.ToListAsync());
        }

        // GET: PersonaNatural/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personaNatural = await _context.PersonaNatural
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personaNatural == null)
            {
                return NotFound();
            }

            return View(personaNatural);
        }

        // GET: PersonaNatural/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonaNatural/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombres,Apellidos")] PersonaNatural personaNatural)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personaNatural);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personaNatural);
        }

        // GET: PersonaNatural/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personaNatural = await _context.PersonaNatural.FindAsync(id);
            if (personaNatural == null)
            {
                return NotFound();
            }
            return View(personaNatural);
        }

        // POST: PersonaNatural/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombres,Apellidos")] PersonaNatural personaNatural)
        {
            if (id != personaNatural.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personaNatural);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaNaturalExists(personaNatural.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(personaNatural);
        }

        // GET: PersonaNatural/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personaNatural = await _context.PersonaNatural
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personaNatural == null)
            {
                return NotFound();
            }

            return View(personaNatural);
        }

        // POST: PersonaNatural/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personaNatural = await _context.PersonaNatural.FindAsync(id);
            _context.PersonaNatural.Remove(personaNatural);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonaNaturalExists(int id)
        {
            return _context.PersonaNatural.Any(e => e.Id == id);
        }
    }
}
