using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuMuon
    {
        private string maDG;

        public string MaDG
        {
            get { return maDG; }
            set { maDG = value; }
        }
        private string maSach;

        public string MaSach
        {
            get { return maSach; }
            set { maSach = value; }
        }
        private int soLuong;

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
        private DateTime ngayMuon;

        public DateTime NgayMuon
        {
            get { return ngayMuon; }
            set { ngayMuon = value; }
        }
        

       
       
       

        public PhieuMuon(string mdg, string ms,int sl ,DateTime nm)
        {
            MaDG = mdg;
            MaSach = ms;
            SoLuong = sl;
            NgayMuon = nm;
           
        }

    }
}
