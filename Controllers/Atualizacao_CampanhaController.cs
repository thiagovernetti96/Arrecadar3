using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Arrecadar3.Data;
using Arrecadar3.Models;

namespace Arrecadar3.Controllers
{
    public class Atualizacao_CampanhaController : Controller
    {
        private readonly Arrecadar3Context _context;

        public Atualizacao_CampanhaController(Arrecadar3Context context)
        {
            _context = context;
        }

        // GET: Atualizacao_Campanha
        public async Task<IActionResult> Index()
        {
            var arrecadar3Context = _context.Atualizacao_Campanha.Include(a => a.Campanha);
            return View(await arrecadar3Context.ToListAsync());
        }

        // GET: Atualizacao_Campanha/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Atualizacao_Campanha == null)
            {
                return NotFound();
            }

            var atualizacao_Campanha = await _context.Atualizacao_Campanha
                .Include(a => a.Campanha)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atualizacao_Campanha == null)
            {
                return NotFound();
            }

            return View(atualizacao_Campanha);
        }

        // GET: Atualizacao_Campanha/Create
        public IActionResult Create()
        {
            ViewData["CampanhaId"] = new SelectList(_context.Campanha, "Id", "Descricao");
            return View();
        }

        // POST: Atualizacao_Campanha/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CampanhaId,Titulo,Descricao,Imagem_Url,Data_Publicacao")] Atualizacao_Campanha atualizacao_Campanha)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atualizacao_Campanha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CampanhaId"] = new SelectList(_context.Campanha, "Id", "Descricao", atualizacao_Campanha.CampanhaId);
            return View(atualizacao_Campanha);
        }

        // GET: Atualizacao_Campanha/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Atualizacao_Campanha == null)
            {
                return NotFound();
            }

            var atualizacao_Campanha = await _context.Atualizacao_Campanha.FindAsync(id);
            if (atualizacao_Campanha == null)
            {
                return NotFound();
            }
            ViewData["CampanhaId"] = new SelectList(_context.Campanha, "Id", "Descricao", atualizacao_Campanha.CampanhaId);
            return View(atualizacao_Campanha);
        }

        // POST: Atualizacao_Campanha/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CampanhaId,Titulo,Descricao,Imagem_Url,Data_Publicacao")] Atualizacao_Campanha atualizacao_Campanha)
        {
            if (id != atualizacao_Campanha.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atualizacao_Campanha);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Atualizacao_CampanhaExists(atualizacao_Campanha.Id))
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
            ViewData["CampanhaId"] = new SelectList(_context.Campanha, "Id", "Descricao", atualizacao_Campanha.CampanhaId);
            return View(atualizacao_Campanha);
        }

        // GET: Atualizacao_Campanha/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Atualizacao_Campanha == null)
            {
                return NotFound();
            }

            var atualizacao_Campanha = await _context.Atualizacao_Campanha
                .Include(a => a.Campanha)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atualizacao_Campanha == null)
            {
                return NotFound();
            }

            return View(atualizacao_Campanha);
        }

        // POST: Atualizacao_Campanha/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Atualizacao_Campanha == null)
            {
                return Problem("Entity set 'Arrecadar3Context.Atualizacao_Campanha'  is null.");
            }
            var atualizacao_Campanha = await _context.Atualizacao_Campanha.FindAsync(id);
            if (atualizacao_Campanha != null)
            {
                _context.Atualizacao_Campanha.Remove(atualizacao_Campanha);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Atualizacao_CampanhaExists(int id)
        {
          return (_context.Atualizacao_Campanha?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
