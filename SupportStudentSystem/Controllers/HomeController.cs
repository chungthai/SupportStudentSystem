using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SupportStudentSystem.Models;

namespace SupportStudentSystem.Controllers
{
    public class HomeController : Controller
    {
        QUANLYSINHVIENEntities2 qlsv = new QUANLYSINHVIENEntities2();
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection f, string id)
        {
            string sTaiKhoan = f.Get("UserName").ToString();
            string sMatKhau = f.Get("Password").ToString();
            SinhVien sv = qlsv.SinhVien.SingleOrDefault(a => a.MSSV == sTaiKhoan && a.MatKhau == sMatKhau);

            if (sv != null)
            {
                ViewBag.ThongBao = "Chúc mừng bạn đăng nhập thành công";
                Session["TaiKhoan"] = sTaiKhoan;
                Session["Tensinhvien"] = sv.HoLot + " " + sv.Ten;
                sTaiKhoan = id;

                return RedirectToAction("Index", "Home");
            }
            if (sv == null)
            {
                ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng";

            }
            return View();
        }
        public ActionResult FormApp()
        {
            return View();
        }
        public ActionResult ThongTinSinhVien(string id)
        {

            id = Session["TaiKhoan"].ToString();

            var sv = from c in qlsv.TTSV
                     where c.MSSV == id
                     select c;
            return View(sv);


        }
        public ActionResult ThongTinSinhVienDiemI(string id)
        {

            id = Session["TaiKhoan"].ToString();

            var sv = from c in qlsv.TTSV
                     where c.MSSV == id
                     select c;
            return View(sv);


        }
        [HttpGet]
        public ActionResult DonXetTotNghiep()
        {
            return View();
        }
        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        string sinhma(string ma)
        {

            int random = RandomNumber(0, 1000);
            ma = random.ToString();
            //string s = ma.Substring(2, ma.Length - 2);
            int i = int.Parse(ma);
            i++;
            if (i < 10) return "GV00" + Convert.ToString(i);
            else
            if (i < 1000) return "GV0" + Convert.ToString(i);
            else return "GV" + Convert.ToString(i);

        }

