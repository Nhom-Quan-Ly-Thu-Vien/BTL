using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataProvider();
                }
                return instance;
            }
        }

        //chuoi ket noi

        //string connection = @"Data Source=ADMINISTRATOR\PHD;Initial Catalog=QuanLyThuVien1.0;Integrated Security=True";

        string connection = @"Data Source=ADMIN\QUOCCUONG;Initial Catalog=QuanLyThuVien1.0;Integrated Security=True";

        public DataTable ExecuteQuery(string query)
        {
            DataTable data = new DataTable();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                adapter.Fill(data);

                conn.Close();
            }
            return data;
        }

        public void ExecuteNonQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(query, conn);

                command.ExecuteNonQuery();

                conn.Close();
            }
           
        }

        public int ExecuteScalar(string query)
        {
            int n;
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(query, conn);

                n =(int)command.ExecuteScalar();
                
                conn.Close();
            }
            return n;
        }
    }
}