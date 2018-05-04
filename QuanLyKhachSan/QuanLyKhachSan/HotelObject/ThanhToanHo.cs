using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.HotelObject
{
    class ThanhToanHo
    {
        private string m_mathue;
        public string MaThue
        {
            get { return m_mathue; }
            set { m_mathue = value; }
        }
            
        private string m_thanhtien;
        public string ThanhTien
        {
            get { return m_thanhtien; }
            set { m_thanhtien = value; }
        }

        private string m_ngaythanhtoan;
        public string NgayThanhToan
        {
            get { return m_ngaythanhtoan; }
            set { m_ngaythanhtoan = value; }
        }
    }
}
