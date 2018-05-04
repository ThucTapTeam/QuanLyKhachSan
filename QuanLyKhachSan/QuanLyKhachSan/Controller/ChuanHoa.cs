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
        
        public bool Check_SoCMT(TextBoxX tb)
        {
            bool check = false;
            string temp = null;
            temp = tb.Text;
            if (temp.Length == 9 || temp.Length == 12)
            {
                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i] == ' ')
                    {
                        check = false;
                        break;
                    }
                    else
                    {
                        if (Char.IsNumber(temp[i]) == true)
                        {
                            check = true;
                        }
                        else
                        {
                            check = false;
                            break;
                        }
                    }
                }
            }
            return check;
        }
        public bool Check_Text_Name(TextBoxX tb)
        {
            bool check = false;
            string temp = null;
            temp = tb.Text;
            for(int i=0;i<temp.Length;i++)
            {
                if (Char.IsNumber(temp[i]))
                {
                    check = false;
                }
                else
                {
                    check = true;
                }
            }
            return check;
        }
        public bool Check_Phone(TextBoxX tb)
        {
            bool check = false;
            string temp = null;
            temp = tb.Text;
            if (temp.Length == 10 || temp.Length == 11)
            {
                
                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i] == ' ')
                    {
                        check = false;
                        break;
                    }
                    else
                    {
                        if (Char.IsNumber(temp[i]) == true)
                        {
                            check = true;
                        }
                        else
                        {
                            check = false;
                            break;
                        }
                    }
                }
                if (temp.Length == 10)
                {
                    if (temp[0] == '0' && temp[1] == '9') check = true;
                    else check = false;
                }
                else
                {
                    if (temp[0] == '0' && temp[1] == '1') check = true;
                    else check = false;
                }
            }
            return check;
        }

        public bool Check_Number(TextBoxX tb)
        {
            bool check = false;
            string temp = null;
            temp = tb.Text;
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == ' ')
                {
                    check = false;
                    break;
                }
                else
                {
                    if (Char.IsNumber(temp[i]) == true)
                    {
                        check = true;
                    }
                    else
                    {
                        check = false;
                        break;
                    }
                }
            }
            return check;
        }
        public string CH_UpperFirstText(string a)
        {
            string temp = null;
            for (int i = 0; i < a.Length; i++)
            {
                if(i==0)
                {
                    temp += a[i].ToString().ToUpper();
                }
                else
                {
                    temp += a[i];
                }
            }
            return temp;
        }
        public string TongTien(string ngayra,string ngayvao,int giatien)
        {
            DateTime ngayra1 = Convert.ToDateTime(ngayra);
            DateTime ngayvao1 = Convert.ToDateTime(ngayvao);
            TimeSpan a = ngayra1 - ngayvao1;
            int day = a.Days+1;
            int tongtien = day * giatien;
            return tongtien.ToString();
        }
    }
}
