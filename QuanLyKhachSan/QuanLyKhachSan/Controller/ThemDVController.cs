using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevComponents.DotNetBar.Controls;

namespace QuanLyKhachSan.Controller
{
    class ThemDVController
    {
        public void ThemDichVu(TextBoxX tbtendv,TextBoxX tbsoluong,TextBoxX tbgiatien)
        {

            ChuanHoa ch = new ChuanHoa();
            Connection conn = new Connection();
            HotelObject.DichVuHo dv = new HotelObject.DichVuHo();
            if(tbtendv.Text.Length==0 || tbsoluong.Text.Length==0 || tbgiatien.Text.Length ==0)
            {
                Notification nf = new Notification("LỖI", "Không được để trống các trường.", "Mời bạn nhập đầy đủ.");
                nf.Show();
            }
            else
            {
                if(ch.Check_Text_Name(tbtendv)==false)
                {
                    Notification nf = new Notification("LỖI", "Tên dịch vụ chứa chữ số.", "Mời bạn nhập lại.");
                    nf.Show();
                }
                else if(ch.Check_Number(tbsoluong)==false)
                {
                    Notification nf = new Notification("LỖI", "Số lượng chỉ được nhập số.", "Mời bạn nhập lại.");
                    nf.Show();
                }
                else if(ch.Check_Number(tbgiatien) == false)
                {
                    Notification nf = new Notification("LỖI", "Gía tiền chỉ được nhập số.", "Mời bạn nhập lại.");
                    nf.Show();
                }
                else
                {
                    dv.TenDichVu = ch.CH_Space(tbtendv);
                    dv.SoLuong = Int32.Parse(tbsoluong.Text);
                    dv.GiaTien = Int32.Parse(tbgiatien.Text);
                    //dv.MaDichVu = conn.LayBien("");
                    //conn.InsertDeleteUpdate("EXEC PROC_INSERT_THEMDV");
                }
            }
        }
    }
}
