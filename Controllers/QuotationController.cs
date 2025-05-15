using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuotationSys.Models;
using QuotationSysAuth.Data;

namespace QuotationSysAuth.Controllers;
[Authorize]
public class QuotationController(ApplicationDbContext context) : Controller
{

    public async Task<IActionResult> Index()
    {
        var quotations = await context.Quotations
            .Include(q => q.Customer)
            .Include(q => q.QuotationItems)
                .ThenInclude(qi => qi.Product)
            .ToListAsync();
        return View(quotations);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var quotation = await context.Quotations
            .Include(q => q.Customer)
            .Include(q => q.QuotationItems)
            .ThenInclude(qi => qi.Product)
            .FirstOrDefaultAsync(q => q.QuotationId == id);

        if (quotation == null) return NotFound();

        return View(quotation);
    }

    public IActionResult Create()
    {
        ViewData["CustomerId"] = new SelectList(context.Customers, "CustomerId", "CompanyName");
        ViewData["Products"] = new SelectList(context.Products, "ProductId", "Name");
        ViewBag.ProductList = new SelectList(context.Products, "ProductId", "Name");
        return View();
    }
    
    [HttpPost]
    [AutoValidateAntiforgeryToken]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Quotation quotation)
    {
        if (ModelState.IsValid)
        {
            context.Add(quotation);
            await context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Quotation created successfully!";
            return RedirectToAction(nameof(Index));
        }
        
        ViewBag.ProductList = new SelectList(context.Products, "ProductId", "Name");
        return View(quotation);
    }


    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var quotation = await context.Quotations
            .Include(q => q.QuotationItems)
            .FirstOrDefaultAsync(q => q.QuotationId == id);

        if (quotation == null)
        {
            return NotFound();
        }
        
        ViewData["CustomerId"] = new SelectList(context.Customers, "CustomerId", "CompanyName", quotation.CustomerId);
        ViewData["Products"] = new SelectList(context.Products, "ProductId", "Name");
        return View(quotation);
    }

    public async Task<IActionResult> Edit(int? id, Quotation quotation)
    {
        if (id != quotation.QuotationId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                context.Update(quotation);
                await context.SaveChangesAsync();
                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuotationExists(quotation.QuotationId))
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
        
        ViewData["CustomerId"] = new SelectList(context.Customers, "CustomerId", "CompanyName", quotation.CustomerId);
        ViewData["Products"] = new SelectList(context.Products, "ProductId", "Name");
        return View(quotation);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        
        var quotation = context.Quotations
            .Include(q => q.Customer)
            .FirstOrDefault(q => q.QuotationId == id);

        if (quotation == null)
        {
            return NotFound();
        }
        
        return View(quotation);
    }

    [HttpPost, ActionName("Delete")]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var quotation = await context.Quotations.FindAsync(id);

        if (quotation != null)
        {
            context.Quotations.Remove(quotation);
            await context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    private bool QuotationExists(int id)
    {
        return context.Quotations.Any(e => e.QuotationId == id);
    }
}