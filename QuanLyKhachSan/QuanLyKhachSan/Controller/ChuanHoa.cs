using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan
{
    class ChuanHoa
    {
        public void ChuanHoaDate(string ngaydat, out string day, out string month, out string year)
        {
            day = null; month = null; year = null;
            string temp = null;
            int tam = 1;
            for (int i = 0; i < ngaydat.Length; i++)
            {
                if (ngaydat[i] == ' ')
                {
                    ngaydat = temp;
                    break;
                }
                else
                {
                    temp = temp + ngaydat[i];
                }
            }
            for (int i = 0; i < ngaydat.Length; i++)
            {
                if (ngaydat[i] != 47)
                {
                    if (tam == 1)
                    {
                        month = month + ngaydat[i];
                    }
                    else if (tam == 2) day = day + ngaydat[i];
                    else if (tam == 3) year = year + ngaydat[i];
                }
                else
                {
                    tam++;
                }
            }
            if (day.Length == 1)
            {
                day = "0" + day;
            }
            if (month.Length == 1)
            {
                month = "0" + month;
            }
        }
        public bool CheckTB(string a,string c,string d)
        {
            bool check = false;
            if(a.Length!=0 ||c.Length!=0 || d.Length!=0)
            {
                check = true;
            }

            return check;
        }
        public bool CheckDate(int day1,int month1,int year1,int day2,int month2,int year2)
        {
            bool temp = false;
            if(year1 <= year2)
            {
                if(month1<=month2)
                {
                    if(day1<=day2)
                    {
                        temp = true;
                    }
                }
            }
            return temp;
        }
    }
}
