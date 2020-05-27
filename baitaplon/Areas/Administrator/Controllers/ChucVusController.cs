using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using vinmart;

namespace baitaplon.Areas.Administrator.Controllers
{
    public class ChucVusController : Controller
    {
        private vinmartDB db = new vinmartDB();

        // GET: Administrator/ChucVus
        public ActionResult Index()
        {
            return View(db.ChucVus.ToList());
        }

        // GET: Administrator/ChucVus/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChucVu chucVu = db.ChucVus.Find(id);
            if (chucVu == null)
            {
                return HttpNotFound();
            }
            return View(chucVu);
        }

        // GET: Administrator/ChucVus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/ChucVus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCV,Ten")] ChucVu chucVu)
        {
            if (ModelState.IsValid)
            {
                db.ChucVus.Add(chucVu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chucVu);
        }

        // GET: Administrator/ChucVus/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChucVu chucVu = db.ChucVus.Find(id);
            if (chucVu == null)
            {
                return HttpNotFound();
            }
            return View(chucVu);
        }

        // POST: Administrator/ChucVus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCV,Ten")] ChucVu chucVu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chucVu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chucVu);
        }

        // GET: Administrator/ChucVus/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChucVu chucVu = db.ChucVus.Find(id);
            if (chucVu == null)
            {
                return HttpNotFound();
            }
            return View(chucVu);
        }

        // POST: Administrator/ChucVus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ChucVu chucVu = db.ChucVus.Find(id);
            db.ChucVus.Remove(chucVu);
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
