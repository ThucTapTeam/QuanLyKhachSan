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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            
        }
        private const int CS_DROPSHADOW = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                // add the drop shadow flag for automatically drawing 
                // a drop shadow around the form 
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        private void close_Hover(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("../img/Close1.png");
        }

        private void close_Leave(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("../img/Close.png");
        }

        private void mini_Hover(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile("../img/Minimize1.png");
        }

        private void mini_Leave(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile("../img/Minimize.png");
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        private void mini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btlogin_Click(object sender, EventArgs e)
        {
            Connection cn = new Connection();
            string username = tbuser.Text.ToString();
            string password = tbpass.Text.ToString();
            string hoten = null;
            string chucvu = "Chưa có dữ liệu";
            string avatar = "../img/avatar1.jpg";
            if((cn.login(username.ToUpper(),"select MANHANVIEN FROM NHANVIEN", 0))==true && (cn.login(password, "select PASS FROM NHANVIEN", 0)) == true)
            {
                hoten = cn.LayBien("select HOTEN FROM NHANVIEN where MANHANVIEN='"+username +"'", 0);
                chucvu = cn.LayBien("select CHUCVU FROM NHANVIEN where MANHANVIEN='" + username + "'", 0);
                avatar = cn.LayBien("select AVATAR FROM NHANVIEN where MANHANVIEN='" + username + "'", 0);
                MainForm mf = new MainForm(hoten,chucvu,avatar);
                this.Hide();
                mf.Show();
            }
            
        }
    }
}
