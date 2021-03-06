﻿using System;
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
            List<StudentCourse> studentCourses = _context.StudentCourse.Where(s => s.StudentId == studentCourse.StudentId).ToList();

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
                else if (courseCount < 3 && scourse.CourseId != studentCourse.CourseId)
                {
                    _context.StudentCourse.Add(studentCourse);

                    _context.SaveChanges();
                }
            }
            
            ViewBag.StudentId = new SelectList(_context.Student, "StudentId", "FirstName", studentCourse.StudentId);

            ViewBag.CourseId = new SelectList(_context.Course, "CourseId", "CourseName", studentCourse.CourseId);

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
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }
        
    }
}
