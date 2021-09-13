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
    public partial class SearchWindow : Form
    {
        List<IDefectItem> searchList = new List<IDefectItem>();
        Dictionary<int, int> MapIndexId = new Dictionary<int, int>();
        DbOperations db;
        string itemType;
        string tableName;
        string txtBNameDEClass;
        string txtBDescDeClass;
        bool isHidden;
        List<string> MapIdAndIndex = new List<string>();
        string[] row;
        public IDefectItem SelectedItem { get; set; }
        public SearchWindow(string itemType, DbOperations db, string tableName, string txtBNameDEClass, string txtBDescDeClass, bool isHidden)
        {
            InitializeComponent();
            this.itemType = itemType;
           // MessageBox.Show(tableName);
            this.db = db;
            this.isHidden = isHidden;
            this.tableName = tableName;
            this.txtBNameDEClass = txtBNameDEClass;
            this.txtBDescDeClass = txtBDescDeClass;
            txtBoxName.Text = txtBNameDEClass;
            txtBoxDescription.Text = txtBDescDeClass;
            dataGridView1.DoubleClick += dataGridView1_DoubleClick;
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value);
                int index = MapIndexId[id];
                SelectedItem = searchList[index-1];
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        public void WindowPopUp_Load(object sender, EventArgs e)
        {
            lblName.Text = itemType + " Name";
            lblDescription.Text = itemType + " Description";
            lblCountRows.Text = "Items fount : 0";
            checkSearchtype();
        }
        public void checkSearchtype()
        {
            if (txtBNameDEClass == "" && txtBDescDeClass == ""&& isHidden==true)
            {
                dataGridView1.Rows.Clear();
                searchList = db.searchnhidden1(tableName);
                fillGrid();
            }
            if (txtBNameDEClass == "" && txtBDescDeClass == "" && isHidden == false)
            {
                dataGridView1.Rows.Clear();
                searchList = db.searchnhidden0(tableName);
                fillGrid();
            }
            if (txtBNameDEClass != "" || txtBDescDeClass != "")
            {
                dataGridView1.Rows.Clear();
              
                    db.SetDbParams("searchName", txtBoxName.Text);
                    db.SetDbParams("searchDesc", txtBoxDescription.Text);
                    searchList = db.SearchLikeRows(tableName);
                fillGrid();
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchGrid(txtBoxName.Text, txtBoxDescription.Text);
        }
        private void txtBoxDescription_TextChanged(object sender, EventArgs e)
        {
            searchGrid(txtBoxName.Text, txtBoxDescription.Text);
        }
        void searchGrid(string SearchItem, string SearchType)
        {
            dataGridView1.Rows.Clear();
            foreach (var defectItem in searchList)
            {
                if (defectItem.Name.Contains(SearchItem) && defectItem.Description.Contains(SearchType))
                {
                    row = new string[] { defectItem.Name, defectItem.Description, defectItem.Id.ToString() };
                    dataGridView1.Rows.Add(row);
                }
            }
            lblCountRows.Text = "Items found : " + dataGridView1.Rows.Count.ToString();
        }
        void fillGrid()
        {
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = itemType + " Name";
            dataGridView1.Columns[1].Name = itemType + " Description";
            dataGridView1.Columns[2].Name = itemType + " Id";
            this.dataGridView1.Columns[itemType + " Id"].Visible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (var defectItem in searchList)
            {
                row = new string[] { defectItem.Name, defectItem.Description, defectItem.Id.ToString() };
                dataGridView1.Rows.Add(row);
                MapIndexId.Add(defectItem.Id,dataGridView1.Rows.Count);
            }
            lblCountRows.Text = "Items found : " + dataGridView1.Rows.Count.ToString();
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
