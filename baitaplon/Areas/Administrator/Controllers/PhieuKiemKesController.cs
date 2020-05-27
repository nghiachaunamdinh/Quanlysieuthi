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
    public class PhieuKiemKesController : Controller
    {
        private vinmartDB db = new vinmartDB();

        // GET: Administrator/PhieuKiemKes
        public ActionResult Index()
        {
            var phieuKiemKes = db.PhieuKiemKes.Include(p => p.NhanVien);
            return View(phieuKiemKes.ToList());
        }

        // GET: Administrator/PhieuKiemKes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuKiemKe phieuKiemKe = db.PhieuKiemKes.Find(id);
            if (phieuKiemKe == null)
            {
                return HttpNotFound();
            }
            return View(phieuKiemKe);
        }

        // GET: Administrator/PhieuKiemKes/Create
        public ActionResult Create()
        {
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "Ten");
            return View();
        }

        // POST: Administrator/PhieuKiemKes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPKK,MaNV,NgayCapThe")] PhieuKiemKe phieuKiemKe)
        {
            if (ModelState.IsValid)
            {
                db.PhieuKiemKes.Add(phieuKiemKe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "Ten", phieuKiemKe.MaNV);
            return View(phieuKiemKe);
        }

        // GET: Administrator/PhieuKiemKes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuKiemKe phieuKiemKe = db.PhieuKiemKes.Find(id);
            if (phieuKiemKe == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "Ten", phieuKiemKe.MaNV);
            return View(phieuKiemKe);
        }

        // POST: Administrator/PhieuKiemKes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPKK,MaNV,NgayCapThe")] PhieuKiemKe phieuKiemKe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuKiemKe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "Ten", phieuKiemKe.MaNV);
            return View(phieuKiemKe);
        }

        // GET: Administrator/PhieuKiemKes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuKiemKe phieuKiemKe = db.PhieuKiemKes.Find(id);
            if (phieuKiemKe == null)
            {
                return HttpNotFound();
            }
            return View(phieuKiemKe);
        }

        // POST: Administrator/PhieuKiemKes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PhieuKiemKe phieuKiemKe = db.PhieuKiemKes.Find(id);
            db.PhieuKiemKes.Remove(phieuKiemKe);
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
