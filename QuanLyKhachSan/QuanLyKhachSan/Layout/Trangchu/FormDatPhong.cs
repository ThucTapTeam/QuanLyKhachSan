﻿using System;
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
        string day, month, year,ngaydat;
        string day1,month1, year1,ngaytra;
        private void dpngaytra_Change(object sender, EventArgs e)
        {
            ngaytra= DPNgayTra.Value.ToString();
            ch.ChuanHoaDate(ngaytra, out day1, out month1, out year1);
        }

        private void dpdatphong_Change(object sender, EventArgs e)
        {
            ngaydat = DPNgayDat.Value.ToString();
            ch.ChuanHoaDate(ngaydat, out day, out month, out year);
        }
        private void btdatphong_Click(object sender, EventArgs e)
        {
            ngaytra = DPNgayTra.Value.ToString();
            ch.ChuanHoaDate(ngaytra, out day1, out month1, out year1);
            ngaydat = DPNgayDat.Value.ToString();
            ch.ChuanHoaDate(ngaydat, out day, out month, out year);
            Connection cn = new Connection();
            if (ch.CheckTB(tbhoten.Text, tbsocmt.Text, tbphone.Text)==false)
            {
                Notification nf = new Notification("LỖI", "Thông tin phải được nhập đầy đủ.");
                nf.Show();
            }
            else if(ch.CheckDate(Int32.Parse(day), Int32.Parse(month), Int32.Parse(year), Int32.Parse(day1), Int32.Parse(month1), Int32.Parse(year1))==false)
            {
                Notification nf = new Notification("LỖI", "Ngày đặt phòng và ngày trả phòng không hợp lệ.");
                nf.Show();
            }
            else
            {
                string temp=null,temp2=null;
                string makhachhang=cn.LayBien("select makhachhang from khachhang order by makhachhang asc",0);
                string mathue = cn.LayBien("select mathue from thuephong order by mathue asc", 0);
                string maphong = cn.LayBien("select maphong from phong where tenphong='" + label2.Text + "'",0);
                for(int i=2;i<makhachhang.Length;i++)
                {
                    temp = temp + makhachhang[i];
                }
                for (int i = 2; i < mathue.Length; i++)
                {
                    temp2 = temp2 + mathue[i];
                }
                makhachhang = "KH" + (Int32.Parse(temp) + 1).ToString();
                mathue = "TP" + (Int32.Parse(temp2) + 1).ToString();
                cn.InsertDeleteUpdate("INSERT INTO KHACHHANG VALUES('"+ makhachhang + "',N'" + tbhoten.Text + "',N'" + ddGioiTinh.selectedValue + "','"+tbsocmt.Text+"','" + tbphone.Text + "')");
                cn.InsertDeleteUpdate("INSERT INTO THUEPHONG VALUES('" + mathue + "','" + makhachhang + "','" + maphong + "','" + year + month + day + "','" + year1 + month1 + day1 + "')");
                
                Notification nf = new Notification("ĐẶT PHÒNG", "Đặt phòng thành công.");
                nf.Show();
                this.Hide();
            }
        }
        
        
    }
}
