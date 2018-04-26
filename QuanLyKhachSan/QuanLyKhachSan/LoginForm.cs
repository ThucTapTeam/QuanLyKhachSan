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
            HotelObject.NhanVienHo nv =new HotelObject.NhanVienHo();
            Connection cn = new Connection();
            nv.MaNhanVien = tbuser.Text.ToString();
            nv.MatKhau = tbpass.Text.ToString();
            nv.HoTen = null;
            nv.ChucVu = "Chưa có dữ liệu";
            nv.Avatar = "../img/avatar1.jpg";
            if((cn.login(nv.MaNhanVien.ToUpper(), "EXEC PROC_SELECT_MANHANVIEN ", 0))==true && (cn.login(nv.MatKhau, "select PASS FROM NHANVIEN", 0)) == true)
            {
                nv.HoTen = cn.LayBien("EXEC PROC_SELECT_HOTEN '" + nv.MaNhanVien + "'", 0);
                nv.ChucVu = cn.LayBien("EXEC PROC_SELECT_CHUCVU'" + nv.MaNhanVien + "'", 0);
                nv.Avatar = cn.LayBien("EXEC PROC_SELECT_AVATAR '" + nv.MaNhanVien + "'", 0);
                MainForm mf = new MainForm(nv.HoTen, nv.ChucVu, nv.Avatar);
                this.Hide();
                mf.Show();
            }
            else
            {
                Notification nf = new Notification("ĐĂNG NHẬP","Mật khẩu và tài khoản không hợp lệ.","");
                nf.Show();
            }
        }
    }
}
