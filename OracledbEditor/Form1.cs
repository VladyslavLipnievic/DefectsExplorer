using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace OracledbEditor
{
    public partial class Form1 : Form
    {
        QuerySelection qs = new QuerySelection();
        public Form1()
        {
            InitializeComponent();

           // Console.WriteLine("loaded");

        }
        //test pakeitimas

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void btnSelect_Click_1(object sender, EventArgs e)
        {
            qs.selectDefects();
            qs.selectDefectPosition();
            qs.selectDefectTypes();

        }

      

      

        private void button7_Click(object sender, EventArgs e)
        {

            string conString = "User Id=praktika_vladyslav;Password=praktika;Data Source=192.168.0.188:1521/startas";
            OracleConnection con = new OracleConnection(conString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into Defects values (8,'split8', 'driver asdasdasdads')";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            /*
            string queryString = "SELECT EmpNo, DeptNo FROM Scott.Emp";
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                OracleCommand command = new OracleCommand(queryString, connection);
                connection.Open();
                OracleDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader.GetInt32(0) + ", " + reader.GetInt32(1));
                    }
                }
                finally
                {
                    // always call Close when done reading.
                    reader.Close();
                }
            }
            */

        }

    }
}
