using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.HotelObject
{
    public class PhongHo
    {
        private string m_MaPhong;
        public string MaPhong
        {
            get { return m_MaPhong; }
            set { m_MaPhong = value; }
        }

        private string m_TenPhong;
        public string TenPhong
        {
            get { return m_TenPhong; }
            set { m_TenPhong = value; }
        }

        private int m_MaLoai;
        public int MaLoai
        {
            get { return m_MaLoai; }
            set { m_MaLoai = value; }
        }

        private int m_GiaThue;
        public int GiaThue
        {
            get { return m_GiaThue; }
            set { m_GiaThue = value; }
        }

        private int m_SoTang;
        public int SoTang
        {
            get { return m_SoTang; }
            set { m_SoTang = value; }
        }
    }
}
