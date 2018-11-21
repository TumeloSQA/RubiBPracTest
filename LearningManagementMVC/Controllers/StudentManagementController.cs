using ServiceModules.ServiceModules;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DAL.Controllers
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

            return View(ds);
        }
    }
}