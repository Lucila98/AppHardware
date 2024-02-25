using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppHardware.Models;
using AppHardware.Context;
using System.Collections;
using AppHardware.Migrations;

namespace AppHardware.Controllers
{
    public class RegistroController : Controller
    {
        private readonly HardwareDatabaseContext _context;

        public RegistroController(HardwareDatabaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var hardwareDatabaseContext = _context.Registros.Include(r => r.Producto).Include(r => r.Usuario);
            return View(await hardwareDatabaseContext.ToListAsync());
        }

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

        public IActionResult Create()
        {
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "NombreCompleto");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "NombreCompleto");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegistroId,UsuarioId,ProductoId,FechaEntrega,FechaDevolucion, Cantidad")] Registro registro)
        {
            if (registro.UsuarioId == -1)
            {
                ModelState.AddModelError("UsuarioId", "Seleccione un usuario válido.");
                
            } else if (registro.ProductoId == -1)
            {
                ModelState.AddModelError("ProductoId", "Seleccione un producto válido.");
            }
            else
            {
                var stock = await _context.Stock.FindAsync(registro.ProductoId);      
                    if (stock == null || registro.Cantidad <= 0 || registro.Cantidad > stock.Cantidad)
                {
                    ModelState.AddModelError("Cantidad", "La cantidad no es válida o no hay suficiente stock.");
                }
            }
            if (!ModelState.IsValid && _context.Usuarios.Any(u => u.UsuarioId == registro.UsuarioId) && _context.Productos.Any(p => p.ProductoId == registro.ProductoId))
            {
                registro.FechaDevolucion = null;
                var stock = await _context.Stock.FindAsync(registro.ProductoId);
                if (stock.Cantidad >= registro.Cantidad)
                {
                    stock.Cantidad -= registro.Cantidad;
                    _context.Add(registro);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                
            }
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "NombreCompleto", registro.ProductoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "NombreCompleto", registro.UsuarioId);

            
            return View(registro);
        
    }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegistroId,UsuarioId,ProductoId,FechaEntrega,FechaDevolucion, Cantidad")] Registro registro)
        {
            if (id != registro.RegistroId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)

            {
                if (registro.FechaDevolucion > registro.FechaEntrega)
                {
                    try
                    {
                        var cantidadOriginal = Convert.ToInt32(Request.Form["Cantidad"]);
                        var stock = await _context.Stock.FindAsync(registro.ProductoId);
                        stock.Cantidad += cantidadOriginal;

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
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));

                }

            }
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "NombreCompleto", registro.ProductoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "NombreCompleto", registro.UsuarioId);
            return View(registro);
        }

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
