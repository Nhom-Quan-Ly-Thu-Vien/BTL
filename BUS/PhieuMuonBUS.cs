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
    public class PhieuMuonBUS
    {
        private static PhieuMuonBUS instance;
        public static PhieuMuonBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PhieuMuonBUS();
                }
                return instance;
            }
        }
        public PhieuMuonBUS() { }

        public DataTable LoadPhieuMuon()
        {
            return PhieuMuonDAO.Instance.LoadPhieuMuon();
        }
        public DataTable LoadPhieuTra()
        {
            return PhieuMuonDAO.Instance.LoadPhieuTra();
        }
        public DataTable GetMaDG()
        {
            return PhieuMuonDAO.Instance.GetMaDG();
        }
        public DataTable GetSachTra(string madg)
        {
            return PhieuMuonDAO.Instance.GetSachTra(madg);
        }
        public DataTable LookPhieuMuon(string maph)
        {
          return  PhieuMuonDAO.Instance.LookPhieuMuon(maph);
        }
        public DataTable LookPhieuTra(string madg)
        {
           return  PhieuMuonDAO.Instance.LookPhieuTra(madg);
        }
        public void AddPhieuMuon(PhieuMuon phieu)
        {
            PhieuMuonDAO.Instance.AddPhieuMuon(phieu);
        }
        public void AddPhieuTra(DateTime ngayTra, string masach,string madg)
        {
            PhieuMuonDAO.Instance.AddPhieuTra(ngayTra, masach,madg);
        }
        public void DeletePhieu(string mdg, string ms)
        {
            PhieuMuonDAO.Instance.DeletePhieu(mdg,ms);
        }
    }
}
