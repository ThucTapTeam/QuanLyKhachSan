using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bunifu.Framework.UI;
using DevComponents.DotNetBar.Controls;
using System.Windows.Forms;

namespace QuanLyKhachSan.Controller
{
    public class DatPhongController
    {
        public void DatPhong(TextBoxX tbhoten,BunifuDropdown ddGioiTinh,TextBoxX tbsocmt,TextBoxX tbphone,BunifuDatepicker DPNgayDat,BunifuDatepicker DPNgayTra,Label label2,Label label8,out int transfer)
        {
            transfer = 0;
            ChuanHoa ch = new ChuanHoa();
            HotelObject.KhachHangHo kh = new HotelObject.KhachHangHo();
            HotelObject.ThuePhongHo tp = new HotelObject.ThuePhongHo();
            HotelObject.PhongFo p = new HotelObject.PhongFo();
            string day, month, year;
            string day1, month1, year1;
            string day2, month2, year2;
            ch.ChuanHoaDate(DPNgayTra.Value.ToString(), out day1, out month1, out year1);
            ch.ChuanHoaDate(DPNgayDat.Value.ToString(), out day, out month, out year);
            ch.ChuanHoaDate(DateTime.Now.ToString(), out day2, out month2, out year2);
            Connection cn = new Connection();
            if (ch.CheckTB(tbhoten.Text, tbsocmt.Text, tbphone.Text) == false)
            {
                Notification nf = new Notification("LỖI", "Thông tin phải được nhập đầy đủ.", "Mời bạn nhập lại.");
                nf.Show();
            }
            else if (ch.CheckDate(Int32.Parse(day2), Int32.Parse(month2), Int32.Parse(year2), Int32.Parse(day), Int32.Parse(month), Int32.Parse(year)) == false)
            {
                Notification nf = new Notification("LỖI", "Ngày đặt phòng không hợp lệ.", "Mời bạn nhập lại.");
                nf.Show();
            }
            else if (ch.CheckDate(Int32.Parse(day), Int32.Parse(month), Int32.Parse(year), Int32.Parse(day1), Int32.Parse(month1), Int32.Parse(year1)) == false)
            {
                Notification nf = new Notification("LỖI", "Ngày đặt phòng và ngày trả phòng không hợp lệ.", "Mời bạn nhập lại.");
                nf.Show();
            }
            
            else if (ch.Check_SoCMT(tbsocmt)==false)
            {
                Notification nf = new Notification("LỖI", "Số CMT không hợp lệ.", "Mời bạn nhập lại.");
                nf.Show();
            }
            else if(ch.Check_Phone(tbphone)==false)
            {
                Notification nf = new Notification("LỖI", "Số điện thoại không hợp lệ.", "Mời bạn nhập lại.");
                nf.Show();
            }
            else
            {     
                kh.TenKhachHang = ch.CH_Name(tbhoten);
                kh.SoCMT = ch.CH_Space(tbsocmt);
                string temp = null, temp2 = null;
                kh.MaKhachHang= cn.LayBien("select makhachhang from khachhang order by makhachhang asc", 0);
                tp.MaThue = cn.LayBien("select mathue from thuephong order by mathue asc", 0);
                p.MaPhong = cn.LayBien("select maphong from phong where tenphong='" + label2.Text + "'", 0);
                for (int i = 2; i < kh.MaKhachHang.Length; i++)
                {
                    temp = temp + kh.MaKhachHang[i];
                }
                for (int i = 2; i < tp.MaThue.Length; i++)
                {
                    temp2 = temp2 + tp.MaThue[i];
                }
                kh.MaKhachHang = "KH" + (Int32.Parse(temp) + 1).ToString();
                tp.MaThue = "TP" + (Int32.Parse(temp2) + 1).ToString();
                cn.InsertDeleteUpdate("INSERT INTO KHACHHANG VALUES('" + kh.MaKhachHang + "',N'" + kh.TenKhachHang + "',N'" + ddGioiTinh.selectedValue + "','" + kh.SoCMT + "','" + tbphone.Text + "')");
                cn.InsertDeleteUpdate("INSERT INTO THUEPHONG VALUES('" + tp.MaThue + "','" + kh.MaKhachHang + "','" + p.MaPhong + "','" + year + month + day + "','" + year1 + month1 + day1 + "',1)");
                Notification nf = new Notification("ĐẶT PHÒNG", "Đặt phòng thành công.", "");
                nf.Show();
                transfer = 1;
            }
        }
    }
}
