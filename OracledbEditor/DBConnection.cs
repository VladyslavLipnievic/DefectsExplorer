using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;

namespace OracledbEditor
{
    class DBConnection
    {
        public OracleConnection conn { get; } = new OracleConnection(Configuration.conString);
        public void OpenConnection ()
        {
            try
            {
                conn.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void CloseConnection() 
        {
            if(conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();
            }    
        }
    }
}
