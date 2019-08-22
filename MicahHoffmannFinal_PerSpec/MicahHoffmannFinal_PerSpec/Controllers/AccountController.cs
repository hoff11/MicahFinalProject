using DataProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MicahHoffmannFinal_PerSpec.Controllers
{
    public class AccountController : Controller
    {
        private StudentProcessor studentProcessor;
        private string sqlConnection;
        private ClassProcessor classProcessor;

        public AccountController()
        {
            studentProcessor = new StudentProcessor();
            classProcessor = new ClassProcessor();
            sqlConnection = System.Configuration.ConfigurationManager.ConnectionStrings["LocalPC"].ConnectionString;
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RequestAccount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RequestAccount(FormCollection collection)
        {
            ViewData["Error"] = "";
            try
            {
                studentProcessor.Insert(sqlConnection
                    , int.Parse(collection["StudentID"])
                    , collection["StudentName"]
                    , collection["StudentEmail"]
                    , collection["StudentLogin"]
                    , collection["StudentPassword"]);
                return RedirectToAction("Index", "Home", "Index");
            } catch(Exception e)
            {
                ViewData["error"] = e.Message;
                return View();
            }
        }
        private List<Models.Student> SelectAllStudents()
        {
            //You can return an object for View data using a class in the DLL,
            List<Student> lstRows = studentProcessor.Select(sqlConnection);

            //BUT you can also create an MVC data model, which decouples the requierment of a DLL (could switch to a XML or JSON file later!)
            Models.Student objStudent;
            List<Models.Student> lstStudents = new List<Models.Student>();
            foreach (var row in lstRows)
            {
                objStudent = new Models.Student(row.StudentID, row.StudentName, row.StudentEmail, row.StudentLogin, row.StudentPassword);
                lstStudents.Add(objStudent);
            }
            return lstStudents;
        }

        private Models.Student SelectOneStudents(int id)
        {
            var objOneStudent = new object();
            foreach (var item in SelectAllStudents())
            {
                if (item.StudentID == id) objOneStudent = item;
            }
            return (Models.Student)objOneStudent;
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            ViewData["Error"] = "";
            try
            {
                var studentId = studentProcessor.Login(sqlConnection
                    , collection["StudentLogin"]
                    , collection["StudentPassword"]);

                return RedirectToAction("Details", new { id = studentId});
            }
            catch (Exception e)
            {
                ViewData["error"] = e.Message;
                return View();
            }
        }
        

        public ActionResult Details(int id)
        {
            ViewData["Error"] = "";
            try
            {
                var student = SelectOneStudents(id);
                return View(student);
            }
            catch (Exception e)
            {
                ViewData["error"] = e.Message;
                return View();
            }

        }
        private List<Models.Classes> SelectAllClasses()
        {
            //You can return an object for View data using a class in the DLL,
            List<Class> dataClasses = classProcessor.Select(sqlConnection);

            //BUT you can also create an MVC data model, which decouples the requierment of a DLL (could switch to a XML or JSON file later!)
            Models.Classes objClasses;
            List<Models.Classes> classes = new List<Models.Classes>();
            foreach (var row in dataClasses)
            {
                objClasses = new Models.Classes(row.ClassId, row.ClassName, row.ClassDate, row.ClassDescription);
                classes.Add(objClasses);
            }
            return classes;
        }
        private Models.Classes SelectOneClass(int id)
        {
            var objOneClass = new object();
            foreach (var item in SelectAllClasses())
            {
                if (item.ClassId == id) objOneClass = item;
            }
            return (Models.Classes)objOneClass;
        }
        

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(int id, FormCollection collection)
        {
            ViewData["Error"] = "";
            try
            {
                classProcessor.Insert(sqlConnection
                    , int.Parse(collection["ClassId"])
                    , id);
                return RedirectToAction("MyClasses", "Account", new { id = id});
            }
            catch (Exception e)
            {
                ViewData["error"] = e.Message;
                return View();
            }
        }

    }
}