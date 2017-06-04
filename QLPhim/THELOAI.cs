using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace khasingum
{
    class THELOAI
    {
        public DataTable getTHELOAI()
        {
            DATABASE diaphim = new DATABASE();
            DataTable tab = new DataTable();
            tab = diaphim.getData("spr_get_THELOAI", null);
            diaphim.closeConnection();
            return tab;
        }

        public void insertTHELOAI(string name)
        {

            DATABASE diaphim = new DATABASE();
            diaphim.openConnection();
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@NAME", SqlDbType.VarChar);
            parameters[0].Value = name;

            diaphim.setData("spr_insert_THELOAI", parameters);
            diaphim.closeConnection();

        }

        public DataTable searchSANPHAM(string valueToSearch)
        {

            DATABASE diaphim = new DATABASE();
            DataTable table = new DataTable();
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@val", SqlDbType.VarChar, 100);
            parameters[0].Value = valueToSearch;
            table = diaphim.getData("spr_search_SANPHAM", parameters);
            diaphim.closeConnection();
            return table;
        }

        public void deleteTHELOAI(int S_id)
        {

            DATABASE diaphim = new DATABASE();
            DataTable table = new DataTable();
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@cid", SqlDbType.Int);
            parameters[0].Value = S_id;

            diaphim.openConnection();
            diaphim.setData("spr_delete_THELOAI", parameters);
            diaphim.closeConnection();

        }

        public void updateTHELOAI(int cid, string name)
        {

            DATABASE diaphim = new DATABASE();
            diaphim.openConnection();
            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter("@T_ID", SqlDbType.Int);
            parameters[0].Value = cid;

            parameters[1] = new SqlParameter("@NAME", SqlDbType.VarChar);
            parameters[1].Value = name;

            diaphim.setData("spr_update_THELOAI", parameters);
            diaphim.closeConnection();

        }
    }
}
