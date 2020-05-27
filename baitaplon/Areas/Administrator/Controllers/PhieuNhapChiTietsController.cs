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
    public class PhieuNhapChiTietsController : Controller
    {
        private vinmartDB db = new vinmartDB();

        // GET: Administrator/PhieuNhapChiTiets
        public ActionResult Index()
        {
            var phieuNhapChiTiets = db.PhieuNhapChiTiets.Include(p => p.MatHang).Include(p => p.NhaCungCap).Include(p => p.PhieuNhap);
            return View(phieuNhapChiTiets.ToList());
        }

        // GET: Administrator/PhieuNhapChiTiets/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuNhapChiTiet phieuNhapChiTiet = db.PhieuNhapChiTiets.Find(id);
            if (phieuNhapChiTiet == null)
            {
                return HttpNotFound();
            }
            return View(phieuNhapChiTiet);
        }

        // GET: Administrator/PhieuNhapChiTiets/Create
        public ActionResult Create()
        {
            ViewBag.MaPN = new SelectList(db.MatHangs, "MaMH", "Ten");
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "Ten");
            ViewBag.MaPN = new SelectList(db.PhieuNhaps, "MaPN", "MaNV");
            return View();
        }

        // POST: Administrator/PhieuNhapChiTiets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPN,MaMH,MaNCC")] PhieuNhapChiTiet phieuNhapChiTiet)
        {
            if (ModelState.IsValid)
            {
                db.PhieuNhapChiTiets.Add(phieuNhapChiTiet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaPN = new SelectList(db.MatHangs, "MaMH", "Ten", phieuNhapChiTiet.MaPN);
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "Ten", phieuNhapChiTiet.MaNCC);
            ViewBag.MaPN = new SelectList(db.PhieuNhaps, "MaPN", "MaNV", phieuNhapChiTiet.MaPN);
            return View(phieuNhapChiTiet);
        }

        // GET: Administrator/PhieuNhapChiTiets/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuNhapChiTiet phieuNhapChiTiet = db.PhieuNhapChiTiets.Find(id);
            if (phieuNhapChiTiet == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPN = new SelectList(db.MatHangs, "MaMH", "Ten", phieuNhapChiTiet.MaPN);
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "Ten", phieuNhapChiTiet.MaNCC);
            ViewBag.MaPN = new SelectList(db.PhieuNhaps, "MaPN", "MaNV", phieuNhapChiTiet.MaPN);
            return View(phieuNhapChiTiet);
        }

        // POST: Administrator/PhieuNhapChiTiets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPN,MaMH,MaNCC")] PhieuNhapChiTiet phieuNhapChiTiet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuNhapChiTiet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPN = new SelectList(db.MatHangs, "MaMH", "Ten", phieuNhapChiTiet.MaPN);
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "Ten", phieuNhapChiTiet.MaNCC);
            ViewBag.MaPN = new SelectList(db.PhieuNhaps, "MaPN", "MaNV", phieuNhapChiTiet.MaPN);
            return View(phieuNhapChiTiet);
        }

        // GET: Administrator/PhieuNhapChiTiets/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuNhapChiTiet phieuNhapChiTiet = db.PhieuNhapChiTiets.Find(id);
            if (phieuNhapChiTiet == null)
            {
                return HttpNotFound();
            }
            return View(phieuNhapChiTiet);
        }

        // POST: Administrator/PhieuNhapChiTiets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PhieuNhapChiTiet phieuNhapChiTiet = db.PhieuNhapChiTiets.Find(id);
            db.PhieuNhapChiTiets.Remove(phieuNhapChiTiet);
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
