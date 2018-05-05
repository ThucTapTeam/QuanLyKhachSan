using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan.Layout.SubLayout
{
    public partial class FormThemDichVuPhong : Form
    {
        Controller.ThemDVPhongController dvphong = new Controller.ThemDVPhongController();
        public FormThemDichVuPhong()
        {
            InitializeComponent();
            dvphong.LayTenDichVu(ddDichVu);
            dvphong.LayTenPhong(ddsotang, ddtenphong);
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
            this.Close();
        }

        private void mini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bthuy_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        
        private void ddsotang_Selected(object sender, EventArgs e)
        {
            dvphong.LayTenPhong(ddsotang,ddtenphong);
        }

        private void ddtenphong_Selected(object sender, EventArgs e)
        {
            dvphong.LayLoaiPhong(ddtenphong,tenphong,loaiphong);
        }

        private void btthemdichvu_Click(object sender, EventArgs e)
        {
            int transfer;
            if (ddtenphong.selectedIndex!=-1)
            {
                dvphong.ThemDichVu(ddtenphong, ddDichVu, out transfer);
                if (transfer == 1)
                {
                    this.Hide();
                }
            }
            else
            {
                Notification nf = new Notification("LỖI", "Bạn chưa chọn phòng.", "");
                nf.Show();
            }
        }
    }
}
