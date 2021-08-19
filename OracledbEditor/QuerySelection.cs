using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace OracledbEditor
{
    class QuerySelection
    {
        List<Defect> defectlist = new List<Defect>();
        List<DefectType> defectTypeList = new List<DefectType>();
        List<DefectPosition> defectPositionList = new List<DefectPosition>();
        DBConnection dBConnection = new DBConnection();
        public void selectDefectPosition()
        {
            string sql = "select nid, sName, sDescription, defect_type_id from defect_position";

            OracleCommand cmd = new OracleCommand(sql, dBConnection.conn);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                defectPositionList.Add(new DefectPosition { Id = Convert.ToInt32(dr[0].ToString()), Name = dr[1].ToString(), Description = dr[2].ToString(), DefectTypeId = Convert.ToInt32(dr[3].ToString()) });
            }

            // close and dispose the objects
            dr.Close();
            dr.Dispose();
            cmd.Dispose();
        }

        public void selectDefectTypes()
        {
     


     
            string sql = "select nid, sName, sDescription, defect_id from Defect_types";

            OracleCommand cmd = new OracleCommand(sql, dBConnection.conn);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                defectTypeList.Add(new DefectType { Id = Convert.ToInt32(dr[0].ToString()), Name = dr[1].ToString(), Description = dr[2].ToString(), Defectid = Convert.ToInt32(dr[3].ToString()) });
            }

            // close and dispose the objects
            dr.Close();
            dr.Dispose();
            cmd.Dispose();
        }

        public void selectDefects()
        {



            string sql = "select nid, sName, sDescription from Defects";

            OracleCommand cmd = new OracleCommand(sql, dBConnection.conn);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                defectlist.Add(new Defect { Id = Convert.ToInt32(dr[0].ToString()), Name = dr[1].ToString(), Description = dr[2].ToString() });
            }

            // close and dispose the objects
            dr.Close();
            dr.Dispose();
            cmd.Dispose();
        }

    }
}
