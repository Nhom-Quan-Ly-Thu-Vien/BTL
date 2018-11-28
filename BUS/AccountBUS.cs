using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace BUS
{
    public class AccountBUS
    {
        private static AccountBUS instance;

        public static AccountBUS Instance
        {
            get
            {
                if (instance == null) instance = new AccountBUS();
                return AccountBUS.instance;
            }
            set { AccountBUS.instance = value; }
        }
        public AccountBUS()
        {

        }
        public bool login(Account account)
        {
            return AccountDAO.Instance.login(account);
        }
    }
}
