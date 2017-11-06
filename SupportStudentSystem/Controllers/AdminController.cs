using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using SupportStudentSystem.Models;

namespace SupportStudentSystem.Controllers
{
    public class AdminController : Controller
    {
        QUANLYSINHVIENEntities2 qlsv = new QUANLYSINHVIENEntities2();
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["Nhanvien"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection f, string id)
        {

            string sTaiKhoan = f.Get("userName").ToString();
            string sMatKhau = f.Get("password").ToString();
            NhanVien nv = qlsv.NhanVien.SingleOrDefault(a => a.NhanVienID == sTaiKhoan && a.MatKhau == sMatKhau);
            if (nv != null)
            {
                Session["Nhanvien"] = nv;
                Session["Tennhanvien"] = nv.Ho + nv.Ten;
                sTaiKhoan = id;

                return RedirectToAction("Index", "Admin");
            }
            if (nv == null)
            {
                ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng";
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session["Nhanvien"] = null;
            return RedirectToAction("Login");
        }
        public ActionResult danhSachDon(int? page)
        {
            if (Session["Nhanvien"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                int pageNumber = (page ?? 1);
                int pageSize = 15;
                return View(qlsv.DANHSACHDON.ToList().OrderBy(n => n.NgayNopDon).ToPagedList(pageNumber, pageSize));
            }
        }
    }
}