using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyKhachSan
{
    class Connection
    {
        string conn = "Data Source=DESKTOP-SSCJKUR;Initial Catalog=QLKS;Integrated Security=True";
        SqlConnection sqlconn;
        SqlCommand sqlcom;
        SqlDataAdapter sqldataa;
        SqlDataReader sqldatar;
        DataSet ds = new DataSet();
        public void ketnoi()
        {
            sqlconn = new SqlConnection(conn);
            sqlconn.Open();
        }
        public void ngatketnoi()
        {
            sqlconn.Close();
        }
        public void trangchu(string[] temp ,string strsql,int cot)
        {
            int i = 0;
            ketnoi();
            sqlcom = new SqlCommand(strsql, sqlconn);
            sqldatar = sqlcom.ExecuteReader();
            while(sqldatar.Read())
            {
                temp[i] = sqldatar[cot].ToString();
                i++;
            }
            ngatketnoi();
        }
        public void LayMangSql(string[] temp, string strsql,out int i, int cot)
        {
            i = 0;
            ketnoi();
            sqlcom = new SqlCommand(strsql, sqlconn);
            sqldatar = sqlcom.ExecuteReader();
            while (sqldatar.Read())
            {
                temp[i] = sqldatar[cot].ToString();
                i++;
            }
            ngatketnoi();
        }
        public string LayBien( string strsql, int cot)
        {
            ketnoi();
            string temp = null;
            sqlcom = new SqlCommand(strsql, sqlconn);
            sqldatar = sqlcom.ExecuteReader();
            while (sqldatar.Read())
            {
                temp = sqldatar[cot].ToString();
            }
            ngatketnoi();
            return temp;
        }
        public string sophong(string strsql,byte cot)
        {
            ketnoi();
            string temp="0";
            sqlcom = new SqlCommand(strsql, sqlconn);
            sqldatar = sqlcom.ExecuteReader();
            while(sqldatar.Read())
            {
                temp = sqldatar[cot].ToString();
            }
            ngatketnoi();
            return temp;
        }
        
        public bool login(string a,string strsql,byte cot)
        {
            ketnoi();
            bool temp = false;
            sqlcom = new SqlCommand(strsql, sqlconn);
            sqldatar = sqlcom.ExecuteReader();
            while(sqldatar.Read())
            {
                if(a==sqldatar[cot].ToString())
                {
                    temp = true;
                }
            }
            ngatketnoi();
            return temp;
        }
        public void InsertDeleteUpdate(string strsql)
        {
            ketnoi();
            sqlcom = new SqlCommand(strsql, sqlconn);
            sqldatar = sqlcom.ExecuteReader();
            ngatketnoi();
        }
    }
}
