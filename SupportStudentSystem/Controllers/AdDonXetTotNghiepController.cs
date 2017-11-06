using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using SupportStudentSystem.Models;

namespace SupportStudentSystem.Controllers
{
    public class AdDonXetTotNghiepController : Controller
    {
        QUANLYSINHVIENEntities2 qlsv = new QUANLYSINHVIENEntities2();
        // GET: AdDonXetTotNghiep
        public ActionResult donXetTotNghiep(int? page)
        {
            if (Session["Nhanvien"] == null)
            {
                return Redirect("/Admin/Login");
            }
            else
            {
                int pageNumber = (page ?? 1);
                int pageSize = 15;
                return View(qlsv.DANHSACHDON.ToList().OrderBy(n => n.NgayNopDon).ToPagedList(pageNumber, pageSize));
            }
        }

        public ActionResult Details(string id)
        {
            //Lấy ra đối tượng sản phẩm theo mã
            DonDeNghiXetTotNghiep sv = qlsv.DonDeNghiXetTotNghiep.SingleOrDefault(n => n.DonTuID == id);
           // ViewBag.
            if (sv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sv);
        }

        //Xóa sản phẩm
        [HttpGet]
        public ActionResult Delete(string id)
        {
            //Lấy ra đối tượng cần xóa
            DonDeNghiXetTotNghiep sv = qlsv.DonDeNghiXetTotNghiep.SingleOrDefault(n => n.DonTuID == id);
            ViewBag.donXetTN = sv.DonTuID;
            if (sv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sv);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Xacnhanxoa(string id)
        {
            //Lấy đối tượng sản phẩm cần xóa theo mã
            DonDeNghiXetTotNghiep sv = qlsv.DonDeNghiXetTotNghiep.SingleOrDefault(n => n.DonTuID == id);
            ViewBag.Maloai = sv.DonTuID;
            if (sv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            qlsv.DonDeNghiXetTotNghiep.Remove(sv);
            qlsv.SaveChanges();
            return Redirect("/AdDonXetTotNghiep/donXetTotNghiep");
        }

        //Sửa sản phẩm
        [HttpGet]
        public ActionResult Edit(string id)
        {
            //Lấy đối tượng sản phẩm
            DonDeNghiXetTotNghiep sv = qlsv.DonDeNghiXetTotNghiep.SingleOrDefault(n => n.DonTuID == id);
            if (sv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sv);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(DonDeNghiXetTotNghiep sv)
        {
            UpdateModel(sv);
            qlsv.SaveChanges();
            return Redirect("/AdDonXetTotNghiep/donXetTotNghiep");
        }
    }
}