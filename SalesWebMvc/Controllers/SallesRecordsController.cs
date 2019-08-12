using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class SallesRecordsController : Controller
    {
        private readonly SalesWebMvcContext _context;

        public SallesRecordsController(SalesWebMvcContext context)
        {
            _context = context;
        }

        // GET: SallesRecords
        public async Task<IActionResult> Index()
        {
            return View(await _context.SallesRecord.ToListAsync());
        }

        // GET: SallesRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sallesRecord = await _context.SallesRecord
                .FirstOrDefaultAsync(m => m.id == id);
            if (sallesRecord == null)
            {
                return NotFound();
            }

            return View(sallesRecord);
        }

        // GET: SallesRecords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SallesRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Date,Amount,Status")] SallesRecord sallesRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sallesRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sallesRecord);
        }

        // GET: SallesRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sallesRecord = await _context.SallesRecord.FindAsync(id);
            if (sallesRecord == null)
            {
                return NotFound();
            }
            return View(sallesRecord);
        }

        // POST: SallesRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Date,Amount,Status")] SallesRecord sallesRecord)
        {
            if (id != sallesRecord.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sallesRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SallesRecordExists(sallesRecord.id))
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
            return View(sallesRecord);
        }

        // GET: SallesRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sallesRecord = await _context.SallesRecord
                .FirstOrDefaultAsync(m => m.id == id);
            if (sallesRecord == null)
            {
                return NotFound();
            }

            return View(sallesRecord);
        }

        // POST: SallesRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sallesRecord = await _context.SallesRecord.FindAsync(id);
            _context.SallesRecord.Remove(sallesRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SallesRecordExists(int id)
        {
            return _context.SallesRecord.Any(e => e.id == id);
        }
    }
}
