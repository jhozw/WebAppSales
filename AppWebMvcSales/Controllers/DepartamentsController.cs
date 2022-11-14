using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppWebMvcSales.Data;
using AppWebMvcSales.Models;
using AppWebMvcSales.Models.ViewModels;
using AppWebMvcSales.Services;

namespace AppWebMvcSales.Controllers
{
    public class DepartamentsController : Controller
    {
        private readonly DepartamentService _departamentService;
        public DepartamentsController(DepartamentService departamentService)        {
            _departamentService = departamentService;
        }
        public IActionResult Index()
        {
            var departaments = _departamentService.FindAll();
            return View(departaments);

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Departament departament)
        {
            bool success = _departamentService.Incert(departament);
            if (success)
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound("ERROR: Create not possible!");
        }
        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                return BadRequest("ERROR: Delete not possible!");
            }
            var departament = _departamentService.FindById(id.Value);
            if (departament is null)
            {
                return NotFound();
            }

            return View(departament);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            bool success = _departamentService.RemoveItem(id);
            if (success)
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound("ERROR: Create not possible!");
        }
        public IActionResult Details(int id)
        {
            var departament = _departamentService.FindById(id);
            return View(departament);
        }

        /*private readonly AppWebMvcSalesContext _context;

        public DepartamentsController(AppWebMvcSalesContext context)
        {
            _context = context;
        }

        // GET: Departaments
        public async Task<IActionResult> Index()
        {
              return View(await _context.Departament.ToListAsync());
        }

        // GET: Departaments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Departament == null)
            {
                return NotFound();
            }

            var departament = await _context.Departament
                .FirstOrDefaultAsync(m => m.id == id);
            if (departament == null)
            {
                return NotFound();
            }

            return View(departament);
        }

        // GET: Departaments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departaments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name")] Departament departament)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departament);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departament);
        }

        // GET: Departaments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Departament == null)
            {
                return NotFound();
            }

            var departament = await _context.Departament.FindAsync(id);
            if (departament == null)
            {
                return NotFound();
            }
            return View(departament);
        }

        // POST: Departaments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name")] Departament departament)
        {
            if (id != departament.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departament);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamentExists(departament.id))
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
            return View(departament);
        }

        // GET: Departaments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Departament == null)
            {
                return NotFound();
            }

            var departament = await _context.Departament
                .FirstOrDefaultAsync(m => m.id == id);
            if (departament == null)
            {
                return NotFound();
            }

            return View(departament);
        }

        // POST: Departaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Departament == null)
            {
                return Problem("Entity set 'AppWebMvcSalesContext.Departament'  is null.");
            }
            var departament = await _context.Departament.FindAsync(id);
            if (departament != null)
            {
                _context.Departament.Remove(departament);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartamentExists(int id)
        {
          return _context.Departament.Any(e => e.id == id);
        }*/
    }
}
