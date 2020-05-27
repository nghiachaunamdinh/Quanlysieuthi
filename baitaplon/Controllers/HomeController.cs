using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vinmart;

namespace baitaplon.Controllers
{
    public class HomeController : Controller
    {
        vinmartDB db = new vinmartDB();
        public ActionResult Index()
        {
            ViewBag.mhnew = db.MatHangs.OrderByDescending(x => x.NgayNhap).Take(6).ToList();
            ViewBag.mhbanchay = db.MatHangs.OrderByDescending(x => x.SoLuongBan).Take(3).ToList();
            return View();
        }
        public ActionResult Mathang()
        {
            ViewBag.mh = db.MatHangs.OrderByDescending(x => x.NgayNhap).Take(100).ToList();
            return View();
        }
        public ActionResult Mathanghot()
        {
            ViewBag.mhbanchay = db.MatHangs.OrderByDescending(x => x.SoLuongBan).Take(5).ToList();
            return View();
        }
        public ActionResult Detailes(string ma)
        {
            //timf kieen mh co ma la ma
            MatHang mh = db.MatHangs.SingleOrDefault(x => x.MaMH == ma);
            if (mh == null)
            {
                return HttpNotFound();
            }
            return View(mh);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}