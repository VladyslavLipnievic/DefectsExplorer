using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace OracledbEditor
{
    public class DbOperations
    {
        public List<Defect> defectlist { get; set; } = new List<Defect>();
        public List<DefectType> defectTypeList { get; set; } = new List<DefectType>();
        public List<DefectPosition> defectPositionList { get; set; } = new List<DefectPosition>();

        Dictionary<int, List<int>> DefectDefectsTypesMap = new Dictionary<int, List<int>>();

        private OracleConnection conn { get; set; }
        public void OpenConnection()
        {
            conn = new OracleConnection($"User Id={DefectExplorer.config.userId};Password={DefectExplorer.config.password};Data Source={DefectExplorer.config.address}");
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void CloseConnection()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void clearList()
        {
            defectlist.Clear();
            defectTypeList.Clear();
            defectPositionList.Clear();
        }
        public void SelectDefectPosition()
        {
            string sql = "select nid, sName, sDescription, defect_type_id, nHidden from defect_position";
            OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                defectPositionList.Add(new DefectPosition { Id = Convert.ToInt32(dr[0].ToString()), Name = dr[1].ToString(), Description = dr[2].ToString(), DefectTypeId = Convert.ToInt32(dr[3].ToString()), nHidden = Convert.ToInt32(dr[4]) });
            }
            dr.Close();
            dr.Dispose();
            cmd.Dispose();
        }
        public void SelectDefectTypes()
        {
            string sql = "select nid, sName, sDescription, defect_id,nHidden from Defect_types";

            OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                defectTypeList.Add(new DefectType { Id = Convert.ToInt32(dr[0].ToString()), Name = dr[1].ToString(), Description = dr[2].ToString(), Defectid = Convert.ToInt32(dr[3].ToString()), nHidden = Convert.ToInt32(dr[4]) });
            }
            // close and dispose the objects
            dr.Close();
            dr.Dispose();
            cmd.Dispose();
        }
        public void SelectDefects()
        {
            string sql = "select nid, sName, sDescription, nHidden from Defects";
            OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                defectlist.Add(new Defect { Id = Convert.ToInt32(dr[0].ToString()), Name = dr[1].ToString(), Description = dr[2].ToString(), nHidden = Convert.ToInt32(dr[3]) });
            
            }

            // close and dispose the objects
            dr.Close();
            dr.Dispose();
            cmd.Dispose();
          /*  foreach (var defect in defectlist)
            {

                MessageBox.Show(defect.nHidden.ToString());
            }*/
        }
        public void deleteRow(string tableName, int id)
        {
            string sql = $"Delete from {tableName} where nid = {id}";
            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }
        public void addNewRow(string tableName, string Name, string Description, string ckBoxValue)
        {
            string sql = $"insert into {tableName}(sname, sdescription, nHidden) VALUES ('{Name}','{Description}', '{ckBoxValue}')";
            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();

        }
        public List<IDefectItem> SearchLikeRows(string tableName, string Name, string Description)
        {
            List<IDefectItem> searchList = new List<IDefectItem>();
            string sql = $"select * from {tableName} where UPPER(sname) like UPPER('{Name}%') and UPPER(sdescription) like UPPER('{Description}%') collate binary_ci";
            OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                IDefectItem defectItem;
                switch (tableName)
                {
                    case "defects":
                        defectItem = new Defect();
                        break;
                    case "defect_types":
                        defectItem = new DefectType();
                        break;
                    case "defect_positions":
                        defectItem = new DefectPosition();
                        break;
                    default:
                        defectItem = new Defect();
                        break;
                }
                defectItem.Id = Convert.ToInt32(dr[0].ToString());
                defectItem.Name = dr[1].ToString();
                defectItem.Description = dr[2].ToString();
                searchList.Add(defectItem);
            }
            dr.Close();
            dr.Dispose();
            cmd.Dispose();
            return searchList;
        }



        public List<IDefectItem> searchnhidden0(string tableName)
        {
            List<IDefectItem> searchList = new List<IDefectItem>();
            string sql = $"select * from {tableName} where nHidden = 0 ";
            OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                IDefectItem defectItem;
                switch (tableName)
                {
                    case "defects":
                        defectItem = new Defect();
                        break;
                    case "defect_types":
                        defectItem = new DefectType();
                        break;
                    case "defect_positions":
                        defectItem = new DefectPosition();
                        break;
                    default:
                        defectItem = new Defect();
                        break;
                }
                defectItem.Id = Convert.ToInt32(dr[0].ToString());
                defectItem.Name = dr[1].ToString();
                defectItem.Description = dr[2].ToString();
                searchList.Add(defectItem);
            }
            // close and dispose the objects
            dr.Close();
            dr.Dispose();
            cmd.Dispose();
            return searchList;
        }



        public List<IDefectItem> searchnhidden1(string tableName)
        {
            List<IDefectItem> searchList = new List<IDefectItem>();
            string sql = $"select * from {tableName} where nHidden = 1 ";
            OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                IDefectItem defectItem;
                switch (tableName)
                {
                    case "defects":
                        defectItem = new Defect();
                        break;
                    case "defect_types":
                        defectItem = new DefectType();
                        break;
                    case "defect_positions":
                        defectItem = new DefectPosition();
                        break;
                    default:
                        defectItem = new Defect();
                        break;
                }
                defectItem.Id = Convert.ToInt32(dr[0].ToString());
                defectItem.Name = dr[1].ToString();
                defectItem.Description = dr[2].ToString();
                searchList.Add(defectItem);
            }
            // close and dispose the objects
            dr.Close();
            dr.Dispose();
            cmd.Dispose();
            return searchList;
        }
        public void UpdateDB(string tableName, string colName, string newValue, int id)
        {
            string sql = $"update {tableName} set {colName} = '{newValue}' where nid = {id}";
            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }
        public void CloseConn()
        {
            CloseConnection();
        }
    }
}
