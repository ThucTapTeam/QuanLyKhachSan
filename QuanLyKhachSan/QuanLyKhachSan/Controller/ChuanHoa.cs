using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevComponents.DotNetBar.Controls;

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
        public string CH_Name(TextBoxX tb)
        {
            string temp=null,temp1=null;
            temp = tb.Text.Trim();
            while(temp.IndexOf("  ")>=0)
            {
                temp = temp.Replace("  ", " ");
            }
            temp = temp.ToLower();
            for(int i=0;i<temp.Length;i++)
            {
                if (i == 0)
                {
                    temp1 += temp[i].ToString().ToUpper();
                }
                else
                {
                    if (temp[i] == ' ')
                    {
                        temp1 = temp1 + " " + temp[i+1].ToString().ToUpper();
                        i++;
                    }
                    else
                    {
                        temp1 += temp[i];
                    }
                }
            }
            return temp1;
        }
        public string CH_Space(TextBoxX tb)
        {
            string temp = null;
            temp = tb.Text.Trim();
            while (temp.IndexOf("  ") >= 0)
            {
                temp = temp.Replace("  ", " ");
            }
            return temp;
        }
        /*
        public bool Check_Number(TextBoxX tb)
        {
            bool check = false;
            string temp = null;
            temp = tb.Text;
            return check;
        }*/
    }
}
