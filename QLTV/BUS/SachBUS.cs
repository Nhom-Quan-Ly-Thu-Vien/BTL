using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Data;
using System.Windows.Forms;

namespace BUS
{
    public class SachBUS
    {
        public static SachBUS instance;
        public static SachBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SachBUS();
                }
                return instance;
            }
        }

        public void showSach(DataGridView data)
        {
            string sql = "select * from dbo.Acount";
            data.DataSource = AcountDAO.Instance.showAcount(sql);
        }
    }
}
