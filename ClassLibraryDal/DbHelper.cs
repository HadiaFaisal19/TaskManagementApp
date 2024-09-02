using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDal
{
    public class DbHelper
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-LH2H0SS\\SQLEXPRESS;Initial Catalog=TaskManagementApp;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0");
            return conn;
        }
    }
}
