using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Windows.Forms;



namespace DAO
{
    public class AcountDAO
    {
        public static AcountDAO instance;
        public static AcountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AcountDAO();
                }
                return instance;
            }
        }

        public int kiemtra(string sql)
        {
            return dataprovider.Instance.Executescalar(sql);
        }

        public List<AcountDTO> showAcount(string sql)
        {
            DataTable data = new DataTable();
            
            List<AcountDTO> ac = new List<AcountDTO>();

            data = dataprovider.Instance.Executequery(sql);
            foreach (DataRow item in data.Rows)
            {
                string username = item["username"].ToString();
                string password = item["password"].ToString();
                AcountDTO ac1 = new AcountDTO(username, password);
                ac.Add(ac1);
            }


            return ac;
        }

        public void insert(string sql)
        {
            dataprovider.Instance.Executenonquery(sql);
        }

        public void sua(string sql)
        {
            dataprovider.Instance.Executenonquery(sql);
        }

        public void xoa(string sql)
        {
            dataprovider.Instance.Executenonquery(sql);
        }
    }
}
