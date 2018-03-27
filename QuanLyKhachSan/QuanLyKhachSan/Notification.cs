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
    public partial class Notification : Form
    {
        public Notification()
        {
            InitializeComponent();
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
    }
}
