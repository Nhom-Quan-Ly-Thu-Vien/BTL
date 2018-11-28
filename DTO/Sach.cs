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

        public string MaSach
        {
            get { return maSach; }
            set { maSach = value; }
        }
        private string tenSach;

        public string TenSach
        {
            get { return tenSach; }
            set { tenSach = value; }
        }
        private string tenTheLoai;

        public string TenTheLoai
        {
            get { return tenTheLoai; }
            set { tenTheLoai = value; }
        }
        private int soLuong;

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
        private string tenTacGia;

        public string TenTacGia
        {
            get { return tenTacGia; }
            set { tenTacGia = value; }
        }

        

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
