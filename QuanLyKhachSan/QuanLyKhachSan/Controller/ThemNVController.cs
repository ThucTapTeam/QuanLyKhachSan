
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using DevComponents.DotNetBar.Controls;

namespace QuanLyKhachSan.Controller
{
    public class ThemNVController
    {
        string day, month, year;
        Connection conn = new Connection();
        public void ThemNhanVien(TextBoxX tbhoten,BunifuDropdown ddGioiTinh, TextBoxX tbpass, TextBoxX tbphone,BunifuDatepicker DPNgaySinh, BunifuDropdown ddchucvu,string btavtar,out int transfer)
        {
            transfer = 0;
            HotelObject.NhanVienHo nv = new HotelObject.NhanVienHo(); 
            string temp=null;
            ChuanHoa ch = new ChuanHoa();
            nv.NgaySinh= DPNgaySinh.Value.ToString();
            ch.ChuanHoaDate(nv.NgaySinh, out day, out month, out year);
            nv.NgaySinh = year + month + day;
            nv.MaNhanVien = conn.LayBien("EXEC PROC_SELECT_MANHANVIEN", 0);
            for (int i = 2; i < nv.NgaySinh.Length; i++)
            {
                temp = temp + nv.NgaySinh[i];
            }
            nv.NgaySinh = "NV"+ (Int32.Parse(temp) + 1).ToString();
            nv.HoTen = ch.CH_Name(tbhoten);
            if(ch.Check_Phone(tbphone)==false)
            {
                Notification nf = new Notification("LỖI", "Số điện thoại không hợp lệ", "Mời bạn nhập lại.");
                nf.Show();
                transfer = 0;
            }
            else if(ch.Check_Text_Name(tbhoten)==false)
            {
                Notification nf = new Notification("LỖI", "Tên nhập chứa chữ số", "Mời bạn nhập lại.");
                nf.Show();
                transfer = 0;
            }
            else
            {
                conn.InsertDeleteUpdate("EXEC PROC_INSERT_NHANVIEN '" + nv.MaNhanVien + "','" + tbpass.Text + "',N'" + tbhoten.Text + "',N'" + ddchucvu.selectedValue + "',N'" + ddGioiTinh.selectedValue + "','" + btavtar + "','" + year + month + day + "','" + tbphone.Text + "'");
                Notification nf = new Notification("THÊM NHÂN VIÊN", "Thêm nhân viên thành công.", "Mã nhân viên :" + nv.MaNhanVien);
                nf.Show();
                transfer = 1;
            }
            
        }
    }
}
