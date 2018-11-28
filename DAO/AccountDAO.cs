using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
using DAO;

namespace DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null) instance = new AccountDAO(); 
                return AccountDAO.instance; }
            set { AccountDAO.instance = value; }
        }

        public AccountDAO()
        {

        }

        public bool login(Account account)
        {
            string query = "select * FROM Admin WHERE Admin=N'" + account.User + "' AND Password = N'" + account.Password + "' ";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }
    }
}
