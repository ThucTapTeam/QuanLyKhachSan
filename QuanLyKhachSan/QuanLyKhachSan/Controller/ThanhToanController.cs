using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;

namespace QuanLyKhachSan.Controller
{
    public class ThanhToanController
    {
        Connection conn = new Connection();
        ChuanHoa ch = new ChuanHoa();
        public void ThanhToan(Label lbtenphong,Label lbhoten,Label lbloaiphong,Label lbngayvao,Label lbngayra,Label lbthanhtien)
        {
            HotelObject.ThanhToanHo tt = new HotelObject.ThanhToanHo();
            HotelObject.ThuePhongHo tp = new HotelObject.ThuePhongHo();
            string year, month, day,ngayvao=null;
            string year1, month1, day1, ngayra = null;
            string yearnow, monthnow, daynow;
            lbhoten.Text = conn.LayBien("EXEC PROC_SELECT_TENKHACHHANG N'" + lbtenphong.Text + "'", 0);
            lbloaiphong.Text = conn.LayBien("EXEC PROC_SELECT_LOAIPHONG N'" + lbtenphong.Text + "'", 0);
            tp.NgayVao = conn.LayBien("EXEC PROC_SELECT_NGAYVAO N'"+lbtenphong.Text+"'",0);
            tp.NgayRa = conn.LayBien("EXEC PROC_SELECT_NGAYRA N'" + lbtenphong.Text + "'", 0);
            tp.MaThue = conn.LayBien("EXEC PROC_SELECT_MATHUE N'" + lbtenphong.Text + "'", 0);
            ch.ChuanHoaDate(tp.NgayRa, out day,out month,out year); 
            ch.ChuanHoaDate(tp.NgayVao, out day1, out month1, out year1);
            ch.ChuanHoaDate(DateTime.Now.ToString(), out daynow, out monthnow, out yearnow);
            lbngayvao.Text = day + " / " + month + " / " + year;
            lbngayra.Text = day1 + " / " + month1 + " / " + year1;
            string giatien = conn.LayBien("EXEC PROC_SELECT_GIATIEN N'" + lbtenphong.Text + "'",0);
            string tongtientt=ch.TongTien(ngayra, ngayvao, Int32.Parse(giatien));

            TimeSpan time = DateTime.Parse(tp.NgayRa) - DateTime.Parse(tp.NgayVao);
            int dayz = time.Days+1;
            lbthanhtien.Text = (Int32.Parse(tongtientt) *dayz *1000).ToString();
            conn.InsertDeleteUpdate("EXEC PROC_INSERT_THANHTOAN '"+tp.MaThue+"','"+giatien+"','"+yearnow+monthnow+daynow+"'");
        }
    }
}
