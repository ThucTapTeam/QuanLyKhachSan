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
    public partial class FormDatPhong : Form
    {
        public FormDatPhong(string sophong, string tangso)
        {
            
            InitializeComponent();
            label2.Text = sophong;
            label8.Text = "Tầng " + tangso;
            DPNgayDat.Value = DateTime.Now;
            DPNgayTra.Value = DateTime.Now;
        }
        ChuanHoa ch = new ChuanHoa();
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
        private void dpngaytra_Change(object sender, EventArgs e)
        {
            
        }

        private void dpdatphong_Change(object sender, EventArgs e)
        {
        }
        private void btdatphong_Click(object sender, EventArgs e)
        {
            int transfer;
            Controller.DatPhongController dpc = new Controller.DatPhongController();
            dpc.DatPhong(tbhoten,ddGioiTinh,tbsocmt,tbphone,DPNgayDat,DPNgayTra,label2,label8,out transfer);
            if(transfer==1)
            {
                this.Hide();
            }
        }
        
        
    }
}
