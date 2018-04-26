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
            conn.LayMangSql(tenphong, "EXEC PRO_SELECT_TENPHONG " + ddsotang.selectedValue,out m, 0);
            ddtenphong.Clear();
            for (int i=0;i<m;i++)
            {
                ddtenphong.AddItem(tenphong[i]);
            }
            ddtenphong.selectedIndex = 0;
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
    }
}
