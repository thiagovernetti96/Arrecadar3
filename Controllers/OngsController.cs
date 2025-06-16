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
    public class OngsController : Controller
    {
        private readonly Arrecadar3Context _context;

        public OngsController(Arrecadar3Context context)
        {
            _context = context;
        }

        // GET: Ongs
        public async Task<IActionResult> Index()
        {
            var arrecadar3Context = _context.Ong.Include(o => o.User);
            return View(await arrecadar3Context.ToListAsync());
        }

        // GET: Ongs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ong == null)
            {
                return NotFound();
            }

            var ong = await _context.Ong
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ong == null)
            {
                return NotFound();
            }

            return View(ong);
        }

        // GET: Ongs/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Ongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,UserId,Cnpj,Telefone,Area_Atuacao,Descricao,Foto_Perfil_Url")] Ong ong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", ong.UserId);
            return View(ong);
        }

        // GET: Ongs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ong == null)
            {
                return NotFound();
            }

            var ong = await _context.Ong.FindAsync(id);
            if (ong == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", ong.UserId);
            return View(ong);
        }

        // POST: Ongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,UserId,Cnpj,Telefone,Area_Atuacao,Descricao,Foto_Perfil_Url")] Ong ong)
        {
            if (id != ong.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OngExists(ong.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", ong.UserId);
            return View(ong);
        }

        // GET: Ongs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ong == null)
            {
                return NotFound();
            }

            var ong = await _context.Ong
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ong == null)
            {
                return NotFound();
            }

            return View(ong);
        }

        // POST: Ongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ong == null)
            {
                return Problem("Entity set 'Arrecadar3Context.Ong'  is null.");
            }
            var ong = await _context.Ong.FindAsync(id);
            if (ong != null)
            {
                _context.Ong.Remove(ong);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OngExists(int id)
        {
          return (_context.Ong?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
