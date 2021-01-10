using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUD.Data;
using CRUD.Models;


namespace CRUD.Controllers
{
    public class imgController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: img
        public ActionResult Index()
        {
            return View(db.imgDatas.ToList());
        }

        // GET: img/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            imgData imgData = db.imgDatas.Find(id);
            if (imgData == null)
            {
                return HttpNotFound();
            }
            return View(imgData);
        }

        // GET: img/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: img/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,img")] imgData imgData)
        {
            if (ModelState.IsValid)
            {
                db.imgDatas.Add(imgData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(imgData);
        }

        // GET: img/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            imgData imgData = db.imgDatas.Find(id);
            if (imgData == null)
            {
                return HttpNotFound();
            }
            return View(imgData);
        }

        // POST: img/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,img")] imgData imgData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imgData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(imgData);
        }

        // GET: img/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            imgData imgData = db.imgDatas.Find(id);
            if (imgData == null)
            {
                return HttpNotFound();
            }
            return View(imgData);
        }

        // POST: img/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            imgData imgData = db.imgDatas.Find(id);
            db.imgDatas.Remove(imgData);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //Pruebas
        //public ActionResult FileUpload(HttpPostedFileBase file)
        //{
        //    if (file != null)
        //    {
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            file.InputStream.CopyTo(ms);
        //            byte[] array = ms.GetBuffer();

        //            var context = new Models.imgData();
        //            context.img.Add(new Models.imgData()
        //            {
        //                FotoAF = array,
        //            });
        //            context.SaveChanges();
        //        }

        //    }

        //    return RedirectToAction("actionname", "controller");

        //    public class ImagesController : Controller
        //{
        //    public ActionResult Index(int id)
        //    {
        //        var context = new Models.imgData();
        //        byte[] imageData = context.img.FirstOrDefault(i => i.id == id)?.FotoAF;
        //        if (imageData != null)
        //        {
        //            return File(imageData, "image/png"); // Might need to adjust the content type based on your actual image type
        //        }
        //        return null;
        //    }
    //    }
    //}
    }
}
