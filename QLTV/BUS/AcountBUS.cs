using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Data;
using System.Windows.Forms;

namespace Quanlythuvien
{
    public class AcountBUS
    {
        public static AcountBUS instance;
        public static AcountBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AcountBUS();
                }
                return instance;
            }
        }

        public int kiemtra(string usn, string pss)
        {
            string sql = "select count(*) from dbo.AdminAccount where username='"+usn+"' and password='"+pss+"'";
            int a = AcountDAO.Instance.kiemtra(sql);
            return a;
        }
        public void showAcount(DataGridView data)
        {
            string sql = "select * from dbo.AdminAccount";
            data.DataSource = AcountDAO.Instance.showAcount(sql);
        }

        public void insert(string usn, string pss)
        {
            string sql = "insert into dbo.AdminAccount values(N'" + usn + "',N'" + pss + "')";
            AcountDAO.Instance.insert(sql);
        }

        public void sua(string usn, string pss)
        {
            string sql = "update dbo.AdminAccount set username=N'" + usn + "',password=N'" + pss + "'";
            AcountDAO.Instance.sua(sql);
        }

        public void xoa(string ml)
        {
            string sql = "delete dbo.AdminAccount where username=N'" + ml + "'";
            AcountDAO.Instance.xoa(sql);
        }
    }
}
