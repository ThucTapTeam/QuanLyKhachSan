using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.HotelObject
{
    class SuDungDichVuHo
    {
        private string m_MaSD;
        public string MaSuDung
        {
            get { return m_MaSD; }
            set { m_MaSD = value; }
        }

        private string m_mathue;
        public string MaThue
        {
            get { return m_mathue; }
            set { m_mathue = value; }
        }

        private string m_madv;
        public string MaDichVu
        {
            get { return m_madv; }
            set { m_madv = value; }
        }

        private string m_ngaysudung;
        public string NgaySuDung
        {
            get { return m_ngaysudung; }
            set { m_ngaysudung = value; }
        }

        private string m_dongia;
        public string DonGia
        {
            get { return m_dongia; }
            set { m_dongia = value; }
        }
    }
}
