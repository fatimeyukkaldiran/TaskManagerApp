using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Models;

namespace TaskManagerApp.Controllers
{
    public class EmployeeRegistersController : Controller
    {
        private readonly TaskManagerDbContext _context;

        public EmployeeRegistersController(TaskManagerDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeRegisters
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeeRegisters.ToListAsync());
        }

        // GET: EmployeeRegisters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelEmployeeRegister = await _context.EmployeeRegisters
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (modelEmployeeRegister == null)
            {
                return NotFound();
            }

            return View(modelEmployeeRegister);
        }

        // GET: EmployeeRegisters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeRegisters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,FirstName,LastName,Email,MobilePhone,UserName,Password")] ModelEmployeeRegister modelEmployeeRegister)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modelEmployeeRegister);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modelEmployeeRegister);
        }

        // GET: EmployeeRegisters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelEmployeeRegister = await _context.EmployeeRegisters.FindAsync(id);
            if (modelEmployeeRegister == null)
            {
                return NotFound();
            }
            return View(modelEmployeeRegister);
        }

        // POST: EmployeeRegisters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,FirstName,LastName,Email,MobilePhone,UserName,Password")] ModelEmployeeRegister modelEmployeeRegister)
        {
            if (id != modelEmployeeRegister.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelEmployeeRegister);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelEmployeeRegisterExists(modelEmployeeRegister.EmployeeId))
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
            return View(modelEmployeeRegister);
        }

        // GET: EmployeeRegisters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelEmployeeRegister = await _context.EmployeeRegisters
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (modelEmployeeRegister == null)
            {
                return NotFound();
            }

            return View(modelEmployeeRegister);
        }

        // POST: EmployeeRegisters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modelEmployeeRegister = await _context.EmployeeRegisters.FindAsync(id);
            _context.EmployeeRegisters.Remove(modelEmployeeRegister);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModelEmployeeRegisterExists(int id)
        {
            return _context.EmployeeRegisters.Any(e => e.EmployeeId == id);
        }
    }
}
