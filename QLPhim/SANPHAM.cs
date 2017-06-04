using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace khasingum
{
    class SANPHAM
    {
        public void insertSANPHAM(int cid, string tenphim, string linkphim, byte[] image, int thoiluong, string namsanxuat, string daodien)
        {

            DATABASE diaphim = new DATABASE();
            diaphim.openConnection();
            SqlParameter[] parameters = new SqlParameter[7];

            parameters[0] = new SqlParameter("@T_ID", SqlDbType.Int);
            parameters[0].Value = cid;

            parameters[1] = new SqlParameter("@TENPHIM", SqlDbType.VarChar, 50);
            parameters[1].Value = tenphim;

            parameters[2] = new SqlParameter("@THOILUONG", SqlDbType.Int);
            parameters[2].Value = thoiluong;

            parameters[3] = new SqlParameter("@LINKPHIM", SqlDbType.VarChar);
            parameters[3].Value = linkphim;

            parameters[4] = new SqlParameter("@NAMSANXUAT", SqlDbType.VarChar, 10);
            parameters[4].Value = namsanxuat;

            parameters[5] = new SqlParameter("@DAODIEN", SqlDbType.VarChar, 20);
            parameters[5].Value = daodien;

            parameters[6] = new SqlParameter("@HINHANH", SqlDbType.Image);
            parameters[6].Value = image;

            diaphim.setData("spr_insert_SANPHAM", parameters);
            diaphim.closeConnection();

        }

        public DataTable getSANPHAM()
        {
            DATABASE diaphim = new DATABASE();
            DataTable tab = new DataTable();
            tab = diaphim.getData("spr_get_SANPHAM", null);
            diaphim.closeConnection();
            return tab;
        }

        public DataTable getSANPHAM(int id)
        {
            DATABASE diaphim = new DATABASE();
            DataTable tab = new DataTable();
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@ID", SqlDbType.Int);
            parameters[0].Value = id;
            tab = diaphim.getData("spr_get_SANPHAM_by_id", parameters);
            diaphim.closeConnection();
            return tab;
        }

        public DataTable getSANPHAMbyTHELOAI(int t_id)
        {
            DATABASE diaphim = new DATABASE();
            DataTable table = new DataTable();
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@ST_ID", SqlDbType.Int);
            parameters[0].Value = t_id;
            table = diaphim.getData("spr_SANPHAM_by_THELOAI", parameters);
            diaphim.closeConnection();
            return table;
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

        public void deleteSANPHAM(int s_id)
        {

            DATABASE diaphim = new DATABASE();
            diaphim.openConnection();
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@SID", SqlDbType.Int);
            parameters[0].Value = s_id;

            
            diaphim.setData("spr_delete_SANPHAM", parameters);
            diaphim.closeConnection();

        }

        public void updateSANPHAM(int pid, int cid, string tenphim, string linkphim, byte[] image, int thoiluong, string namsanxuat, string daodien)
        {

            DATABASE diaphim = new DATABASE();
            diaphim.openConnection();
            SqlParameter[] parameters = new SqlParameter[8];

            parameters[0] = new SqlParameter("@ID", SqlDbType.Int);
            parameters[0].Value = pid;

            parameters[1] = new SqlParameter("@T_ID", SqlDbType.Int);
            parameters[1].Value = cid;

            parameters[2] = new SqlParameter("@TENPHIM", SqlDbType.VarChar, 50);
            parameters[2].Value = tenphim;

            parameters[3] = new SqlParameter("@THOILUONG", SqlDbType.Int);
            parameters[3].Value = thoiluong;

            parameters[4] = new SqlParameter("@LINKPHIM", SqlDbType.VarChar);
            parameters[4].Value = linkphim;

            parameters[5] = new SqlParameter("@NAMSANXUAT", SqlDbType.VarChar, 10);
            parameters[5].Value = namsanxuat;

            parameters[6] = new SqlParameter("@DAODIEN", SqlDbType.VarChar, 50);
            parameters[6].Value = daodien;

            parameters[7] = new SqlParameter("@HINHANH", SqlDbType.Image);
            parameters[7].Value = image;

            diaphim.setData("spr_update_SANPHAM", parameters);
            diaphim.closeConnection();

        }

    }
}
