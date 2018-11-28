using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class dataprovider
    {
        public static dataprovider instance;
        public static dataprovider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new dataprovider();
                }
                return instance;
            }
        }
        string connection = @"Data Source=DESKTOP-HVKPF81\SQLEXPRESS;Initial Catalog=QuanLyThuVien;Integrated Security=True";
        public DataTable Executequery(string sql)
        {
            DataTable data = new DataTable();
            using (SqlConnection cnn = new SqlConnection(connection))
            {
                cnn.Open();
                SqlDataAdapter dt = new SqlDataAdapter(sql, cnn);
                dt.Fill(data);
                cnn.Close();
            }
            return data;
        }
        public void Executenonquery(string sql)
        {
            using (SqlConnection cnn = new SqlConnection(connection))
            {
                cnn.Open();
                SqlCommand dt = new SqlCommand(sql, cnn);
                dt.ExecuteNonQuery();
                cnn.Close();
            }
           
        }

        public int Executescalar(string sql)
        {
            int n;
            using (SqlConnection cnn = new SqlConnection(connection))
            {
                cnn.Open();
                SqlCommand dt = new SqlCommand(sql, cnn);
                n =(int)dt.ExecuteScalar();
                
                cnn.Close();
            }
            return n;
        }
    }
}