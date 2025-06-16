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
    public class CampanhasController : Controller
    {
        private readonly Arrecadar3Context _context;

        public CampanhasController(Arrecadar3Context context)
        {
            _context = context;
        }

        // GET: Campanhas
        public async Task<IActionResult> Index()
        {
            var arrecadar3Context = _context.Campanha.Include(c => c.Ongs);
            return View(await arrecadar3Context.ToListAsync());
        }

        // GET: Campanhas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Campanha == null)
            {
                return NotFound();
            }

            var campanha = await _context.Campanha
                .Include(c => c.Ongs)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campanha == null)
            {
                return NotFound();
            }

            return View(campanha);
        }

        // GET: Campanhas/Create
        public IActionResult Create()
        {
            ViewData["OngId"] = new SelectList(_context.Ong, "Id", "Area_Atuacao");
            return View();
        }

        // POST: Campanhas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,OngId,Descricao,Meta_Arrecadacao,Valor_Arrecadado,Data_Inicio,Imagem_Url")] Campanha campanha)
        {
            if (ModelState.IsValid)
            {
                _context.Add(campanha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OngId"] = new SelectList(_context.Ong, "Id", "Area_Atuacao", campanha.OngId);
            return View(campanha);
        }

        // GET: Campanhas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Campanha == null)
            {
                return NotFound();
            }

            var campanha = await _context.Campanha.FindAsync(id);
            if (campanha == null)
            {
                return NotFound();
            }
            ViewData["OngId"] = new SelectList(_context.Ong, "Id", "Area_Atuacao", campanha.OngId);
            return View(campanha);
        }

        // POST: Campanhas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,OngId,Descricao,Meta_Arrecadacao,Valor_Arrecadado,Data_Inicio,Imagem_Url")] Campanha campanha)
        {
            if (id != campanha.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(campanha);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampanhaExists(campanha.Id))
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
            ViewData["OngId"] = new SelectList(_context.Ong, "Id", "Area_Atuacao", campanha.OngId);
            return View(campanha);
        }

        // GET: Campanhas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Campanha == null)
            {
                return NotFound();
            }

            var campanha = await _context.Campanha
                .Include(c => c.Ongs)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campanha == null)
            {
                return NotFound();
            }

            return View(campanha);
        }

        // POST: Campanhas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Campanha == null)
            {
                return Problem("Entity set 'Arrecadar3Context.Campanha'  is null.");
            }
            var campanha = await _context.Campanha.FindAsync(id);
            if (campanha != null)
            {
                _context.Campanha.Remove(campanha);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampanhaExists(int id)
        {
          return (_context.Campanha?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
