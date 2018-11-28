using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Sach
    {
        private string maSach;
        private string tenSach;
        private string tenTheLoai;
        private int soLuong;
        private string tenTacGia;

        public string MaSach { get => maSach; set => maSach = value; }
        public string TenSach { get => tenSach; set => tenSach = value; }
        public string TenTheLoai { get => tenTheLoai; set => tenTheLoai = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public string TenTacGia { get => tenTacGia; set => tenTacGia = value; }

        public Sach (string ma, string ten, string theloai, int sl,string tg)
        {
            MaSach = ma;
            TenSach = ten;
            TenTheLoai = theloai;
            SoLuong = sl;
            TenTacGia = tg;
        }
    }
}