        [HttpPost]
        public ActionResult DonXetTotNghiep(FormCollection f, string sm)
        {

            string tntruochen;
            if (f["tntruochen"] == null)
            {
                tntruochen = "";
            }
            else
            {
                tntruochen = f["tntruochen"].ToString();
            }

            string nohocphan;
            if (f["nohocphan"] == null)
            {
                nohocphan = "";
            }
            else
            {
                nohocphan = f["nohocphan"].ToString();
            }

            string caithiendiem;
            if (f["caithiendiem"] == null)
            {
                caithiendiem = "";
            }
            else
            {
                caithiendiem = f["caithiendiem"].ToString();
            }

            string thieuchungchi;
            if (f["thieuchungchi"] == null)
            {
                thieuchungchi = "";
            }
            else
            {
                thieuchungchi = f["thieuchungchi"].ToString();
            }

            string lydokhac;
            if (f["lydokhac"] == null)
            {
                lydokhac = "";
            }
            else
            {
                lydokhac = f["lydokhac"].ToString();
            }
            string CCNN = f.Get("CCNN").ToString();
            string SHNN = f.Get("soHieuNN").ToString();
            string VSNN = f.Get("soVaoSoNN").ToString();
            string NCNN = f.Get("ngayCapNN").ToString();
            string MCNN = f.Get("minhChungNN").ToString();
            string CCTH = f.Get("CCTH").ToString();
            string SHTH = f.Get("soHieuTH").ToString();
            string VSTH = f.Get("soVaoSoTH").ToString();
            string NCTH = f.Get("ngayCapTH").ToString();
            string MCTH = f.Get("minhChungTH").ToString();
            string CCNH1 = f.Get("CCNH1").ToString();
            string SHNH1 = f.Get("soHieuNH1").ToString();
            string VSNH1 = f.Get("soVaoSoNH1").ToString();
            string NCNH1 = f.Get("ngayCapNH1").ToString();
            string MCNH1 = f.Get("minhChungNH1").ToString();
            string CCNH2 = f.Get("CCNH2").ToString();
            string SHNH2 = f.Get("soHieuNH2").ToString();
            string VSNH2 = f.Get("soVaoSoNH2").ToString();
            string NCNH2 = f.Get("ngayCapNH2").ToString();
            string MCNH2 = f.Get("minhChungNH2").ToString();
            string lydochuatotnghiep = tntruochen + " " + nohocphan + " " + caithiendiem + " " + thieuchungchi + " " + lydokhac;
            if (tntruochen.ToString() == null && nohocphan.ToString() == null && caithiendiem.ToString() == null && thieuchungchi.ToString() == null && lydokhac.ToString() == null)
            {
                ViewData["Loi1"] = "Bạn chưa chọn lý do";
            }
            else if (String.IsNullOrEmpty(CCNN))
            {
                ViewData["Loi2"] = "Bạn chưa chọn chứng chỉ ngoại ngữ";
            }
            else if (String.IsNullOrEmpty(SHNN))
            {
                ViewData["Loi3"] = "Bạn chưa nhập số hiệu chứng chỉ ngoại ngữ";
            }
            else if (String.IsNullOrEmpty(VSNN))
            {
                ViewData["Loi4"] = "Bạn chưa nhập số vào sổ chứng chỉ ngoại ngữ";
            }
            else if (String.IsNullOrEmpty(NCNN))
            {
                ViewData["Loi5"] = "Bạn chưa nhập ngày cấp chứng chỉ ngoại ngữ";
            }
            else if (String.IsNullOrEmpty(CCTH))
            {
                if (String.IsNullOrEmpty(CCNH1))
                {
                    ViewData["Loi6"] = "Bạn chưa nhập chứng chỉ ngắn hạn 1";
                }
                else if (String.IsNullOrEmpty(SHNH1))
                {
                    ViewData["Loi7"] = "Bạn chưa nhập số hiệu chứng chỉ ngắn hạn 1";
                }
                else if (String.IsNullOrEmpty(VSNH1))
                {
                    ViewData["Loi8"] = "Bạn chưa nhập số vào sổ chứng chỉ ngắn hạn 1";
                }
                else if (String.IsNullOrEmpty(NCNH1))
                {
                    ViewData["Loi9"] = "Bạn chưa nhập ngày cấp chứng chỉ ngắn hạn 1";
                }
                else if (String.IsNullOrEmpty(CCNH2))
                {
                    ViewData["Loi10"] = "Bạn chưa nhập chứng chỉ ngắn hạn 2";
                }
                else if (String.IsNullOrEmpty(SHNH2))
                {
                    ViewData["Loi11"] = "Bạn chưa nhập số hiệu chứng chỉ ngắn hạn 2";
                }
                else if (String.IsNullOrEmpty(VSNH2))
                {
                    ViewData["Loi12"] = "Bạn chưa nhập số vào sổ chứng chỉ ngắn hạn 2";
                }
                else if (String.IsNullOrEmpty(NCNH2))
                {
                    ViewData["Loi13"] = "Bạn chưa nhập ngày cấp chứng chỉ ngắn hạn 2";
                }
                else
                {
                    ViewData["Loi14"] = "Bạn chưa chọn chứng chỉ tin học";

                }
            }
            else if (String.IsNullOrEmpty(SHTH))
            {
                ViewData["Loi15"] = "Bạn chưa nhập số hiệu chứng chỉ tin học";
            }
            else if (String.IsNullOrEmpty(VSTH))
            {
                ViewData["Loi16"] = "Bạn chưa nhập số vào sổ chứng chỉ tin học";
            }
            else if (String.IsNullOrEmpty(NCTH))
            {
                ViewData["Loi17"] = "Bạn chưa nhập ngày cấp chứng chỉ tin học";
            }
            else
            {
                DonDeNghiXetTotNghiep don = new DonDeNghiXetTotNghiep();

                if (lydochuatotnghiep.Length > 0)
                {
                   
                    Session["LyDo"] = lydochuatotnghiep.ToString();
                    don.DonTuID = "DXTN" + sinhma(sm);
                    don.LyDo = lydochuatotnghiep;
                    qlsv.DonDeNghiXetTotNghiep.Add(don);
                    qlsv.SaveChanges();
                    Session["IDDonTotNgiep"] = don.DonTuID;


                }
                if (lydokhac.Length > 0)
                {
                    Session["LyDo"] = lydokhac.ToString();
                    
                    don.DonTuID = "DXTN" + sinhma(sm);
                    don.LyDo = lydochuatotnghiep;
                    qlsv.DonDeNghiXetTotNghiep.Add(don);
                    qlsv.SaveChanges();
                    Session["IDDonTotNgiep"] = don.DonTuID;

                }
                if (SHNN.Length > 0)
                {
                    Session["LyDo"] = CCNN.ToString();
                    
                    don.DonTuID = "DXTN" + sinhma(sm);
                    don.CCTAID = CCNN.ToString();
                    don.SoHieu_CCTA = SHNN.ToString();
                    don.SoVaoSo_CCTA = VSNN.ToString();
                    don.NgayCap_CCTA = DateTime.Parse(NCNN);
                    don.MinhChung_CCTA = MCNN;
                    qlsv.DonDeNghiXetTotNghiep.Add(don);
                    qlsv.SaveChanges();
                    Session["IDDonTotNgiep"] = don.DonTuID;

                }
                if (SHTH.Length > 0)
                {
                    Session["LyDo"] = CCTH.ToString();
                    
                    don.DonTuID = "DXTN" + sinhma(sm);
                    don.CCTHID = CCTH.ToString();
                    don.SoHieu_CCTH = SHTH.ToString();
                    don.SoVaoSo_CCTH = VSTH.ToString();
                    don.NgayCap_CCTH = DateTime.Parse(NCTH);
                    don.MinhChung_CCTH = CCTH;
                    qlsv.DonDeNghiXetTotNghiep.Add(don);
                    qlsv.SaveChanges();
                    Session["IDDonTotNgiep"] = don.DonTuID;
                }
                if (SHNH1.Length > 0)
                {
                    Session["LyDo"] = CCNH1.ToString();
                    
                    don.DonTuID = "DXTN" + sinhma(sm);
                    don.CCNHID1 = CCNH1.ToString();
                    don.SoHieu_CCNH1 = SHNH1.ToString();
                    don.SoVaoSo_CCNH1 = VSNH1.ToString();
                    don.NgayCap_CCNH1 = DateTime.Parse(NCNH1);
                    don.MinhChung_CCNH1 = MCNH1;
                    qlsv.DonDeNghiXetTotNghiep.Add(don);
                    qlsv.SaveChanges();
                    Session["IDDonTotNgiep"] = don.DonTuID;
                }
                if (SHNH2.Length > 0)
                {
                    Session["LyDo"] = CCNH2.ToString();
                  
                    don.DonTuID = "DXTN" + sinhma(sm);
                    don.CCNHID2 = CCNH2.ToString();
                    don.SoHieu_CCNH2 = SHNH2.ToString();
                    don.SoVaoSo_CCNH2 = VSNH2.ToString();
                    don.NgayCap_CCNH2 = DateTime.Parse(NCNH2);
                    don.MinhChung_CCNH2 = MCNH2;
                    qlsv.DonDeNghiXetTotNghiep.Add(don);
                    qlsv.SaveChanges();
                    Session["IDDonTotNgiep"] = don.DonTuID;
                }
                return RedirectToAction("XacNhanThongTin", "Home");
            }
            return this.DonXetTotNghiep();
        }
        [HttpGet]
        public ActionResult XacNhanThongTin()
        {
            string id = Session["TaiKhoan"].ToString();

            var sv = from c in qlsv.TTSV

                     where c.MSSV == id
                     select c;

            return View(sv);
        }

