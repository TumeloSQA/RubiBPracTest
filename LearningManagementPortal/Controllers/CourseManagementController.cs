using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningManagementPortal.Models;
using LearningManagementPortal.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementPortal.Controllers
{
    public class CourseManagementController : Controller
    {
        private readonly ICourseManagementRepository _repository;
        private readonly TestDB_MaremaneTPContext _context;
        public CourseManagementController(TestDB_MaremaneTPContext context,ICourseManagementRepository repository)
        {
            _context = context;
            _repository = repository;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CourseName,StartDate,EndDate")] Course course)
        {
            if (DateTime.Parse(course.StartDate) < DateTime.Parse(course.EndDate))
            {
                if (ModelState.IsValid)
                {
                    _context.Add(course);
                    _context.SaveChangesAsync();
                    return RedirectToAction("Index", "StudentManagement");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Course start date should not be after the course end date.");
                    return View();
                }
            }
                    return View(course);
        }
    }
}