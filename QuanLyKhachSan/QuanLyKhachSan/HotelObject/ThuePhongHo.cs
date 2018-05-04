using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.HotelObject
{
    public class ThuePhongHo
    {
        private string m_mathue;
        public string MaThue
        {
            get{ return m_mathue; }
            set { m_mathue = value; }
        }

        private string m_makhachhang;
        public string MaKhacHhang
        {
            get { return m_makhachhang; }
            set { m_makhachhang = value; }
        }

        private string m_maphong;
        public string MaPhong
        {
            get { return m_maphong; }
            set { m_maphong = value; }
        }

        private string m_ngayvao;
        public string NgayVao
        {
            get { return m_ngayvao; }
            set { m_ngayvao = value; }
        }

        private string m_ngayra;
        public string NgayRa
        {
            get { return m_ngayra; }
            set { m_ngayra = value; }
        }

        private string m_trangthai;
        public string TrangThai
        {
            get { return m_trangthai; }
            set { m_trangthai = value; }
        }
    }
}
