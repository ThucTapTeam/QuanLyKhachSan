using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bunifu.Framework.UI;
using System.Windows.Forms;

namespace QuanLyKhachSan.Controller
{
    class ThemDVPhongController
    {
        Connection conn = new Connection();
        public void LayTenPhong(BunifuDropdown ddsotang,BunifuDropdown ddtenphong)
        {
            string[] tenphong = new string[15];
            int m;
            conn.LayMangSql(tenphong, "EXEC PRO_SELECT_TENPHONG1 " + ddsotang.selectedValue,out m, 0);
            ddtenphong.Clear();
            for (int i=0;i<m;i++)
            {
                ddtenphong.AddItem(tenphong[i]);
            }
            if (m != 0)
            {
                ddtenphong.selectedIndex = 0;
            }
            
        }
        public void LayLoaiPhong(BunifuDropdown ddtenphong,Label tenphong,Label loaiphong)
        {
            
            tenphong.Text = ddtenphong.selectedValue;
            loaiphong.Text = conn.LayBien("EXEC PROC_SELECT_MALOAIPHONG N'" + tenphong.Text + "'", 0);
        }
        public void LayTenDichVu(BunifuDropdown ddDichVu)
        {
            int n;
            string[] tendichvu = new string[100];
            conn.LayMangSql(tendichvu, "EXEC PROC_SELECT_TENDICHVU",out n, 0);
            ddDichVu.Clear();
            for( int i=0;i<n;i++)
            {
                ddDichVu.AddItem(tendichvu[i]);
            }
            ddDichVu.selectedIndex = 0;
        }
        public void ThemDichVu(BunifuDropdown ddtenphong,BunifuDropdown ddDichVu,out int transfer)
        {
            transfer = 0;
            HotelObject.ThuePhongHo tp = new HotelObject.ThuePhongHo();
            string temp2 = null;
            tp.MaThue = conn.LayBien("EXEC PROC_SELECT_MASD", 0);
            for (int i = 2; i < tp.MaThue.Length; i++)
            {
                temp2 = temp2 + tp.MaThue[i];
            }
            tp.MaThue = "SD" + (Int32.Parse(temp2) + 1).ToString();

            conn.InsertDeleteUpdate("EXEC PROC_SELECT_THEMDICHVU N'" + ddtenphong.selectedValue + "','" + tp.MaThue + "',N'" + ddDichVu.selectedValue + "','" + DateTime.Now + "' ");
            Notification nf = new Notification("DỊCH VỤ", "Thêm dịch vụ thành công.", "");
            nf.Show();
            transfer = 1;
        }
    }
}
