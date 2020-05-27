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
    public class MatHangsController : Controller
    {
        private vinmartDB db = new vinmartDB();

        // GET: Administrator/MatHangs
        public ActionResult Index()
        {
            var matHangs = db.MatHangs.Include(m => m.DonViTinh).Include(m => m.LoaiHang);
            return View(matHangs.ToList());
        }

        // GET: Administrator/MatHangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatHang matHang = db.MatHangs.Find(id);
            if (matHang == null)
            {
                return HttpNotFound();
            }
            return View(matHang);
        }

        // GET: Administrator/MatHangs/Create
        public ActionResult Create()
        {
            ViewBag.MaDVT = new SelectList(db.DonViTinhs, "MaDVT", "Ten");
            ViewBag.MaLH = new SelectList(db.LoaiHangs, "MaLH", "Ten");
            return View();
        }

        // POST: Administrator/MatHangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaMH,Ten,MaLH,MaDVT,NgaySanXuat,SoLuongNhap,SoLuongBan,GiaBan,GiaMua,VAT,MoTa,NgayNhap,NgayHetHan,HinhMinhHoa")] MatHang matHang)
        {
            if (ModelState.IsValid)
            {
                db.MatHangs.Add(matHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDVT = new SelectList(db.DonViTinhs, "MaDVT", "Ten", matHang.MaDVT);
            ViewBag.MaLH = new SelectList(db.LoaiHangs, "MaLH", "Ten", matHang.MaLH);
            return View(matHang);
        }

        // GET: Administrator/MatHangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatHang matHang = db.MatHangs.Find(id);
            if (matHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDVT = new SelectList(db.DonViTinhs, "MaDVT", "Ten", matHang.MaDVT);
            ViewBag.MaLH = new SelectList(db.LoaiHangs, "MaLH", "Ten", matHang.MaLH);
            return View(matHang);
        }

        // POST: Administrator/MatHangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaMH,Ten,MaLH,MaDVT,NgaySanXuat,SoLuongNhap,SoLuongBan,GiaBan,GiaMua,VAT,MoTa,NgayNhap,NgayHetHan,HinhMinhHoa")] MatHang matHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDVT = new SelectList(db.DonViTinhs, "MaDVT", "Ten", matHang.MaDVT);
            ViewBag.MaLH = new SelectList(db.LoaiHangs, "MaLH", "Ten", matHang.MaLH);
            return View(matHang);
        }

        // GET: Administrator/MatHangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatHang matHang = db.MatHangs.Find(id);
            if (matHang == null)
            {
                return HttpNotFound();
            }
            return View(matHang);
        }

        // POST: Administrator/MatHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MatHang matHang = db.MatHangs.Find(id);
            db.MatHangs.Remove(matHang);
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
