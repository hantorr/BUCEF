using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BUCEF.Models.BD;

namespace BUCEF.Controllers.Personas
{
    public class LocalizacionController : Controller
    {
        private readonly BucContext _context;

        public LocalizacionController(BucContext context)
        {
            _context = context;
        }

        // GET: Localizacion
        public async Task<IActionResult> Index()
        {
            return View(await _context.Localizacion.ToListAsync());
        }

        // GET: Localizacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localizacion = await _context.Localizacion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (localizacion == null)
            {
                return NotFound();
            }

            return View(localizacion);
        }

        // GET: Localizacion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Localizacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Direccion,Ciudad")] Localizacion localizacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(localizacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(localizacion);
        }

        // GET: Localizacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localizacion = await _context.Localizacion.FindAsync(id);
            if (localizacion == null)
            {
                return NotFound();
            }
            return View(localizacion);
        }

        // POST: Localizacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Direccion,Ciudad")] Localizacion localizacion)
        {
            if (id != localizacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(localizacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalizacionExists(localizacion.Id))
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
            return View(localizacion);
        }

        // GET: Localizacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localizacion = await _context.Localizacion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (localizacion == null)
            {
                return NotFound();
            }

            return View(localizacion);
        }

        // POST: Localizacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var localizacion = await _context.Localizacion.FindAsync(id);
            _context.Localizacion.Remove(localizacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalizacionExists(int id)
        {
            return _context.Localizacion.Any(e => e.Id == id);
        }
    }
}
