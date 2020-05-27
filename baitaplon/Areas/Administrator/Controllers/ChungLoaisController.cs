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
    public class ChungLoaisController : Controller
    {
        private vinmartDB db = new vinmartDB();

        // GET: Administrator/ChungLoais
        public ActionResult Index()
        {
            return View(db.ChungLoais.ToList());
        }

        // GET: Administrator/ChungLoais/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChungLoai chungLoai = db.ChungLoais.Find(id);
            if (chungLoai == null)
            {
                return HttpNotFound();
            }
            return View(chungLoai);
        }

        // GET: Administrator/ChungLoais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/ChungLoais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCL,Ten")] ChungLoai chungLoai)
        {
            if (ModelState.IsValid)
            {
                db.ChungLoais.Add(chungLoai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chungLoai);
        }

        // GET: Administrator/ChungLoais/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChungLoai chungLoai = db.ChungLoais.Find(id);
            if (chungLoai == null)
            {
                return HttpNotFound();
            }
            return View(chungLoai);
        }

        // POST: Administrator/ChungLoais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCL,Ten")] ChungLoai chungLoai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chungLoai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chungLoai);
        }

        // GET: Administrator/ChungLoais/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChungLoai chungLoai = db.ChungLoais.Find(id);
            if (chungLoai == null)
            {
                return HttpNotFound();
            }
            return View(chungLoai);
        }

        // POST: Administrator/ChungLoais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ChungLoai chungLoai = db.ChungLoais.Find(id);
            db.ChungLoais.Remove(chungLoai);
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
