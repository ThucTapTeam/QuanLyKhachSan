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
        public void ThemDichVu(TextBoxX tbtendv,TextBoxX tbgiatien,out int transfer)
        {
            transfer = 0;
            ChuanHoa ch = new ChuanHoa();
            Connection conn = new Connection();
            HotelObject.DichVuHo dv = new HotelObject.DichVuHo();
            if(tbtendv.Text.Length==0 || tbgiatien.Text.Length ==0)
            {
                Notification nf = new Notification("LỖI", "Không được để trống các trường.", "Mời bạn nhập đầy đủ.");
                nf.Show();
                transfer = 0;
            }
            else
            {
                if(ch.Check_Text_Name(tbtendv)==false)
                {
                    Notification nf = new Notification("LỖI", "Tên dịch vụ chứa chữ số.", "Mời bạn nhập lại.");
                    nf.Show();
                    transfer = 0;
                }
                else if(ch.Check_Number(tbgiatien) == false)
                {
                    Notification nf = new Notification("LỖI", "Gía tiền chỉ được nhập số.", "Mời bạn nhập lại.");
                    nf.Show();
                    transfer = 0;
                }
                else
                {
                    string madichvu = null,temp=null;
                    dv.TenDichVu = ch.CH_Space(tbtendv);
                    dv.GiaTien = Int32.Parse(tbgiatien.Text);
                    dv.TenDichVu = ch.CH_UpperFirstText(dv.TenDichVu);
                    temp = conn.LayBien("EXEC PROC_INSERT_MADICHVU",0);
                    for(int i=2;i<temp.Length;i++)
                    {
                        madichvu +=temp[i];
                    }
                    dv.MaDichVu = "DV" + (Int32.Parse(madichvu) + 1).ToString();
                    conn.InsertDeleteUpdate("EXEC PROC_INSERT_THEMDV '"+dv.MaDichVu+"', N'"+dv.TenDichVu+"','"+dv.GiaTien+"' ");
                    Notification nf = new Notification("THÊM DỊCH VỤ", "Thêm dịch vụ thành công", "");
                    nf.Show();
                    transfer = 1;
                }
            }
        }
    }
}
