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
    public class StudentManagementController : Controller
    {
        private readonly IStudentManagementRepository _repository;
        public StudentManagementController(IStudentManagementRepository repository)
        {
            this._repository = repository;
        }

        // GET: StudentManagement
        public ActionResult Index()
        {
            
            DataSet ds = _repository.GetStudents();

            Session["studentCount"] = ds.Tables[0].Columns.Count;

            return View(ds);
        }

        // GET: StudentManagement
        public ActionResult Details(int studentID)
        {
            DataSet ds = _repository.StudentDetails(studentID);

            return View(ds);
        }

        public ActionResult Create()
        {
                return View();
        }
            
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _repository.InsertStudents(student);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, contact your system administrator.");
            }

            return RedirectToAction("Index");

        }
    }
}