        [HttpPost]
        public ActionResult XacNhanThongTin(FormCollection f, string sm)
        {


            DonTu don1 = new DonTu();
            don1.DonTuID = Session["IDDonTotNgiep"].ToString();
            don1.NgayNopDon = DateTime.Now;
            don1.MSSV = Session["TaiKhoan"].ToString();
            qlsv.DonTu.Add(don1);
            qlsv.SaveChanges();
            return RedirectToAction("FormApp", "Home");

        }

        [HttpGet]
        public ActionResult DonXinDiemI()
        {

            return View();
        }
        [HttpPost]
        public ActionResult DonXinDiemI(FormCollection f, string sm)
        {

            string MaHocPhan = f.Get("MaHocPhan").ToString();
            string TenHocPhan = f.Get("TenHocPhan").ToString();
            string LyDoNhanDiemI = f.Get("LyDoNhanDiemI").ToString();
            string MinhChungDonXinDiemI = f.Get("minhChungDonXinDiemI").ToString();
            Session["MonHoanThi"] = TenHocPhan;
            Session["LyDoHoanThi"] = LyDoNhanDiemI;
            DonXinNhanDiemI_HoanThi don = new DonXinNhanDiemI_HoanThi();
            don.DonTuID = "DXinDI" + sinhma(sm);
            don.HocPhanID = MaHocPhan;
            don.LyDo = LyDoNhanDiemI;
            don.MinhChung = MinhChungDonXinDiemI;
            qlsv.DonXinNhanDiemI_HoanThi.Add(don);
            qlsv.SaveChanges();
            Session["IDDonXinDiemI"] = don.DonTuID;
            return RedirectToAction("XacNhanThongTin_DXDI", "Home");
        }
        [HttpGet]
        public ActionResult XacNhanThongTin_DXDI()
        {
            string id = Session["TaiKhoan"].ToString();

            var sv = from c in qlsv.TTSV

                     where c.MSSV == id
                     select c;

            return View(sv);
        }
        [HttpPost]
        public ActionResult XacNhanThongTin_DXDI(FormCollection f)
        {

            DonTu don1 = new DonTu();
            don1.DonTuID = Session["IDDonXinDiemI"].ToString();
            don1.NgayNopDon = DateTime.Now;
            don1.MSSV = Session["TaiKhoan"].ToString();
            qlsv.DonTu.Add(don1);
            qlsv.SaveChanges();
            return RedirectToAction("FormApp", "Home");

        }

