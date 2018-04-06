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
        public TrangChuControl()
        {
            InitializeComponent();
            Phong(2);
            RoomColor(2);


        }
        string sophong;
        
        Connection conn = new Connection();
        public string tenphongthue = null;
        public int[] CheckPhong(string[] temp,int tongsophong,int sotang,out int j)
        {
            string[] tenphong = new string[15];
            int[] phongso = new int[15];
            j = 0;
            conn.trangchu(tenphong, "select tenphong from THUEPHONG INNER JOIN PHONG ON NGAYRA>cast(getdate() as date) AND THUEPHONG.MAPHONG=PHONG.MAPHONG and PHONG.SOTANG=" + sotang, 0);
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
        public void RoomColor(int tangso)
        {
            sophong = conn.sophong("select count(TENPHONG) FROM PHONG WHERE SOTANG="+tangso, 0);
            Panel[] pn = new Panel[20];
            int[] phongso = new int[15];
            string[] tenphong = new string[15];
            conn.trangchu(tenphong, "select TENPHONG FROM PHONG WHERE SOTANG=" + tangso, 0);
            int sophongdangthue ;
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
            phongso=CheckPhong(tenphong, Int32.Parse(sophong), tangso,out sophongdangthue);
            for (int i=0;i< Int32.Parse(sophong);i++)
            {
                pn[i].BackColor = Color.FromArgb(149, 165, 166) ;
                pn[i].Cursor = Cursors.Hand;
            }
            for(int i=0;i<sophongdangthue;i++)
            {
                pn[phongso[i]].BackColor = Color.FromArgb(191, 57, 42);
            }
            for(int i= Int32.Parse(sophong); i<=14;i++)
            {
                pn[i].BackColor = Color.White;
                pn[i].Cursor = Cursors.Default;
            }
        }
        private void DDTang_Select(object sender, EventArgs e)
        {
            if(DDTang.selectedValue.ToString()== "Tầng 2 ( Gồm 10 Phòng)")
            {
                Phong(2);
                RoomColor(2);
            }
            else if(DDTang.selectedValue.ToString() == "Tầng 3 ( Gồm 5 Phòng)")
            {
                Phong(3);
                RoomColor(3);
            }
        }
    }
}
