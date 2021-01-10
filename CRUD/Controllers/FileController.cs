using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD.Data;

namespace CRUD.Controllers
{
    public class FileController : Controller
    {
        private AppDBContext db = new AppDBContext();
        // GET: File
        public ActionResult Index(int Id)
        {
            var fileToRetrieve = db.Files.Find(Id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
            //return View();
        }
    }
}