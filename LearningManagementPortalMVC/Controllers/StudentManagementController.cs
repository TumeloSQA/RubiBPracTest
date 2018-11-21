using DAL.Models;
using ServiceModules.ServiceModules;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningManagementPortalMVC.Controllers
{
    public class StudentManagementController : Controller
    {
        private readonly IStudentManagementRepository _repository;
        private PortalDbContext _dbContext;
        public StudentManagementController(IStudentManagementRepository repository, PortalDbContext dbContext)
        {
            this._repository = repository;
            this._dbContext = dbContext;
        }
       
        // GET: StudentManagement
        public ActionResult Index()
        {
            DataSet ds = _repository.GetStudents();

            Session["studentCount"] = ds.Tables[0].Columns.Count;
            
            ViewBag.studentID = ds;
            
            return View(ds);
        }

        public ActionResult Enroll()
        {
            SqlConnection _con = new SqlConnection("Data Source=.;Initial Catalog=TestDB_Tumelo;Integrated Security=True");

            SqlDataAdapter _da = new SqlDataAdapter("SELECT * from Student", _con);

            SqlDataAdapter _daCourse = new SqlDataAdapter("select * from course", _con);

            DataTable _dt = new DataTable();

            DataTable _dtCourse = new DataTable();

            _da.Fill(_dt);

            _daCourse.Fill(_dt);

            ViewBag.StudentName = ToSelectList(_dt, "StudentId", "FirstName");

            ViewBag.CourseName = ToSelectList(_dt, "CourseId", "CourseName");

            return View();
        }

        [HttpPost]
        public ActionResult Enroll(StudentCourseDto studentCourseDto)
        {
            return View();
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

        [NonAction]
        public SelectList ToSelectList(DataTable table, string valueField, string textField)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(new SelectListItem()
                {
                    Text = row[textField].ToString(),
                    Value = row[valueField].ToString()
                });
            }

            return new SelectList(list, "Value", "Text");
        }
    }
}