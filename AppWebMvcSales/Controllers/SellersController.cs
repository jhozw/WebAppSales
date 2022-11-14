using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppWebMvcSales.Services;
using AppWebMvcSales.Data;
using AppWebMvcSales.Models;
using AppWebMvcSales.Models.ViewModels;

namespace AppWebMvcSales.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartamentService _departamentService;
        public SellersController(SellerService sellerService, DepartamentService departamentService)
        {
            _sellerService = sellerService;
            _departamentService = departamentService;
        }

        public IActionResult Index()
        {
            return View(_sellerService.FindAllSellres());
        }

        public IActionResult Create()
        {
            var departaments = _departamentService.FindAll();
            return View(new SellerFormViewMdels { Departaments = departaments });
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
        //public IActionResult Delete()
        //{
        //    return View();
        //}
        public IActionResult Details(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            var obj = _sellerService.FindById(id.Value);
            if (obj is null)
            {
                return NotFound();
            }
            var departament = _departamentService.FindById(obj.DepartamentId);
            if (departament is not null)
            {
                obj.Departament = departament;
            }
            else
            {
                return NotFound("Departamento não encontrado!");
            }

            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            var obj = _sellerService.FindById(id.Value);
            if (obj is null)
            {
                return NotFound();
            }

            var departament = _departamentService.FindById(obj.DepartamentId);
            if (departament is not null)
            {
                obj.Departament = departament;
            }
            else
            {
                return NotFound("Departamento não encontrado!");
            }

            return View(obj);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }


        //private readonly AppWebMvcSalesContext _context;

        //public SellersController(AppWebMvcSalesContext context)
        //{
        //    _context = context;
        //}



        // GET: Sellers
        //public async Task<IActionResult> Index()
        //{
        //    //var appWebMvcSalesContext = _context.Seller.Include(s => s.Departament);
        //    //return View(await appWebMvcSalesContext.ToListAsync());

        //}


        //// GET: Sellers/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Seller == null)
        //    {
        //        return NotFound();
        //    }

        //    var seller = await _context.Seller
        //        .Include(s => s.Departament)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (seller == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(seller);
        //}

        //// GET: Sellers/Create
        //public IActionResult Create()
        //{
        //    ViewData["DepartamentId"] = new SelectList(_context.Departament, "id", "id");
        //    return View();
        //}

        //// POST: Sellers/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Nome,Email,BirthDate,BaseSalary,DepartamentId")] Seller seller)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(seller);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["DepartamentId"] = new SelectList(_context.Departament, "id", "id", seller.DepartamentId);
        //    return View(seller);
        //}

        //// GET: Sellers/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Seller == null)
        //    {
        //        return NotFound();
        //    }

        //    var seller = await _context.Seller.FindAsync(id);
        //    if (seller == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["DepartamentId"] = new SelectList(_context.Departament, "id", "id", seller.DepartamentId);
        //    return View(seller);
        //}

        //// POST: Sellers/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,BirthDate,BaseSalary,DepartamentId")] Seller seller)
        //{
        //    if (id != seller.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(seller);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!SellerExists(seller.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["DepartamentId"] = new SelectList(_context.Departament, "id", "id", seller.DepartamentId);
        //    return View(seller);
        //}

        //// GET: Sellers/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Seller == null)
        //    {
        //        return NotFound();
        //    }

        //    var seller = await _context.Seller
        //        .Include(s => s.Departament)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (seller == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(seller);
        //}

        //// POST: Sellers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Seller == null)
        //    {
        //        return Problem("Entity set 'AppWebMvcSalesContext.Seller'  is null.");
        //    }
        //    var seller = await _context.Seller.FindAsync(id);
        //    if (seller != null)
        //    {
        //        _context.Seller.Remove(seller);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool SellerExists(int id)
        //{
        //  return _context.Seller.Any(e => e.Id == id);
        //}
    }
}
