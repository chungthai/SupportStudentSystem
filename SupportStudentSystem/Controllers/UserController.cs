using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SupportStudentSystem.Models;
namespace SupportStudentSystem.Controllers
{
    public class UserController : Controller
    {
        QUANLYSINHVIENEntities2 qlsv = new QUANLYSINHVIENEntities2();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection f, string id)
        {
            string sTaiKhoan = f.Get("UserName").ToString();
            string sMatKhau = f.Get("Password").ToString();
            SinhVien sv = qlsv.SinhVien.SingleOrDefault(a => a.MSSV == sTaiKhoan && a.MatKhau == sMatKhau);

            if (sv != null)
            {
                Session["Tensinhvien"] = sv;
                Session["Tensinhvien"] = sv.HoLot + sv.Ten;
                sTaiKhoan = id;

                return RedirectToAction("Index", "Home");
            }
            if (sv == null)
            {
                ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng";
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session["Tensinhvien"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}