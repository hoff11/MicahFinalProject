using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MicahHoffmannFinal_PerSpec.Controllers
{
    public class AccountController : Controller
    {
        private DataProcessor.StudentProcessor studentProcessor;
        private string sqlConnection;

        public AccountController()
        {
            studentProcessor = new DataProcessor.StudentProcessor();
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
    }
}