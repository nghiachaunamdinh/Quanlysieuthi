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
    public class LoaiHangsController : Controller
    {
        private vinmartDB db = new vinmartDB();

        // GET: Administrator/LoaiHangs
        public ActionResult Index()
        {
            var loaiHangs = db.LoaiHangs.Include(l => l.ChungLoai);
            return View(loaiHangs.ToList());
        }

        // GET: Administrator/LoaiHangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiHang loaiHang = db.LoaiHangs.Find(id);
            if (loaiHang == null)
            {
                return HttpNotFound();
            }
            return View(loaiHang);
        }

        // GET: Administrator/LoaiHangs/Create
        public ActionResult Create()
        {
            ViewBag.MaCL = new SelectList(db.ChungLoais, "MaCL", "Ten");
            return View();
        }

        // POST: Administrator/LoaiHangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLH,Ten,MaCL")] LoaiHang loaiHang)
        {
            if (ModelState.IsValid)
            {
                db.LoaiHangs.Add(loaiHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaCL = new SelectList(db.ChungLoais, "MaCL", "Ten", loaiHang.MaCL);
            return View(loaiHang);
        }

        // GET: Administrator/LoaiHangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiHang loaiHang = db.LoaiHangs.Find(id);
            if (loaiHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCL = new SelectList(db.ChungLoais, "MaCL", "Ten", loaiHang.MaCL);
            return View(loaiHang);
        }

        // POST: Administrator/LoaiHangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLH,Ten,MaCL")] LoaiHang loaiHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaCL = new SelectList(db.ChungLoais, "MaCL", "Ten", loaiHang.MaCL);
            return View(loaiHang);
        }

        // GET: Administrator/LoaiHangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiHang loaiHang = db.LoaiHangs.Find(id);
            if (loaiHang == null)
            {
                return HttpNotFound();
            }
            return View(loaiHang);
        }

        // POST: Administrator/LoaiHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LoaiHang loaiHang = db.LoaiHangs.Find(id);
            db.LoaiHangs.Remove(loaiHang);
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
