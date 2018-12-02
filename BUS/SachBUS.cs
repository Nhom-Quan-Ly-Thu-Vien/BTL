using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAO;
using DTO;

namespace BUS
{
    public class SachBUS
    {
        private static SachBUS instance;
        public static SachBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SachBUS();
                }
                return instance;
            }
        }
        public SachBUS() { }

        public DataTable ShowSach()
        {
            return SachDAO.Instance.ShowSach();
        }

        public DataTable GetCatory()
        {
            return SachDAO.Instance.GetCatory();
        }

        public void AddBook(Sach sach)
        {
            SachDAO.Instance.AddBook(sach);
        }

        public void UpdateBook(Sach sach)
        {
            SachDAO.Instance.UpdateBook(sach);
        }

        public void DeleteBook(string ma)
        {
            SachDAO.Instance.DeleteBook(ma);
        }

        public DataTable LookBook(string dk)
        {
            return SachDAO.Instance.LookBook(dk);
        }

        public string getSLuong(string MaSach)
        {
            
            
                DataTable data = SachDAO.Instance.getSLuong(MaSach);
                string s = data.Rows[0]["SoLuong"].ToString();
                return s;
        }

        public void UpdateSLBook(int sl, string ms)
        {
            SachDAO.Instance.UpdateSLBook(sl,ms);
        }
    }
}
