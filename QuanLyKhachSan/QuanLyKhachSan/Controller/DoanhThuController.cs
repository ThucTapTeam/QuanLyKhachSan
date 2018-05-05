using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bunifu.Framework.UI;
using System.Windows.Forms;

namespace QuanLyKhachSan.Controller
{
    public class DoanhThuController
    {
        ChuanHoa ch = new ChuanHoa();
        HotelObject.ThanhToanHo tt = new HotelObject.ThanhToanHo();
        Connection conn = new Connection();
        string sophong = "0";
        public void DoanhThuTong(BunifuiOSSwitch switchdoanhthu,BunifuDatepicker DPDoanhThu,Label lbdtdatphong,Label lbsophong,Label lbdichvu)
        {
           
            string day, month, year;
           
            if (switchdoanhthu.Value==true)
            {
                ch.ChuanHoaDate(DPDoanhThu.Value.ToString(),out day,out month,out year);
                tt.ThanhTien = conn.LayBien("EXEC PROC_SELECT_TONGTIEN '" + year + month + day + "'",0);
                sophong = conn.LayBien("EXEC PROC_SELECT_SOPHONG '" + year + month + day + "'", 0);
                if (tt.ThanhTien=="")
                {
                    tt.ThanhTien = "0";
                }
                lbdtdatphong.Text = (Int32.Parse(tt.ThanhTien)*1000).ToString();
                lbsophong.Text = sophong;
            }
            else
            {
                tt.ThanhTien = conn.LayBien("EXEC PROC_SELECT_TONGTIEN1", 0);
                sophong = conn.LayBien("EXEC PROC_SELECT_SOPHONG1", 0);
                if (tt.ThanhTien == "")
                {
                    tt.ThanhTien = "0";
                }
                lbdtdatphong.Text = (Int32.Parse(tt.ThanhTien) * 1000).ToString();
                lbsophong.Text = sophong;
            }
        }
        public void DoanhThuTong1(BunifuiOSSwitch switchdoanhthu, BunifuDatepicker DPDoanhThu, Label lbdtdatphong, Label lbsophong,Label lbdichvu)
        {
            string day, month, year;
            if (switchdoanhthu.Value == true)
            {
                ch.ChuanHoaDate(DPDoanhThu.Value.ToString(), out day, out month, out year);
                tt.ThanhTien = conn.LayBien("EXEC PROC_SELECT_TONGTIEN '" + year + month + day + "'", 0);
                sophong = conn.LayBien("EXEC PROC_SELECT_SOPHONG '" + year + month + day + "'", 0);
                if (tt.ThanhTien == "")
                {
                    tt.ThanhTien = "0";
                }
                lbdtdatphong.Text = (Int32.Parse(tt.ThanhTien) * 1000).ToString();
                lbsophong.Text = sophong;
            }
        }
    }
}
