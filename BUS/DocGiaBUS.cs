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
 
        public class DocGiaBUS
        {
            private static DocGiaBUS instance;

            public static DocGiaBUS Instance
            {
                get
                {
                    if (instance == null) instance = new DocGiaBUS();
                    return DocGiaBUS.instance;
                }
                set { DocGiaBUS.instance = value; }
            }

            public DocGiaBUS()
            {

            }

            public DataTable ShowDG()
            {
                return DocGiaDAO.Instance.ShowDG();
            }

            public DataTable TimKiemDG(String str)
            {
                return DocGiaDAO.Instance.TimKiemDG(str);
            }

            public void ThemDG(DocGia docgia)
            {
                DocGiaDAO.Instance.ThemDG(docgia);
            }

            public void SuaDG(DocGia docgia)
            {
                DocGiaDAO.Instance.SuaDG(docgia);
            }

            public void XoaDG(DocGia docgia)
            {
                DocGiaDAO.Instance.XoaDG(docgia);
            }
        }

}
