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
    public class PhieuXuatChiTietsController : Controller
    {
        private vinmartDB db = new vinmartDB();

        // GET: Administrator/PhieuXuatChiTiets
        public ActionResult Index()
        {
            var phieuXuatChiTiets = db.PhieuXuatChiTiets.Include(p => p.MatHang).Include(p => p.PhieuXuat);
            return View(phieuXuatChiTiets.ToList());
        }

        // GET: Administrator/PhieuXuatChiTiets/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuXuatChiTiet phieuXuatChiTiet = db.PhieuXuatChiTiets.Find(id);
            if (phieuXuatChiTiet == null)
            {
                return HttpNotFound();
            }
            return View(phieuXuatChiTiet);
        }

        // GET: Administrator/PhieuXuatChiTiets/Create
        public ActionResult Create()
        {
            ViewBag.MaPX = new SelectList(db.MatHangs, "MaMH", "Ten");
            ViewBag.MaPX = new SelectList(db.PhieuXuats, "MaPX", "MaNV");
            return View();
        }

        // POST: Administrator/PhieuXuatChiTiets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPX,MaMH,SoLuong")] PhieuXuatChiTiet phieuXuatChiTiet)
        {
            if (ModelState.IsValid)
            {
                db.PhieuXuatChiTiets.Add(phieuXuatChiTiet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaPX = new SelectList(db.MatHangs, "MaMH", "Ten", phieuXuatChiTiet.MaPX);
            ViewBag.MaPX = new SelectList(db.PhieuXuats, "MaPX", "MaNV", phieuXuatChiTiet.MaPX);
            return View(phieuXuatChiTiet);
        }

        // GET: Administrator/PhieuXuatChiTiets/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuXuatChiTiet phieuXuatChiTiet = db.PhieuXuatChiTiets.Find(id);
            if (phieuXuatChiTiet == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPX = new SelectList(db.MatHangs, "MaMH", "Ten", phieuXuatChiTiet.MaPX);
            ViewBag.MaPX = new SelectList(db.PhieuXuats, "MaPX", "MaNV", phieuXuatChiTiet.MaPX);
            return View(phieuXuatChiTiet);
        }

        // POST: Administrator/PhieuXuatChiTiets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPX,MaMH,SoLuong")] PhieuXuatChiTiet phieuXuatChiTiet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuXuatChiTiet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPX = new SelectList(db.MatHangs, "MaMH", "Ten", phieuXuatChiTiet.MaPX);
            ViewBag.MaPX = new SelectList(db.PhieuXuats, "MaPX", "MaNV", phieuXuatChiTiet.MaPX);
            return View(phieuXuatChiTiet);
        }

        // GET: Administrator/PhieuXuatChiTiets/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuXuatChiTiet phieuXuatChiTiet = db.PhieuXuatChiTiets.Find(id);
            if (phieuXuatChiTiet == null)
            {
                return HttpNotFound();
            }
            return View(phieuXuatChiTiet);
        }

        // POST: Administrator/PhieuXuatChiTiets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PhieuXuatChiTiet phieuXuatChiTiet = db.PhieuXuatChiTiets.Find(id);
            db.PhieuXuatChiTiets.Remove(phieuXuatChiTiet);
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
