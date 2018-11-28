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
        private string maSach;
        private int soLuong;
        private DateTime ngayMuon;
        

       
        public string MaDG { get => maDG; set => maDG = value; }
        public string MaSach { get => maSach; set => maSach = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public DateTime NgayMuon { get => ngayMuon; set => ngayMuon = value; }
       

        public PhieuMuon(string mdg, string ms,int sl ,DateTime nm)
        {
            MaDG = mdg;
            MaSach = ms;
            SoLuong = sl;
            NgayMuon = nm;
           
        }

    }
}
