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
        Controller.TrangChuController tcc = new Controller.TrangChuController();
        Connection conn = new Connection();
        int tang;
        string laytenphong;
        public TrangChuControl()
        {
            InitializeComponent();
            tcc.Phong(label1, label2, label3, label4, label5, label6, label7, label8, label9, label10, label11, label12, label13, label14, label15, 2);
            tcc.RoomColor(panel1,panel2, panel3, panel4, panel5, panel6, panel7, panel8, panel9, panel10, panel11, panel12, panel13, panel14, panel15, 2);
            tang = 2;
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
        private void Display(int tang)
        {
            tcc.Phong(label1, label2, label3, label4, label5, label6, label7, label8, label9, label10, label11, label12, label13, label14, label15, tang);
            tcc.RoomColor(panel1, panel2, panel3, panel4, panel5, panel6, panel7, panel8, panel9, panel10, panel11, panel12, panel13, panel14, panel15, tang);

        }
        private void DDTang_Select(object sender, EventArgs e)
        {
            if(DDTang.selectedValue.ToString()== "Tầng 2")
            {
                Display(2);
                tang = 2;
            }
            else if(DDTang.selectedValue.ToString() == "Tầng 3")
            {
                Display(3);
                tang = 3;
            }
            else if (DDTang.selectedValue.ToString() == "Tầng 4")
            {
                Display(4);
                tang = 4;
            }
            else if (DDTang.selectedValue.ToString() == "Tầng 5")
            {
                Display(5);
                tang = 5;
            }
        }
        private void EventKTTang(int a)
        {
            if(tang==2)
            {
                tcc.Tang(2,a,out laytenphong,btdattraphong);
            }
            else if(tang==3)
            {
                tcc.Tang(3,a,out laytenphong,btdattraphong);
            }
            else if (tang == 4)
            {
                tcc.Tang(4, a, out laytenphong, btdattraphong);
            }
            else if (tang == 5)
            {
                tcc.Tang(5, a, out laytenphong, btdattraphong);
            }
        }

        private void btdattraphong_Click(object sender, EventArgs e)
        {
            if (btdattraphong.Text == "Trả Phòng")
            {
                SubLayout.FormThanhToan ftt = new SubLayout.FormThanhToan(laytenphong, tang);
                ftt.Show();
                conn.InsertDeleteUpdate("UPDATE THUEPHONG SET TRANGTHAI=0 WHERE MAPHONG IN (SELECT MAPHONG FROM PHONG WHERE TENPHONG='" + laytenphong + "')");
                tcc.Phong(label1, label2, label3, label4, label5, label6, label7, label8, label9, label10, label11, label12, label13, label14, label15, tang);
                tcc.RoomColor(panel1, panel2, panel3, panel4, panel5, panel6, panel7, panel8, panel9, panel10, panel11, panel12, panel13, panel14, panel15, tang);
            }
        }

        private void btlammoi_Click(object sender, EventArgs e)
        {
            tcc.Phong(label1, label2, label3, label4, label5, label6, label7, label8, label9, label10, label11, label12, label13, label14, label15, tang);
            tcc.RoomColor(panel1, panel2, panel3, panel4, panel5, panel6, panel7, panel8, panel9, panel10, panel11, panel12, panel13, panel14, panel15, tang);
        }
    }
}
