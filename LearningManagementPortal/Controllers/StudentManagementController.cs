using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LearningManagementPortal.Models;
using LearningManagementPortal.Services;
using System.Data;
using Microsoft.AspNetCore.Http;

namespace LearningManagementPortal.Controllers
{
    public class StudentManagementController : Controller
    {
        private readonly IStudentManagementRepository _repository;

        private readonly TestDB_MaremaneTPContext _context;

        public StudentManagementController(TestDB_MaremaneTPContext context, IStudentManagementRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        // GET: StudentManagement
        public IActionResult Index()
        {
            //ViewBag.StudentId = new SelectList(_context.Student, "StudentId", "FirstName");

            //ViewBag.CourseId = new SelectList(_context.Course, "CourseId", "CourseName");

            return View(_repository.GetStudents().ToList());
        }
        public IActionResult Enroll()
        {
            ViewBag.StudentId = new SelectList(_context.Student, "StudentId", "FirstName");

            ViewBag.CourseId = new SelectList(_context.Course, "CourseId", "CourseName");
            
            StudentCourse studentCourse = new StudentCourse();

            return View(studentCourse);
        }

        [HttpPost]
        public IActionResult Enroll(StudentCourse studentCourse)
        {
            var studentCourses = _context.StudentCourse.Where(s => s.StudentId == studentCourse.StudentId).ToList();

            int courseCount = 0;

            foreach (var scourse in studentCourses)
            {
                courseCount++;
                if (courseCount >= 3)
                {
                    ModelState.AddModelError(string.Empty, "Student cannot register for more than 3 Courses.");
                }
                else if (scourse.CourseId == studentCourse.CourseId)
                {
                    ModelState.AddModelError(string.Empty, "Student already enrolled for this course");
                }
                else
                {
                    _context.StudentCourse.Add(studentCourse);

                    _context.SaveChanges();

                    ViewBag.StudentId = new SelectList(_context.Student, "StudentId", "FirstName", studentCourse.StudentId);

                    ViewBag.CourseId = new SelectList(_context.Course, "CourseId", "CourseName", studentCourse.CourseId);
                }
            }
            return View(studentCourse);
        }
        public ActionResult Details(int studentID)
        {
            DataSet ds = _repository.StudentDetails(studentID);

            return View(ds);
        }
        // GET: StudentManagement/Create
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("StudentId,FirstName,Surname,EmailAddress,Idnumber,StudentNumber")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        // GET: StudentManagement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,FirstName,Surname,EmailAddress,Idnumber,StudentNumber")] Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw ex;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: StudentManagement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: StudentManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Student.FindAsync(id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
    }
}
