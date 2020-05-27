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
    public class PhieuKiemKeChiTietsController : Controller
    {
        private vinmartDB db = new vinmartDB();

        // GET: Administrator/PhieuKiemKeChiTiets
        public ActionResult Index()
        {
            var phieuKiemKeChiTiets = db.PhieuKiemKeChiTiets.Include(p => p.MatHang).Include(p => p.PhieuKiemKe);
            return View(phieuKiemKeChiTiets.ToList());
        }

        // GET: Administrator/PhieuKiemKeChiTiets/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuKiemKeChiTiet phieuKiemKeChiTiet = db.PhieuKiemKeChiTiets.Find(id);
            if (phieuKiemKeChiTiet == null)
            {
                return HttpNotFound();
            }
            return View(phieuKiemKeChiTiet);
        }

        // GET: Administrator/PhieuKiemKeChiTiets/Create
        public ActionResult Create()
        {
            ViewBag.MaPKK = new SelectList(db.MatHangs, "MaMH", "Ten");
            ViewBag.MaPKK = new SelectList(db.PhieuKiemKes, "MaPKK", "MaNV");
            return View();
        }

        // POST: Administrator/PhieuKiemKeChiTiets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPKK,MaMH,SLTon")] PhieuKiemKeChiTiet phieuKiemKeChiTiet)
        {
            if (ModelState.IsValid)
            {
                db.PhieuKiemKeChiTiets.Add(phieuKiemKeChiTiet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaPKK = new SelectList(db.MatHangs, "MaMH", "Ten", phieuKiemKeChiTiet.MaPKK);
            ViewBag.MaPKK = new SelectList(db.PhieuKiemKes, "MaPKK", "MaNV", phieuKiemKeChiTiet.MaPKK);
            return View(phieuKiemKeChiTiet);
        }

        // GET: Administrator/PhieuKiemKeChiTiets/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuKiemKeChiTiet phieuKiemKeChiTiet = db.PhieuKiemKeChiTiets.Find(id);
            if (phieuKiemKeChiTiet == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPKK = new SelectList(db.MatHangs, "MaMH", "Ten", phieuKiemKeChiTiet.MaPKK);
            ViewBag.MaPKK = new SelectList(db.PhieuKiemKes, "MaPKK", "MaNV", phieuKiemKeChiTiet.MaPKK);
            return View(phieuKiemKeChiTiet);
        }

        // POST: Administrator/PhieuKiemKeChiTiets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPKK,MaMH,SLTon")] PhieuKiemKeChiTiet phieuKiemKeChiTiet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuKiemKeChiTiet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPKK = new SelectList(db.MatHangs, "MaMH", "Ten", phieuKiemKeChiTiet.MaPKK);
            ViewBag.MaPKK = new SelectList(db.PhieuKiemKes, "MaPKK", "MaNV", phieuKiemKeChiTiet.MaPKK);
            return View(phieuKiemKeChiTiet);
        }

        // GET: Administrator/PhieuKiemKeChiTiets/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuKiemKeChiTiet phieuKiemKeChiTiet = db.PhieuKiemKeChiTiets.Find(id);
            if (phieuKiemKeChiTiet == null)
            {
                return HttpNotFound();
            }
            return View(phieuKiemKeChiTiet);
        }

        // POST: Administrator/PhieuKiemKeChiTiets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PhieuKiemKeChiTiet phieuKiemKeChiTiet = db.PhieuKiemKeChiTiets.Find(id);
            db.PhieuKiemKeChiTiets.Remove(phieuKiemKeChiTiet);
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
