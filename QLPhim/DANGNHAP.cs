using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace khasingum
{
    class DANGNHAP
    {
        public DataTable login(string username, string password)
        {
            DATABASE diaphim = new DATABASE();

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@username", SqlDbType.VarChar, 20);
            param[0].Value = username;
            param[1] = new SqlParameter("@pass", SqlDbType.VarChar, 20);
            param[1].Value = password;
            DataTable tab = new DataTable();
            tab = diaphim.getData("spr_DANGNHAP", param);
            diaphim.closeConnection();
            return tab;
        }
    }
}
