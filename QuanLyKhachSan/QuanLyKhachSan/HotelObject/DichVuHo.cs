using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.HotelObject
{
    class DichVuHo
    {
        private string m_madv;
        public string MaDichVu
        {
            get { return m_madv; }
            set { m_madv = value; }
        }

        private string m_tendv;
        public string TenDichVu
        {
            get { return m_tendv; }
            set { m_tendv = value; }
        }

        private int m_giatien;
        public int GiaTien
        {
            get { return m_giatien; }
            set { m_giatien = value; }
        }

    }
}
