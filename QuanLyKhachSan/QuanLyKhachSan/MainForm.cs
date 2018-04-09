using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class MainForm : Form
    {

        public MainForm(string hoten, string chucvu, string avatar)
        {
            InitializeComponent();
            panelMain.Controls.Clear();
            panelMain.Controls.Add(new Layout.TrangChuControl());
            label1.Text = hoten;
            label2.Text = chucvu;
            pictureBox1.Image = Image.FromFile(avatar);
            if(chucvu!="Quản lý")
            {
                btqlynhanvien.Enabled = false;
                btdoanhthu.Enabled = false;
                btdoanhthu.Cursor = Cursors.Default;
                btqlynhanvien.Cursor = Cursors.Default;
            }
            else
            {
                btqlynhanvien.Enabled = true;
                btdoanhthu.Enabled = true;
                btdoanhthu.Cursor = Cursors.Hand;
                btqlynhanvien.Cursor = Cursors.Hand;
                
            }
        }
        private void close_Hover(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile("../img/Close1.png");
        }

        private void close_Leave(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile("../img/Close.png");
        }

        private void mini_Hover(object sender, EventArgs e)
        {
            pictureBox3.Image = Image.FromFile("../img/Minimize1.png");
        }

        private void mini_Leave(object sender, EventArgs e)
        {
            pictureBox3.Image = Image.FromFile("../img/Minimize.png");
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bttrangchu(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            panelMain.Controls.Add(new Layout.TrangChuControl());
            
        }

        private void btqlnhanvien_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            panelMain.Controls.Add(new Layout.QLNhanVienControl());
        }

        private void btdown_Down(object sender, MouseEventArgs e)
        {
            
        }

        private void btlogout_Click(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm();
            lf.Show();
            this.Hide();
        }

        private void btdichvu_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            panelMain.Controls.Add(new Layout.FormDichVu());
        }

        private void btdoanhthu_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            panelMain.Controls.Add(new Layout.DoanhThuControl());
        }
    }
}