        [HttpGet]
        public ActionResult DonXoaDiemI()
        {

            string id = Session["TaiKhoan"].ToString();
            var tt = from c in qlsv.donxoaI

                     where c.MSSV == id

                     select c;
            //var tt = qlsv.donxoaI.SingleOrDefault(x => x.MSSV == id);
            //Session["MonHoanThi"] = tt.TenMH;
            return View(tt);
        }
        [HttpPost]
        public ActionResult DonXoaDiemI(FormCollection f, string sm)
        {
            string id = Session["TaiKhoan"].ToString();
            var donxinI = qlsv.DonTu.SingleOrDefault(x => x.MSSV == id);
            string hpid = f.Get("MaHocPhan").ToString();
            string nhomthi = f.Get("NhomThi").ToString();
            string tothi = f.Get("ToThi").ToString();
            string ngaythi = f.Get("NgayThi").ToString();
            string phongthi = f.Get("PhongThi").ToString();
            string giothi = f.Get("GioThi").ToString();
            Session["MonHoanThi"] = f.Get("TenHocPhan").ToString();
            DonXinThiXoaDiemI don = new DonXinThiXoaDiemI();
            don.DonTuID = "DXDI" + sinhma(sm);
            don.DonXinNhanDiemI_ID = donxinI.DonTuID;
            don.GioThi = giothi;
            don.HocPhanID = hpid;
            don.ToThi = tothi;
            don.NgayThi = DateTime.Parse(ngaythi.ToString());
            don.PhongThi = phongthi;
            don.NhomThi = nhomthi;

            qlsv.DonXinThiXoaDiemI.Add(don);
            qlsv.SaveChanges();
            Session["IDDonXinXoaDiemI"] = don.DonTuID;
            return RedirectToAction("XacNhanThongTin_DXXDI", "Home");
        }
        [HttpGet]
        public ActionResult XacNhanThongTin_DXXDI()
        {
            string id = Session["TaiKhoan"].ToString();

            var sv = from c in qlsv.TTSV

                     where c.MSSV == id
                     select c;

            return View(sv);

        }
        [HttpPost]
        public ActionResult XacNhanThongTin_DXXDI(FormCollection f)
        {
            DonTu don1 = new DonTu();
            don1.DonTuID = Session["IDDonXinXoaDiemI"].ToString();
            don1.NgayNopDon = DateTime.Now;
            don1.MSSV = Session["TaiKhoan"].ToString();
            qlsv.DonTu.Add(don1);
            qlsv.SaveChanges();
            return RedirectToAction("FormApp", "Home");

        }
    }
}