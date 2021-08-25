using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OracledbEditor
{
    public partial class WindowPopUp : Form
    {
        List<IDefectItem> searchList = new List<IDefectItem>();
        DbOperations db;
        string itemType;
        string tableName;
        public IDefectItem SelectedItem { get; set; }
        public WindowPopUp(string itemType, DbOperations db, string tableName)
        {
            InitializeComponent();
            this.itemType = itemType;
            this.db = db;
            this.tableName = tableName;
            dataGridView1.DoubleClick += dataGridView1_DoubleClick;
        }
     
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count!=0)
            {
                SelectedItem = searchList[dataGridView1.CurrentCell.RowIndex];
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
               
            
          


        }



        public void WindowPopUp_Load(object sender, EventArgs e)
        {
            lblName.Text = itemType + " Name";
            lblDescription.Text = itemType + " Description";
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchList = db.SearchDB(tableName, txtBoxName.Text, txtBoxDescription.Text);
          
            ClearGrid();
            fillGrid();
        
        }
        private void txtBoxDescription_TextChanged(object sender, EventArgs e)
        {
            // MessageBox.Show(itemType);
            searchList = db.SearchDB(tableName, txtBoxName.Text, txtBoxDescription.Text);
          
            ClearGrid();
            fillGrid();
        
        }

        void ClearGrid()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 0;
        }
        void fillGrid()
        {
            if (txtBoxName.Text == "" && txtBoxDescription.Text == "")
            {
                dataGridView1.Rows.Clear();
                dataGridView1.ColumnCount = 0;
                lblCountRows.Text = "Items found : " + dataGridView1.Rows.Count.ToString();
            }
            else
            {
                dataGridView1.ColumnCount = 2;
                dataGridView1.Columns[0].Name = itemType + " Name";
                dataGridView1.Columns[1].Name = itemType + " Description";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


                foreach (var defectItem in searchList)
                {
                    string[] row = new string[] { defectItem.Name, defectItem.Description };
                    dataGridView1.Rows.Add(row);

                }

                lblCountRows.Text = "Items found : " + (dataGridView1.Rows.Count * 2).ToString();
            }
        }

     
        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
        private void lblName_Click(object sender, EventArgs e)
        {
        }
  
        private void lblDescription_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
