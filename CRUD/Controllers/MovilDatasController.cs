using CRUD.Data;
using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace CRUD.Controllers
{
    public class MovilDatasController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: MovilDatas
        public ActionResult Index()
        {
            return View();
            //return View(db.Movil.ToList());
        }

        // GET: MovilDatas
        public ActionResult List()
        {
            return View(db.Movil.ToList());
        }

        // GET: MovilDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovilData movilData = db.Movil.Find(id);
            if (movilData == null)
            {
                return HttpNotFound();
            }
            return View(movilData);
        }

        // GET: MovilDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovilDatas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,TipoDocumento,NumDocumento,TipoVehiculo,PlacaVehiculo")] MovilData movilData, HttpPostedFileBase upload)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Movil.Add(movilData);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(movilData);
        //}

        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        var avatar = new File
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.Avatar,
                            ContentType = upload.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            avatar.Content = reader.ReadBytes(upload.ContentLength);
                        }
                        movilData.Files = new List<File> { avatar };
                    }
                    db.Movil.Add(movilData);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(movilData);
        }



        // GET: MovilDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovilData movilData = db.Movil.Include(s => s.Files).SingleOrDefault(s => s.Id == id);
            if (movilData == null)
            {
                return HttpNotFound();
            }
            return View(movilData);
        }

        // POST: MovilDatas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? Id, HttpPostedFileBase upload)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var moviToUpdate = db.Movil.Find(Id);
            if (TryUpdateModel(moviToUpdate, "",
           new string[] { "Nombre,TipoDocumento,NumDocumento,TipoVehiculo,PlacaVehiculo" }))
            {
                try
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        if (moviToUpdate.Files.Any(f => f.FileType == FileType.Avatar))
                        {
                            db.Files.Remove(moviToUpdate.Files.First(f => f.FileType == FileType.Avatar));
                        }
                        var avatar = new File
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.Avatar,
                            ContentType = upload.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            avatar.Content = reader.ReadBytes(upload.ContentLength);
                        }
                        moviToUpdate.Files = new List<File> { avatar };
                    }
                    db.Entry(moviToUpdate).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("List");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }

            return View(moviToUpdate);
        }




        // GET: MovilDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovilData movilData = db.Movil.Find(id);
            if (movilData == null)
            {
                return HttpNotFound();
            }
            return View(movilData);
        }

        // POST: MovilDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MovilData movilData = db.Movil.Find(id);
            db.Movil.Remove(movilData);
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
    }
}
