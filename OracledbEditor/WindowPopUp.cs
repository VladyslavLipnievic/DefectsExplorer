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
            lstBoxSearchItems.DoubleClick += LstSearchItems_DoubleClick;
        }

        private void LstSearchItems_DoubleClick(object sender, EventArgs e)
        {
            SelectedItem = searchList[lstBoxSearchItems.SelectedIndex];
            this.DialogResult = DialogResult.OK;
            this.Close();
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

        }
        void FillListBox()
        {
            foreach (var defectItem in searchList)
            {
                lstBoxSearchItems.Items.Add(defectItem.Name);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // MessageBox.Show(itemType);
            searchList = db.SearchDB(tableName, txtBoxName.Text, txtBoxDescription.Text);
            FillListBox();
        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void txtBoxDescription_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
