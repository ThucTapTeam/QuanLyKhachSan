﻿using System;
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
            return temp;
        }
        /*
        public bool login(string strsql,byte cot)
        {
            ketnoi();
            bool temp = false;

        }*/
    }
}
