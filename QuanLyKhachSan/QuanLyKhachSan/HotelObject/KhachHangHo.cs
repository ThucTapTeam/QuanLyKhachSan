using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.HotelObject
{
    public class KhachHangHo
    {
        private string m_MaKhachHang;
        public string MaKhachHang
        {
            get { return m_MaKhachHang; }
            set { m_MaKhachHang = value; }
        }
        private string m_TenKhachHang;
        public string TenKhachHang
        {
            get { return m_TenKhachHang; }
            set { m_TenKhachHang = value; }
        }
        private string m_GioiTinh;
        public string GioiTinh
        {
            get { return m_GioiTinh; }
            set { m_GioiTinh = value; }
        }
        private string m_SoCMT;
        public string SoCMT
        {
            get { return m_SoCMT; }
            set { m_SoCMT = value; }
        }
        private string m_Phone;
        public string Phone
        {
            get { return m_Phone; }
            set { m_Phone = value; }
        }
    }
}
