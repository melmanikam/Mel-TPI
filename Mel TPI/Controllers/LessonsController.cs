using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mel_TPI.Data;
using Mel_TPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace Mel_TPI.Controllers
{
    public class LessonsController : Controller
    {
        private readonly Mel_TPIContext _context;

        public LessonsController(Mel_TPIContext context)
        {
            _context = context;
        }

        // GET: Lessons
        public async Task<IActionResult> Index(string SearchString)
        {
            var lessons = from n in _context.Lesson.Include(l => l.Student).Include(l => l.Teacher)
                          select n;
            if (!String.IsNullOrEmpty(SearchString))
            {
                lessons = lessons.Where(ss => ss.Student.FirstName!.Contains(SearchString) || ss.Teacher.FirstName!.Contains(SearchString));
                return View(await lessons.ToListAsync());
            }
            else
            {
                var mel_TPIContext = _context.Lesson.Include(l => l.Student).Include(l => l.Teacher);
                return View(await mel_TPIContext.ToListAsync());
            }

        }

        // GET: Lessons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lesson == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lesson
                .Include(l => l.Student)
                .Include(l => l.Teacher)
                .FirstOrDefaultAsync(m => m.LessonID == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // GET: Lessons/Create
        public IActionResult Create()
        {
            ViewData["StudentID"] = new SelectList(_context.Set<Student>(), "StudentID", "FirstName");
            ViewData["TeacherID"] = new SelectList(_context.Set<Teacher>(), "TeacherID", "FirstName");
            return View();
        }

        // POST: Lessons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LessonID,TeacherID,StudentID,Date,Level,Type")] Lesson lesson)
        {
            if(lesson.Date <= DateTime.Now)
            {
                ModelState.AddModelError("","Lessons cannot be placed in the past.");
                return View(lesson);
            }
            if (!ModelState.IsValid)
            {
                _context.Add(lesson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentID"] = new SelectList(_context.Set<Student>(), "StudentID", "FirstName", lesson.StudentID);
            ViewData["TeacherID"] = new SelectList(_context.Set<Teacher>(), "TeacherID", "FirstName", lesson.TeacherID);
            return View(lesson);
        }

        // GET: Lessons/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lesson == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lesson.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }
            ViewData["StudentID"] = new SelectList(_context.Set<Student>(), "StudentID", "FirstName", lesson.StudentID);
            ViewData["TeacherID"] = new SelectList(_context.Set<Teacher>(), "TeacherID", "FirstName", lesson.TeacherID);
            return View(lesson);
        }

        // POST: Lessons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LessonID,TeacherID,StudentID,Date,Level,Type")] Lesson lesson)
        {
            if (id != lesson.LessonID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(lesson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LessonExists(lesson.LessonID))
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
            ViewData["StudentID"] = new SelectList(_context.Set<Student>(), "StudentID", "FirstName", lesson.StudentID);
            ViewData["TeacherID"] = new SelectList(_context.Set<Teacher>(), "TeacherID", "FirstName", lesson.TeacherID);
            return View(lesson);
        }

        // GET: Lessons/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lesson == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lesson
                .Include(l => l.Student)
                .Include(l => l.Teacher)
                .FirstOrDefaultAsync(m => m.LessonID == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // POST: Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lesson == null)
            {
                return Problem("Entity set 'Mel_TPIContext.Lesson'  is null.");
            }
            var lesson = await _context.Lesson.FindAsync(id);
            if (lesson != null)
            {
                _context.Lesson.Remove(lesson);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LessonExists(int id)
        {
            return (_context.Lesson?.Any(e => e.LessonID == id)).GetValueOrDefault();
        }
    }
}
