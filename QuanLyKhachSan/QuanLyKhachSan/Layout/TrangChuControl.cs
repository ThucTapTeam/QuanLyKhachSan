using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan.Layout
{
    public partial class TrangChuControl : UserControl
    {
        int tang;
        public TrangChuControl()
        {
            InitializeComponent();
            Phong(2);
            RoomColor(2);
            tang = 2;
        }
        string sophong;
        
        Connection conn = new Connection();
        public string tenphongthue = null;
        public int[] CheckPhong(string[] temp,string strsql,int tongsophong,int sotang,out int j)
        {
            string[] tenphong = new string[15];
            int[] phongso = new int[15];
            j = 0;
            conn.trangchu(tenphong, strsql, 0);
            for(int i=0;i<tongsophong;i++)
            {
                if(temp[i]==tenphong[j])
                {
                    phongso[j] = i;
                    j++;
                }
            }
            return phongso;
        }
        private void Phong(int sotang)
        {
            sophong = conn.sophong("select count(TENPHONG) FROM PHONG WHERE SOTANG="+sotang, 0);   
            string[] tenphong=new string[15];           
            Label[] lb = new Label[20];
            lb[0] = this.label1;
            lb[1] = this.label2;
            lb[2] = this.label3;
            lb[3] = this.label4;
            lb[4] = this.label5;
            lb[5] = this.label6;
            lb[6] = this.label7;
            lb[7] = this.label8;
            lb[8] = this.label9;
            lb[9] = this.label10;
            lb[10] = this.label11;
            lb[11] = this.label12;
            lb[12] = this.label13;
            lb[13] = this.label14;
            lb[14] = this.label15;
            
            conn.trangchu(tenphong,"select TENPHONG FROM PHONG WHERE SOTANG="+sotang, 0);
            for (int i=0;i<Int32.Parse(sophong);i++)
            {

                lb[i].Text = tenphong[i];
            }
            for(int i= Int32.Parse(sophong);i<=14;i++)
            {
                lb[i].Text = "";
            }

        }
        private int sophongdangthue;
        private int sophongtramuon;
        private int sophongdattruoc;
        private int[] phongso = new int[15];
        private int[] phongtramuon = new int[15];
        private int[] phongdattruoc = new int[15];
        public void RoomColor(int tangso)
        {
            sophong = conn.sophong("select count(TENPHONG) FROM PHONG WHERE SOTANG="+tangso, 0);
            Panel[] pn = new Panel[20];
            string[] tenphong1 = new string[15];
            conn.trangchu(tenphong1, "select TENPHONG FROM PHONG WHERE SOTANG=" + tangso, 0);
           
            pn[0] = this.panel1;
            pn[1] = this.panel2;
            pn[2] = this.panel3;
            pn[3] = this.panel4;
            pn[4] = this.panel5;
            pn[5] = this.panel6;
            pn[6] = this.panel7;
            pn[7] = this.panel8;
            pn[8] = this.panel9;
            pn[9] = this.panel10;
            pn[10] = this.panel11;
            pn[11] = this.panel12;
            pn[12] = this.panel13;
            pn[13] = this.panel14;
            pn[14] = this.panel15;
            phongso=CheckPhong(tenphong1, "select tenphong from THUEPHONG INNER JOIN PHONG ON NGAYRA>cast(getdate() as date) AND THUEPHONG.MAPHONG=PHONG.MAPHONG and PHONG.SOTANG=" + tangso + "order by tenphong", Int32.Parse(sophong), tangso,out sophongdangthue);
            phongtramuon = CheckPhong(tenphong1, "SELECT TENPHONG FROM THUEPHONG INNER JOIN PHONG ON THUEPHONG.MAPHONG=PHONG.MAPHONG AND THUEPHONG.NGAYRA<CAST(GETDATE() AS DATE) AND PHONG.SOTANG=" + tangso + " order by tenphong", Int32.Parse(sophong), tangso, out sophongtramuon);
            phongdattruoc=CheckPhong(tenphong1, "SELECT TENPHONG FROM THUEPHONG INNER JOIN PHONG ON THUEPHONG.MAPHONG=PHONG.MAPHONG AND THUEPHONG.NGAYVAO>CAST(GETDATE() AS DATE) AND PHONG.SOTANG="+tangso+" order by tenphong", Int32.Parse(sophong), tangso, out sophongdattruoc);
            for (int i=0;i< Int32.Parse(sophong);i++)
            {
                pn[i].BackColor = Color.FromArgb(149, 165, 166) ;
                pn[i].Cursor = Cursors.Hand;          
            }
            for(int i=0;i<sophongdangthue;i++)
            {
                pn[phongso[i]].BackColor = Color.FromArgb(191, 57, 42);
            }
            for(int i=0;i<sophongtramuon;i++)
            {
                pn[phongtramuon[i]].BackColor = Color.FromArgb(230, 126, 34);
            }
            for (int i = 0; i < sophongdattruoc; i++)
            {
                pn[phongdattruoc[i]].BackColor = Color.FromArgb(41, 128, 185);
            }
            for (int i= Int32.Parse(sophong); i<=14;i++)
            {
                pn[i].BackColor = Color.White;
                pn[i].Cursor = Cursors.Default;
            }
        }
        public string laytenphong=null;
        private void Tang(int temp,int a)
        {
            string tenphong2 = null;
            string tenphong3 = null;
            string tenphong4 = null;
            string tenphong5 = null;
            string ghepmaphong = "P"+temp.ToString() + "0" + a.ToString();
            tenphong2=conn.LayBien( "select tenphong from THUEPHONG INNER JOIN PHONG ON NGAYRA>cast(getdate() as date) AND THUEPHONG.MAPHONG=PHONG.MAPHONG and PHONG.SOTANG="+temp+" and phong.MAPHONG='"+ghepmaphong+"'", 0);
            tenphong3=conn.LayBien("select tenphong from THUEPHONG RIGHT JOIN PHONG ON THUEPHONG.MAPHONG=PHONG.MAPHONG  WHERE THUEPHONG.MAPHONG is null and PHONG.SOTANG="+temp+ " and phong.MAPHONG='" + ghepmaphong + "'", 0);
            tenphong4 = conn.LayBien("SELECT TENPHONG FROM THUEPHONG INNER JOIN PHONG ON THUEPHONG.MAPHONG=PHONG.MAPHONG AND THUEPHONG.NGAYRA<CAST(GETDATE() AS DATE) AND PHONG.SOTANG=" + temp + "  and phong.MAPHONG='" + ghepmaphong + "'", 0);
            tenphong5 = conn.LayBien("SELECT TENPHONG FROM THUEPHONG INNER JOIN PHONG ON THUEPHONG.MAPHONG=PHONG.MAPHONG AND THUEPHONG.NGAYVAO>CAST(GETDATE() AS DATE) AND PHONG.SOTANG=" + temp + " and phong.MAPHONG='" + ghepmaphong + "'", 0);
            if (tenphong2!=null)
            {
                btdattraphong.Text = "Trả Phòng";
                btdattraphong.Cursor = Cursors.Hand;
                //label16.Text = "phong dang o";
                laytenphong = tenphong2;
                tang = temp;
            }
            if(tenphong3!=null)
            {
                btdattraphong.Text = "Đặt Phòng";
                btdattraphong.Cursor = Cursors.Default;
                FormDatPhong dp = new FormDatPhong(tenphong3,temp.ToString());
                //FormDatPhong dp = new FormDatPhong();
                dp.Show();
            }
            if(tenphong4!=null)
            {
                //label16.Text = "phong dang tra muon";
                btdattraphong.Text = "Trả Phòng";
                btdattraphong.Cursor = Cursors.Hand;
                laytenphong = tenphong4;
               tang = temp;
            }
            if(tenphong5!=null)
            {
                // label16.Text = "phong dang dat coc";
                btdattraphong.Text = "Trả Phòng";
                btdattraphong.Cursor = Cursors.Hand;
                laytenphong = tenphong5;
                tang = temp;
            }
           
        }
        private void DDTang_Select(object sender, EventArgs e)
        {
            if(DDTang.selectedValue.ToString()== "Tầng 2 ( Gồm 10 Phòng)")
            {
                Phong(2);
                RoomColor(2);
                tang = 2;
            }
            else if(DDTang.selectedValue.ToString() == "Tầng 3 ( Gồm 5 Phòng)")
            {
                Phong(3);
                RoomColor(3);
                tang = 3;
            }
        }
        private void EventKTTang(int a)
        {
            if(tang==2)
            {
                Tang(2,a);
            }
            else if(tang==3)
            {
                Tang(3,a);
            }
        }

        private void lb1(object sender, EventArgs e)
        {
            EventKTTang(1);
        }
        private void lb2(object sender, EventArgs e)
        {
            EventKTTang(2);
        }
        private void lb3(object sender, EventArgs e)
        {
            EventKTTang(3);
        }
        private void lb4(object sender, EventArgs e)
        {
            EventKTTang(4);
        }
        private void lb5(object sender, EventArgs e)
        {
            EventKTTang(5);
        }
        private void lb6(object sender, EventArgs e)
        {
            EventKTTang(6);
        }
        private void lb7(object sender, EventArgs e)
        {
            EventKTTang(7);
        }
        private void lb8(object sender, EventArgs e)
        {
            EventKTTang(8);
        }
        private void lb9(object sender, EventArgs e)
        {
            EventKTTang(9);
        }
        private void lb10(object sender, EventArgs e)
        {
            EventKTTang(10);
        }
        private void lb11(object sender, EventArgs e)
        {
            EventKTTang(11);
        }
        private void lb12(object sender, EventArgs e)
        {
            EventKTTang(12);
        }
        private void lb13(object sender, EventArgs e)
        {
            EventKTTang(13);
        }
        private void lb14(object sender, EventArgs e)
        {
            EventKTTang(14);
        }
        private void lb15(object sender, EventArgs e)
        {
            EventKTTang(15);
        }

        private void btdattraphong_Click(object sender, EventArgs e)
        {
            conn.InsertDeleteUpdate("delete from thuephong where maphong in (select maphong from phong where tenphong= '" + laytenphong + "')", 0);
            Phong(tang);
            RoomColor(tang);
        }
    }
}
