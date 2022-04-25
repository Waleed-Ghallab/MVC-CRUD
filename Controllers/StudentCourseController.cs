using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC4.Data;
using MVC4.Models;

namespace MVC4.Controllers
{
    public class StudentCourseController : Controller
    {
        private readonly MyDBContext _context;

        public StudentCourseController(MyDBContext context)
        {
            _context = context;
        }

        // GET: StudentCourse
        public async Task<IActionResult> Index()
        {
            var myDBContext = _context.StudentCourse.Include(s => s.Course).Include(s => s.Student);
            return View(await myDBContext.ToListAsync());
        }

        // GET: StudentCourse/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCourse = await _context.StudentCourse
                .Include(s => s.Course)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Std_id == id);
            if (studentCourse == null)
            {
                return NotFound();
            }

            return View(studentCourse);
        }

        // GET: StudentCourse/Create
        public IActionResult Create()
        {
            ViewData["Crs_id"] = new SelectList(_context.Courses, "Id", "Id");
            ViewData["Std_id"] = new SelectList(_context.Students, "Id", "Id");
            return View();
        }

        // POST: StudentCourse/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Std_id,Crs_id,grade")] StudentCourse studentCourse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentCourse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Crs_id"] = new SelectList(_context.Courses, "Id", "Id", studentCourse.Crs_id);
            ViewData["Std_id"] = new SelectList(_context.Students, "Id", "Id", studentCourse.Std_id);
            return View(studentCourse);
        }

        // GET: StudentCourse/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCourse = await _context.StudentCourse.FindAsync(id);
            if (studentCourse == null)
            {
                return NotFound();
            }
            ViewData["Crs_id"] = new SelectList(_context.Courses, "Id", "Id", studentCourse.Crs_id);
            ViewData["Std_id"] = new SelectList(_context.Students, "Id", "Id", studentCourse.Std_id);
            return View(studentCourse);
        }

        // POST: StudentCourse/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Std_id,Crs_id,grade")] StudentCourse studentCourse)
        {
            if (id != studentCourse.Std_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentCourse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentCourseExists(studentCourse.Std_id))
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
            ViewData["Crs_id"] = new SelectList(_context.Courses, "Id", "Id", studentCourse.Crs_id);
            ViewData["Std_id"] = new SelectList(_context.Students, "Id", "Id", studentCourse.Std_id);
            return View(studentCourse);
        }

        // GET: StudentCourse/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCourse = await _context.StudentCourse
                .Include(s => s.Course)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Std_id == id);
            if (studentCourse == null)
            {
                return NotFound();
            }

            return View(studentCourse);
        }

        // POST: StudentCourse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentCourse = await _context.StudentCourse.FindAsync(id);
            _context.StudentCourse.Remove(studentCourse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentCourseExists(int id)
        {
            return _context.StudentCourse.Any(e => e.Std_id == id);
        }
    }
}
