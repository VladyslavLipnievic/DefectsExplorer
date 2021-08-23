﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace OracledbEditor
{
    class QuerySelection
    {
        public List<Defect> defectlist { get; set; } = new List<Defect>();
        public List<DefectType> defectTypeList { get; set; } = new List<DefectType>();
        public List<DefectPosition> defectPositionList { get; set; } = new List<DefectPosition>();
        Dictionary<int, List<int>> DefectDefectsTypesMap = new Dictionary<int, List<int>>();

        public void clearList()
        {
            defectlist.Clear();
            defectTypeList.Clear();
            defectPositionList.Clear();
        }

        DBConnection dBConnection = new DBConnection();



        public QuerySelection()
        {
            dBConnection.OpenConnection();
        }
        /*    void MapDefectDefectsTypes()
            {
                List<int> tempDefectType = new List<int>();
                foreach (var defectType in defectTypeList)
                {
                    DefectDefectsTypesMap.Add(defectType.Defectid, )
                }
            }*/







        public void queryForTree()
        {

            string sql = "select nid, sName, sDescription from Defects";

            OracleCommand cmd = new OracleCommand(sql, dBConnection.conn);

            OracleDataReader dr = cmd.ExecuteReader();




        }






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

  

        public void deleteRow(string tableName,  int id)
        {



            string sql = $"Delete from {tableName} where nid = {id}";
            OracleCommand cmd = new OracleCommand(sql, dBConnection.conn);
            cmd.ExecuteNonQuery();
        }



        public void addNewRow(string tableName, string Name, string Description, int id)
        {
            string sql = $"insert into  {tableName} VALUES {Name} = '{Description}' where nid = {id}";
            OracleCommand cmd = new OracleCommand(sql, dBConnection.conn);
            cmd.ExecuteNonQuery();
/*
            INSERT INTO Defect_position
(nID, sName, sDescription, defect_type_id)
VALUES
(4, 'corrosion', 'corrosion on wheels', 4);*/

        }


        public void UpdateDB(string tableName, string colName, string newValue, int id)
        {
            string sql = $"update {tableName} set {colName} = '{newValue}' where nid = {id}";
            OracleCommand cmd = new OracleCommand(sql, dBConnection.conn);
            cmd.ExecuteNonQuery();
        }

 


        public void closeConn()
        {
            dBConnection.CloseConnection();
        }
    }
}
