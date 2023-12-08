using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppHardware.Models;
using AppHardware.Context;

namespace AppHardware.Controllers
{
    public class RegistroController : Controller
    {
        private readonly HardwareDatabaseContext _context;

        public RegistroController(HardwareDatabaseContext context)
        {
            _context = context;
        }

        // GET: Registro
        public async Task<IActionResult> Index()
        {
            var hardwareDatabaseContext = _context.Registros.Include(r => r.Producto).Include(r => r.Usuario);
            return View(await hardwareDatabaseContext.ToListAsync());
        }

        //public async Task<IActionResult> Index(string searchString)
        //{
        //    if (_context.Registros == null)
        //    {
        //        return Problem("No hay registros.");
        //    }

        //    var registro = from r in _context.Registros
        //                   select r;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        registro = registro.Where(s => s.Usuario.NombreCompleto!.Contains(searchString));
        //    }

        //    return View(await registro.ToListAsync());
        //}

        // GET: Registro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registro = await _context.Registros
                .Include(r => r.Producto)
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.RegistroId == id);
            if (registro == null)
            {
                return NotFound();
            }

            return View(registro);
        }

        // GET: Registro/Create
        public IActionResult Create()
        {
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "NombreCompleto");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "NombreCompleto");
            return View();
        }

        // POST: Registro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegistroId,UsuarioId,ProductoId,FechaEntrega,FechaDevolucion")] Registro registro)
        {
            if (!ModelState.IsValid)
            {
                if (registro.FechaEntrega <= DateTime.Now)
                {
                    _context.Add(registro);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
            }
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "NombreCompleto", registro.ProductoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "NombreCompleto", registro.UsuarioId);
            return View(registro);
        }

        // GET: Registro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registro = await _context.Registros.FindAsync(id);
            if (registro == null)
            {
                return NotFound();
            }
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "NombreCompleto", registro.ProductoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "NombreCompleto", registro.UsuarioId);
            return View(registro);
        }

        // POST: Registro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegistroId,UsuarioId,ProductoId,FechaEntrega,FechaDevolucion")] Registro registro)
        {
            if (id != registro.RegistroId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                if (registro.FechaDevolucion >= registro.FechaEntrega)
                {
                    try
                    {
                        _context.Update(registro);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!RegistroExists(registro.RegistroId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            //MOSTRAR EXCEPCION FECHA INVALIDA
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    //mostrar mensaje fecha inválida
                }
            }
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "NombreCompleto", registro.ProductoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "NombreCompleto", registro.UsuarioId);
            return View(registro);
        }

        // GET: Registro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registro = await _context.Registros
                .Include(r => r.Producto)
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.RegistroId == id);
            if (registro == null)
            {
                return NotFound();
            }

            return View(registro);
        }

        // POST: Registro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registro = await _context.Registros.FindAsync(id);
            _context.Registros.Remove(registro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroExists(int id)
        {
            return _context.Registros.Any(e => e.RegistroId == id);
        }
    }
}
