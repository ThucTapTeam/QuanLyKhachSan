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
    public partial class FormDichVu : UserControl
    {
        public FormDichVu()
        {
            InitializeComponent();
        }

        private void bthemdichvu(object sender, EventArgs e)
        {
            SubLayout.FormThemDichVu ftdv = new SubLayout.FormThemDichVu();
            ftdv.Show();
        }
    }
}
