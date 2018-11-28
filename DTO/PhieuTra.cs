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
        private DateTime ngayTra;
        private string tenSach;

        public string MaPhieu { get => maPhieu; set => maPhieu = value; }
        public DateTime NgayTra { get => ngayTra; set => ngayTra = value; }
        public string TenSach { get => tenSach; set => tenSach = value; }

        public PhieuTra(string mp, DateTime nt,string ten)
        {
            MaPhieu = mp;
            NgayTra = nt;
            TenSach = ten;
        }
    }
}
