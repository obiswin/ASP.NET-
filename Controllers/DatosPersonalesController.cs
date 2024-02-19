using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using practica04.Models;

namespace practica04.Controllers
{
    public class DatosPersonalesController : Controller
    {
        private readonly BdpersonalContext _context;

        public DatosPersonalesController(BdpersonalContext context)
        {
            _context = context;
        }

        // GET: DatosPersonales
        public async Task<IActionResult> Index()
        {
            return View(await _context.DatosPersonales.ToListAsync());
        }

        // GET: DatosPersonales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datosPersonale = await _context.DatosPersonales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (datosPersonale == null)
            {
                return NotFound();
            }

            return View(datosPersonale);
        }

        // GET: DatosPersonales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DatosPersonales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Celular,Carnet,Direccion")] DatosPersonale datosPersonale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(datosPersonale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(datosPersonale);
        }

        // GET: DatosPersonales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datosPersonale = await _context.DatosPersonales.FindAsync(id);
            if (datosPersonale == null)
            {
                return NotFound();
            }
            return View(datosPersonale);
        }

        // POST: DatosPersonales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Celular,Carnet,Direccion")] DatosPersonale datosPersonale)
        {
            if (id != datosPersonale.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(datosPersonale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatosPersonaleExists(datosPersonale.Id))
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
            return View(datosPersonale);
        }

        // GET: DatosPersonales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datosPersonale = await _context.DatosPersonales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (datosPersonale == null)
            {
                return NotFound();
            }

            return View(datosPersonale);
        }

        // POST: DatosPersonales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var datosPersonale = await _context.DatosPersonales.FindAsync(id);
            if (datosPersonale != null)
            {
                _context.DatosPersonales.Remove(datosPersonale);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatosPersonaleExists(int id)
        {
            return _context.DatosPersonales.Any(e => e.Id == id);
        }
    }
}
