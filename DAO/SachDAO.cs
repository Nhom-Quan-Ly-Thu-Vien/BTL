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
    public class SachDAO
    {
        private static SachDAO instance;
        public static SachDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SachDAO();
                }
                return instance;
            }
        }
        public SachDAO() { }
        public DataTable ShowSach()
        {
            string query = "Select MaSach,TenSach,TenTheLoai,SoLuong,TenTacGia From Sach,TheLoai Where Sach.MaTheLoai=TheLoai.MaTheLoai ";

             DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }
        
        public DataTable GetCatory()
        {
            string query = "Select * From TheLoai";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }
        public void AddBook(Sach sach)
        {
            string query = "Insert Sach Values('"+sach.MaSach+"',N'"+sach.TenSach+"',N'"+sach.TenTheLoai+"','"+sach.SoLuong+"',N'"+sach.TenTacGia+"')";

            DataProvider.Instance.ExecuteNonQuery(query);

        }
        public void UpdateBook(Sach sach)
        {
            string query = "Update Sach Set TenSach=N'" + sach.TenSach + "', MaTheLoai=N'" + sach.TenTheLoai + "',SoLuong='" + sach.SoLuong + "',TenTacGia=N'" + sach.TenTacGia + "' Where MaSach='" + sach.MaSach + "' ";

            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void DeleteBook(string ma)
        {
            string query = "Delete Sach Where MaSach='" + ma + "'";

            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public DataTable LookBook(string dk)
        {
            string query = "Select MaSach,TenSach,TenTheLoai,SoLuong,TenTacGia  From Sach,TheLoai Where Sach.MaTheLoai=TheLoai.MaTheLoai AND (MaSach LIKE '%" + dk + "%' OR TenSach LIKE '%" + dk + "%' OR TenTheLoai LIKE '%" + dk + "%'  OR TenTacGia LIKE '%" + dk + "%' OR SoLuong LIKE '%"+dk+"%' ) ";
           
            DataTable data= DataProvider.Instance.ExecuteQuery(query);

            return data;
        }


        public DataTable getSLuong(string MaSach)
        {
            DataTable data;
            string query = "select SoLuong from Sach where MaSach='" + MaSach + "'";
            data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }
    }
}
