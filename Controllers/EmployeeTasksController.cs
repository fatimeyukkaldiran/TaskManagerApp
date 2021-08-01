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
    public class EmployeeTasksController : Controller
    {
        private readonly TaskManagerDbContext _context;

        public EmployeeTasksController(TaskManagerDbContext context)
        {
            _context = context;
        }

        // GET: EmloyeeTasks
        public async Task<IActionResult> Index()
        {
            var taskManagerDbContext = _context.EmployeeTasks.Include(m => m.Employee);
            return View(await taskManagerDbContext.ToListAsync());
        }

        // GET: EmloyeeTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelEmloyeeTask = await _context.EmployeeTasks
                .Include(m => m.Employee)
                .FirstOrDefaultAsync(m => m.TaskId == id);
            if (modelEmloyeeTask == null)
            {
                return NotFound();
            }

            return View(modelEmloyeeTask);
        }

        // GET: EmloyeeTasks/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.EmployeeRegisters, "EmployeeId", "EmployeeId");
            return View();
        }

        // POST: EmloyeeTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskId,EmployeeId,Start_Date,End_Date,TaskDetails,Status")] ModelEmployeeTask modelEmloyeeTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modelEmloyeeTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.EmployeeRegisters, "EmployeeId", "EmployeeId", modelEmloyeeTask.EmployeeId);
            return View(modelEmloyeeTask);
        }

        // GET: EmloyeeTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelEmloyeeTask = await _context.EmployeeTasks.FindAsync(id);
            if (modelEmloyeeTask == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.EmployeeRegisters, "EmployeeId", "EmployeeId", modelEmloyeeTask.EmployeeId);
            return View(modelEmloyeeTask);
        }

        // POST: EmloyeeTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskId,EmployeeId,Start_Date,End_Date,TaskDetails,Status")] ModelEmployeeTask modelEmloyeeTask)
        {
            if (id != modelEmloyeeTask.TaskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelEmloyeeTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelEmloyeeTaskExists(modelEmloyeeTask.TaskId))
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
            ViewData["EmployeeId"] = new SelectList(_context.EmployeeRegisters, "EmployeeId", "EmployeeId", modelEmloyeeTask.EmployeeId);
            return View(modelEmloyeeTask);
        }

        // GET: EmloyeeTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelEmloyeeTask = await _context.EmployeeTasks
                .Include(m => m.Employee)
                .FirstOrDefaultAsync(m => m.TaskId == id);
            if (modelEmloyeeTask == null)
            {
                return NotFound();
            }

            return View(modelEmloyeeTask);
        }

        // POST: EmloyeeTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modelEmloyeeTask = await _context.EmployeeTasks.FindAsync(id);
            _context.EmployeeTasks.Remove(modelEmloyeeTask);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModelEmloyeeTaskExists(int id)
        {
            return _context.EmployeeTasks.Any(e => e.TaskId == id);
        }
    }
}
