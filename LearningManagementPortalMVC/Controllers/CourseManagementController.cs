using DAL.Models;
using ServiceModules.ServiceModules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningManagementPortalMVC.Controllers
{
    public class CourseManagementController : Controller
    {
        private readonly ICourseManagementRepository _repository;
        public CourseManagementController(ICourseManagementRepository repository)
        {
            _repository = repository;
        }
        // GET: CourseManagement
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.InsertCourse(course);
                    //return RedirectToAction("Index", "StudentManagement");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, contact your system administrator.");
            }

            return RedirectToAction("Index", "StudentManagement");

        }
    }
}