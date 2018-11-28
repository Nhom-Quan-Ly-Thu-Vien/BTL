using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;

namespace DAO
{
    public class PhieuMuonDAO
    {
        private static PhieuMuonDAO instance;
        public static PhieuMuonDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PhieuMuonDAO();
                }
                return instance;
            }
        }
        public PhieuMuonDAO() { }

        public DataTable LoadPhieuMuon()
        {
            string query = "Select MaDocGia,MaSach,SoLuong,NgayMuon From PhieuMuon Where NgayTra Is Null";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }

        public DataTable LoadPhieuTra()
        {
            string query = "Select * From PhieuMuon Where NgayTra Is Not Null";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }

        public DataTable GetMaDG()
        {
            string query = "Select Distinct MaDocGia From PhieuMuon";

            DataTable data =DataProvider.Instance.ExecuteQuery(query);

            return data;
        }

        public DataTable GetSachTra(string madg)
        {
            string query = "Select PhieuMuon.MaSach,TenSach,PhieuMuon.SoLuong From PhieuMuon,Sach Where PhieuMuon.MaSach=Sach.MaSach AND MaDocGia='"+madg+"' AND NgayTra IS NULL";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }

        public DataTable LookPhieuMuon(string dk)
        {
            string query = "Select MaDocGia,MaSach,SoLuong,NgayMuon From PhieuMuon Where NgayTra Is Null AND (MaDocGia LIKE '%"+dk+"%' OR MaSach LIKE '%"+dk+"%' OR SoLuong LIKE '%"+dk+"%' OR NgayMuon LIKE '%"+dk+"%')";

            DataTable data= DataProvider.Instance.ExecuteQuery(query);

            return data;
        }

        
        public DataTable LookPhieuTra(string dk)
        {
            string query = "Select * From PhieuMuon Where  NgayTra Is Not Null AND (MaDocGia LIKE '%" + dk + "%' OR MaSach LIKE '%" + dk + "%' OR SoLuong LIKE '%" + dk + "%' OR NgayMuon LIKE '%" + dk + "%' OR NgayTra LIKE '%"+dk+"%')";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }

        public void AddPhieuMuon(PhieuMuon phieu)
        {
            string query = "Insert Into PhieuMuon(MaDocGia,MaSach,SoLuong,NgayMuon) Values('"+phieu.MaDG+"','"+phieu.MaSach+"','"+phieu.SoLuong+"','"+phieu.NgayMuon+"')";

            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void AddPhieuTra(DateTime ngayTra,string masach,string madg)
        {
            string query = "Update PhieuMuon SET NgayTra='"+ngayTra+"' Where MaSach='"+masach+"' AND MaDocGia='"+madg+"'";

            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void DeletePhieu(string mdg, string ms)
        {
            string query = "Delete  PhieuMuon Where MaDocGia='"+mdg+"' AND MaSach='"+ms+"'";

            DataProvider.Instance.ExecuteNonQuery(query);
        }
   
    }
}
