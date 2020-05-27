using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vinmart;

namespace baitaplon.Areas.Administrator.Controllers
{
    public class HomeController : Controller
    {
        vinmartDB db = new vinmartDB();
        // GET: Administrator/Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username,string password)
        {
            NhanVien user = db.NhanViens.SingleOrDefault(x => x.Username == username && x.Pwd == password &&x.allowed==1);
            if(user != null)
            {
                Session["MaNV"] = user.MaNV;
                Session["username"] = user.Username;
                Session["avatar"] = user.avatar;
                return RedirectToAction("Index");
            }
            ViewBag.error = "sai ten dang nhap hoac mat khau !";
            return View();
        }
    }
}