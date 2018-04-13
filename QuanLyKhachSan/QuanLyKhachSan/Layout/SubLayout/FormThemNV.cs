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
    public partial class FormThemNV : Form
    {
        public FormThemNV()
        {
            InitializeComponent();
        }

        private void btchonanh_Click(object sender, EventArgs e)
        {
            fileAvatar.ShowDialog();


        }
    }
}
