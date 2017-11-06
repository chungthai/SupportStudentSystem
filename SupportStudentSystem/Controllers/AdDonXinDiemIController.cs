using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SupportStudentSystem.Models;
using PagedList;

namespace SupportStudentSystem.Controllers
{
    public class AdDonXinDiemIController : Controller
    {
        QUANLYSINHVIENEntities2 qlsv = new QUANLYSINHVIENEntities2();
        // GET: AdDonXetTotNghiep
        public ActionResult donXinDiemI(int? page)
        {
            if (Session["Nhanvien"] == null)
            {
                return Redirect("/Admin/Login");
            }
            else
            {
                int pageNumber = (page ?? 1);
                int pageSize = 15;
                return View(qlsv.DANHSACHDON.ToList().OrderBy(n => n.NgayNopDon).Where(n => n.DonTuID == "XTN").ToPagedList(pageNumber, pageSize));
            }
        }

        public ActionResult Details(string id)
        {
            //Lấy ra đối tượng sản phẩm theo mã
            DonXinNhanDiemI_HoanThi sv = qlsv.DonXinNhanDiemI_HoanThi.SingleOrDefault(n => n.DonTuID == id);
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
            DonXinNhanDiemI_HoanThi sv = qlsv.DonXinNhanDiemI_HoanThi.SingleOrDefault(n => n.DonTuID == id);
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
            DonXinNhanDiemI_HoanThi sv = qlsv.DonXinNhanDiemI_HoanThi.SingleOrDefault(n => n.DonTuID == id);
            ViewBag.Maloai = sv.DonTuID;
            if (sv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            qlsv.DonXinNhanDiemI_HoanThi.Remove(sv);
            qlsv.SaveChanges();
            return Redirect("/AdDonXinDiemI/donXinDiemI");
        }

        //Sửa sản phẩm
        [HttpGet]
        public ActionResult Edit(string id)
        {
            //Lấy đối tượng sản phẩm
            DonXinNhanDiemI_HoanThi sv = qlsv.DonXinNhanDiemI_HoanThi.SingleOrDefault(n => n.DonTuID == id);
            if (sv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sv);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(DonXinNhanDiemI_HoanThi sv)
        {
            UpdateModel(sv);
            qlsv.SaveChanges();
            return Redirect("/AdDonXinDiemI/donXinDiemI");
        }
    }
}