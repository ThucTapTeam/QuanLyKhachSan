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
    public partial class QLNhanVienControl : UserControl
    {
        public QLNhanVienControl()
        {
            InitializeComponent();
        }


        private void btthemnv_Click(object sender, EventArgs e)
        {
            SubLayout.FormThemNV themNV = new SubLayout.FormThemNV();
            themNV.Show();
        }
    }
}
