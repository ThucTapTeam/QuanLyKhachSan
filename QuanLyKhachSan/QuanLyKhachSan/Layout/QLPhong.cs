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
    public partial class QLPhong : UserControl
    {
        public QLPhong()
        {
            InitializeComponent();
        }

        private void btthemdichvu_Click(object sender, EventArgs e)
        {
            SubLayout.FormThemDichVuPhong ftdvp =new  SubLayout.FormThemDichVuPhong();
            ftdvp.Show();
        }
    }
}
