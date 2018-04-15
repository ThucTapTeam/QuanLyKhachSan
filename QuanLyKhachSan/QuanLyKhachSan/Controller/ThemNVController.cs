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
        public void ThemNhanVien(TextBoxX tbhoten,BunifuDropdown ddGioiTinh, TextBoxX tbpass, TextBoxX tbphone,BunifuDatepicker DPNgaySinh, BunifuDropdown ddchucvu,string btavtar)
        {
            string manv = null;
            string ngaysinh=null,temp=null;
            ChuanHoa ch = new ChuanHoa();
            ngaysinh = DPNgaySinh.Value.ToString();
            ch.ChuanHoaDate(ngaysinh, out day, out month, out year);
            ngaysinh = year + month + day;
            manv = conn.LayBien("select manhanvien from nhanvien order by manhanvien asc", 0);
            for (int i = 2; i < manv.Length; i++)
            {
                temp = temp + manv[i];
            }
            manv="NV"+ (Int32.Parse(temp) + 1).ToString();
            conn.InsertDeleteUpdate("INSERT INTO NHANVIEN VALUES('"+manv+"','"+tbpass+"','"+tbhoten+"','"+ddchucvu.selectedValue+"','"+ddGioiTinh.selectedValue+"','"+btavtar+"','"+year+month+day+"','"+tbphone+"')");
            Notification nf = new Notification("THÊM NHÂN VIÊN", "Thêm nhân viên thành công.");
            nf.Show();
        }
    }
}
