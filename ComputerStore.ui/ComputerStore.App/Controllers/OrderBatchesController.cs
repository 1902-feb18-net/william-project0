using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComputerStore.Context;

namespace ComputerStore.App.Controllers
{
    public class OrderBatchesController : Controller
    {
        private readonly Project0Context _context;

        public OrderBatchesController(Project0Context context)
        {
            _context = context;
        }

        // GET: OrderBatches
        public async Task<IActionResult> Index()
        {
            var project0Context = _context.OrderBatch.Include(o => o.Customer).Include(o => o.Store);
            return View(await project0Context.ToListAsync());
        }

        // GET: OrderBatches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderBatch = await _context.OrderBatch
                .Include(o => o.Customer)
                .Include(o => o.Store)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderBatch == null)
            {
                return NotFound();
            }

            return View(orderBatch);
        }

        // GET: OrderBatches/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id");
            ViewData["StoreId"] = new SelectList(_context.Store, "Id", "Id");
            return View();
        }

        // POST: OrderBatches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,StoreId,TimePlaced")] OrderBatch orderBatch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderBatch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id", orderBatch.CustomerId);
            ViewData["StoreId"] = new SelectList(_context.Store, "Id", "Id", orderBatch.StoreId);
            return View(orderBatch);
        }

        // GET: OrderBatches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderBatch = await _context.OrderBatch.FindAsync(id);
            if (orderBatch == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id", orderBatch.CustomerId);
            ViewData["StoreId"] = new SelectList(_context.Store, "Id", "Id", orderBatch.StoreId);
            return View(orderBatch);
        }

        // POST: OrderBatches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerId,StoreId,TimePlaced")] OrderBatch orderBatch)
        {
            if (id != orderBatch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderBatch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderBatchExists(orderBatch.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id", orderBatch.CustomerId);
            ViewData["StoreId"] = new SelectList(_context.Store, "Id", "Id", orderBatch.StoreId);
            return View(orderBatch);
        }

        // GET: OrderBatches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderBatch = await _context.OrderBatch
                .Include(o => o.Customer)
                .Include(o => o.Store)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderBatch == null)
            {
                return NotFound();
            }

            return View(orderBatch);
        }

        // POST: OrderBatches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderBatch = await _context.OrderBatch.FindAsync(id);
            _context.OrderBatch.Remove(orderBatch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderBatchExists(int id)
        {
            return _context.OrderBatch.Any(e => e.Id == id);
        }
    }
}
