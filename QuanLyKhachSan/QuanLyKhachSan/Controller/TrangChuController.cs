using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Bunifu.Framework.UI;

namespace QuanLyKhachSan.Controller
{
    public class TrangChuController
    {
        Connection conn = new Connection();
        public string sophong = null;
        private int[] phongso = new int[15];
        private int[] phongtramuon = new int[15];
        private int[] phongdattruoc = new int[15];
        private int sophongdangthue;
        private int sophongtramuon;
        private int sophongdattruoc;
        public int[] CheckPhong(string[] temp, string strsql, int tongsophong, int sotang, out int j)
        {
            string[] tenphong = new string[15];
            int[] phongso = new int[15];
            j = 0;
            conn.trangchu(tenphong, strsql, 0);
            for (int i = 0; i < tongsophong; i++)
            {
                if (temp[i] == tenphong[j])
                {
                    phongso[j] = i;
                    j++;
                }
            }
            return phongso;
        }
        public void RoomColor(Panel panel1, Panel panel2, Panel panel3, Panel panel4, Panel panel5, Panel panel6, Panel panel7, Panel panel8, Panel panel9, Panel panel10, Panel panel11, Panel panel12, Panel panel13, Panel panel14, Panel panel15, int tangso)
        {
            
            sophong = conn.sophong("EXEC PRO_SELECT_SOPHONG " + tangso, 0);
            Panel[] pn = new Panel[20];
            string[] tenphong1 = new string[15];
            conn.trangchu(tenphong1, "EXEC PRO_SELECT_TENPHONG " + tangso, 0);

            pn[0] = panel1;
            pn[1] = panel2;
            pn[2] =panel3;
            pn[3] = panel4;
            pn[4] = panel5;
            pn[5] = panel6;
            pn[6] = panel7;
            pn[7] = panel8;
            pn[8] = panel9;
            pn[9] = panel10;
            pn[10] = panel11;
            pn[11] = panel12;
            pn[12] = panel13;
            pn[13] = panel14;
            pn[14] = panel15;
            phongso = CheckPhong(tenphong1, "EXEC PROC_SELECT_PHONGDANGTHUE "+tangso, Int32.Parse(sophong), tangso, out sophongdangthue);
            phongtramuon = CheckPhong(tenphong1, "EXEC PROC_SELECT_PHONGTHUEMUON "+tangso, Int32.Parse(sophong), tangso, out sophongtramuon);
            phongdattruoc = CheckPhong(tenphong1, "EXEC PROC_SELECT_PHONGDATTRUOC "+tangso, Int32.Parse(sophong), tangso, out sophongdattruoc);
            for (int i = 0; i < Int32.Parse(sophong); i++)
            {
                pn[i].BackColor = Color.FromArgb(149, 165, 166);
                pn[i].Cursor = Cursors.Hand;
            }
            for (int i = 0; i < sophongdangthue; i++)
            {
                pn[phongso[i]].BackColor = Color.FromArgb(191, 57, 42);
            }
            for (int i = 0; i < sophongtramuon; i++)
            {
                pn[phongtramuon[i]].BackColor = Color.FromArgb(230, 126, 34);
            }
            for (int i = 0; i < sophongdattruoc; i++)
            {
                pn[phongdattruoc[i]].BackColor = Color.FromArgb(41, 128, 185);
            }
            for (int i = Int32.Parse(sophong); i <= 14; i++)
            {
                pn[i].BackColor = Color.White;
                pn[i].Cursor = Cursors.Default;
            }
        }
        public void Phong(Label label1, Label label2, Label label3, Label label4, Label label5, Label label6, Label label7, Label label8, Label label9, Label label10, Label label11, Label label12, Label label13, Label label14, Label label15, int sotang)
        {
            sophong = conn.sophong("EXEC PRO_SELECT_SOPHONG " + sotang, 0);
            string[] tenphong = new string[15];
            Label[] lb = new Label[20];
            lb[0] = label1;
            lb[1] =label2;
            lb[2] = label3;
            lb[3] = label4;
            lb[4] = label5;
            lb[5] = label6;
            lb[6] = label7;
            lb[7] = label8;
            lb[8] = label9;
            lb[9] = label10;
            lb[10] =label11;
            lb[11] = label12;
            lb[12] = label13;
            lb[13] = label14;
            lb[14] = label15;

            conn.trangchu(tenphong, "EXEC PRO_SELECT_TENPHONG " + sotang, 0);
            for (int i = 0; i < Int32.Parse(sophong); i++)
            {

                lb[i].Text = tenphong[i];
            }
            for (int i = Int32.Parse(sophong); i <= 14; i++)
            {
                lb[i].Text = "";
            }

        }
        public void Tang(int temp, int a,out string laytenphong, BunifuFlatButton btdattraphong)
        {
            string ghepmaphong;
            laytenphong = null;
            HotelObject.PhongHo p = new HotelObject.PhongHo();
            HotelObject.PhongHo p1 = new HotelObject.PhongHo();
            HotelObject.PhongHo p2 = new HotelObject.PhongHo();
            HotelObject.PhongHo p3 = new HotelObject.PhongHo();
            p.TenPhong = null;
            p1.TenPhong = null;
            p2.TenPhong = null;
            p3.TenPhong = null;
            if (a.ToString().Length == 1)
            {
                ghepmaphong = "P" + temp.ToString() + "0" + a.ToString();
            }
            else
            {
                ghepmaphong = "P" + temp.ToString() + a.ToString();
            }
            p.TenPhong = conn.LayBien("EXEC PROC_SELECT_PHONGDANGO1 "+temp+",'"+ghepmaphong+"'", 0);
            p1.TenPhong = conn.LayBien("EXEC PROC_SELECT_PHONGDANGTHUE1 "+temp+", '"+ghepmaphong+"'", 0);
            p2.TenPhong = conn.LayBien("EXEC PROC_SELECT_PHONGTRAMUON1 "+temp+",'"+ghepmaphong+"'", 0);
            p3.TenPhong = conn.LayBien("EXEC PROC_SELECT_PHONGDATCOCTRUOC1 "+temp+",'"+ghepmaphong+"'", 0);
            if (p.TenPhong != null)
            {
                btdattraphong.Text = "Trả Phòng";
                btdattraphong.Cursor = Cursors.Hand;
                //label16.Text = "phong dang o";
                laytenphong = p.TenPhong;
                
            }
            if (p1.TenPhong != null)
            {
                btdattraphong.Text = "Đặt Phòng";
                btdattraphong.Cursor = Cursors.Default;
                FormDatPhong dp = new FormDatPhong(p1.TenPhong, temp.ToString());
                dp.Show();

            }
            if (p2.TenPhong != null)
            {
                //label16.Text = "phong dang tra muon";
                btdattraphong.Text = "Trả Phòng";
                btdattraphong.Cursor = Cursors.Hand;
                laytenphong = p2.TenPhong;
            }
            if (p3.TenPhong != null)
            {
                // label16.Text = "phong dang dat coc";
                btdattraphong.Text = "Trả Phòng";
                btdattraphong.Cursor = Cursors.Hand;
                laytenphong = p3.TenPhong;
            }

        }
    }
}
