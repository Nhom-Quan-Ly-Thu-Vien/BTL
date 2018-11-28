using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DocGia
    {
        private string maDg;

        public string MaDg
        {
            get { return maDg; }
            set { maDg = value; }
        }
        private string tenDg;

        public string TenDg
        {
            get { return tenDg; }
            set { tenDg = value; }
        }
        private string gt;

        public string Gt
        {
            get { return gt; }
            set { gt = value; }
        }
        private string diaChi;

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }
        private string sdt;
        
        public string Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }

        public DocGia() { }

        public DocGia(string maDg, string tenDg, string gt, string diaChi, string sdt)
        {
            this.maDg = maDg;
            this.tenDg = tenDg;
            this.gt = gt;
            this.diaChi = diaChi;
            this.sdt = sdt;
        }

        
    }
}
