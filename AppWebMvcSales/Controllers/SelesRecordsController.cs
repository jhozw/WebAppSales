using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppWebMvcSales.Data;
using AppWebMvcSales.Models;

namespace AppWebMvcSales.Controllers
{
    public class SelesRecordsController : Controller
    {
        private readonly AppWebMvcSalesContext _context;

        public SelesRecordsController(AppWebMvcSalesContext context)
        {
            _context = context;
        }

        // GET: SelesRecords
        public async Task<IActionResult> Index()
        {
            var appWebMvcSalesContext = _context.SellersRecord.Include(s => s.Seller);
            return View(await appWebMvcSalesContext.ToListAsync());
        }

        // GET: SelesRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SellersRecord == null)
            {
                return NotFound();
            }

            var selesRecord = await _context.SellersRecord
                .Include(s => s.Seller)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (selesRecord == null)
            {
                return NotFound();
            }

            return View(selesRecord);
        }

        // GET: SelesRecords/Create
        public IActionResult Create()
        {
            ViewData["SellerId"] = new SelectList(_context.Seller, "Id", "Id");
            return View();
        }

        // POST: SelesRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Amount,Status,SellerId")] SelesRecord selesRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(selesRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SellerId"] = new SelectList(_context.Seller, "Id", "Id", selesRecord.SellerId);
            return View(selesRecord);
        }

        // GET: SelesRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SellersRecord == null)
            {
                return NotFound();
            }

            var selesRecord = await _context.SellersRecord.FindAsync(id);
            if (selesRecord == null)
            {
                return NotFound();
            }
            ViewData["SellerId"] = new SelectList(_context.Seller, "Id", "Id", selesRecord.SellerId);
            return View(selesRecord);
        }

        // POST: SelesRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Amount,Status,SellerId")] SelesRecord selesRecord)
        {
            if (id != selesRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(selesRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SelesRecordExists(selesRecord.Id))
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
            ViewData["SellerId"] = new SelectList(_context.Seller, "Id", "Id", selesRecord.SellerId);
            return View(selesRecord);
        }

        // GET: SelesRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SellersRecord == null)
            {
                return NotFound();
            }

            var selesRecord = await _context.SellersRecord
                .Include(s => s.Seller)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (selesRecord == null)
            {
                return NotFound();
            }

            return View(selesRecord);
        }

        // POST: SelesRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SellersRecord == null)
            {
                return Problem("Entity set 'AppWebMvcSalesContext.SellersRecord'  is null.");
            }
            var selesRecord = await _context.SellersRecord.FindAsync(id);
            if (selesRecord != null)
            {
                _context.SellersRecord.Remove(selesRecord);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SelesRecordExists(int id)
        {
          return _context.SellersRecord.Any(e => e.Id == id);
        }
    }
}
