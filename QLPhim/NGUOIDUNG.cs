using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace khasingum
{
    class NGUOIDUNG
    {
        public DataTable getnNGUOIDUNG()
        {
            DATABASE diaphim = new DATABASE();
            DataTable tab = new DataTable();
            tab = diaphim.getData("spr_get_users", null);
            diaphim.closeConnection();
            return tab;
        }

        public void insertNGUOIDUNG(string username, string type, string password, string tel, string email)
        {

            DATABASE diaphim = new DATABASE();
            diaphim.openConnection();
            SqlParameter[] parameters = new SqlParameter[5];

            parameters[0] = new SqlParameter("@USERNAME", SqlDbType.VarChar, 20);
            parameters[0].Value = username;

            parameters[1] = new SqlParameter("@TYPE", SqlDbType.VarChar, 10);
            parameters[1].Value = type;

            parameters[2] = new SqlParameter("@PASS", SqlDbType.VarChar, 20);
            parameters[2].Value = password;

            parameters[3] = new SqlParameter("@TEL", SqlDbType.VarChar, 20);
            parameters[3].Value = tel;

            parameters[4] = new SqlParameter("@EMAIL", SqlDbType.VarChar, 20);
            parameters[4].Value = email;

            diaphim.setData("spr_insert_NGUOIDUNG", parameters);
            diaphim.closeConnection();

        }

        public void updateNGUOIDUNG(string username, string type, string password, string tel, string email, int NID)
        {

            DATABASE diaphim = new DATABASE();
            diaphim.openConnection();
            SqlParameter[] parameters = new SqlParameter[6];

            parameters[0] = new SqlParameter("@USERNAME", SqlDbType.VarChar, 20);
            parameters[0].Value = username;

            parameters[1] = new SqlParameter("@TYPE", SqlDbType.VarChar, 100);
            parameters[1].Value = type;

            parameters[2] = new SqlParameter("@PASS", SqlDbType.VarChar, 20);
            parameters[2].Value = password;

            parameters[3] = new SqlParameter("@TEL", SqlDbType.VarChar, 20);
            parameters[3].Value = tel;

            parameters[4] = new SqlParameter("@EMAIL", SqlDbType.VarChar, 20);
            parameters[4].Value = email;

            parameters[5] = new SqlParameter("@ID", SqlDbType.Int);
            parameters[5].Value = NID;

            diaphim.setData("spr_update_NGUOIDUNG", parameters);
            diaphim.closeConnection();

        }

        public void deleteNGUOIDUNG(int userId)
        {

            DATABASE diaphim = new DATABASE();
            diaphim.openConnection();
            SqlParameter[] parameters = new SqlParameter[1];
            
            parameters[0] = new SqlParameter("@NID", SqlDbType.Int);
            parameters[0].Value = userId;

            diaphim.setData("spr_delete_NGUOIDUNG", parameters);
            diaphim.closeConnection();

        }
    }
}
