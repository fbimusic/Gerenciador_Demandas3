using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gerenciador_Demandas3.Models;

namespace Gerenciador_Demandas3.Controllers
{
    public class DemandasController : Controller
    {
        private readonly DemandasContexto _context;

        public DemandasController(DemandasContexto context)
        {
            _context = context;
        }

        // GET: Demandas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Demandas.ToListAsync());
        }

        // GET: Demandas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demandas = await _context.Demandas
                .FirstOrDefaultAsync(m => m.DemandasId == id);
            if (demandas == null)
            {
                return NotFound();
            }

            return View(demandas);
        }

        // GET: Demandas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Demandas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DemandasId,Nome,Descricao,Inicio,Fim,Importancia")] Demandas demandas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(demandas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(demandas);
        }

        // GET: Demandas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demandas = await _context.Demandas.FindAsync(id);
            if (demandas == null)
            {
                return NotFound();
            }
            return View(demandas);
        }

        // POST: Demandas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DemandasId,Nome,Descricao,Inicio,Fim,Importancia")] Demandas demandas)
        {
            if (id != demandas.DemandasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(demandas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DemandasExists(demandas.DemandasId))
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
            return View(demandas);
        }

        // GET: Demandas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demandas = await _context.Demandas
                .FirstOrDefaultAsync(m => m.DemandasId == id);
            if (demandas == null)
            {
                return NotFound();
            }

            return View(demandas);
        }

        // POST: Demandas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var demandas = await _context.Demandas.FindAsync(id);
            _context.Demandas.Remove(demandas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DemandasExists(int id)
        {
            return _context.Demandas.Any(e => e.DemandasId == id);
        }
    }
}
