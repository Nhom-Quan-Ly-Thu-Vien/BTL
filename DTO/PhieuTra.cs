using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuTra
    {
        private string maPhieu;

        public string MaPhieu
        {
            get { return maPhieu; }
            set { maPhieu = value; }
        }
        private DateTime ngayTra;

        public DateTime NgayTra
        {
            get { return ngayTra; }
            set { ngayTra = value; }
        }
        private string tenSach;

        public string TenSach
        {
            get { return tenSach; }
            set { tenSach = value; }
        }

        

        public PhieuTra(string mp, DateTime nt,string ten)
        {
            MaPhieu = mp;
            NgayTra = nt;
            TenSach = ten;
        }
    }
}
