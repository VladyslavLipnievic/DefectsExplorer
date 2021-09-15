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
    public partial class RelationForm : Form
    {
        Dictionary<int, int> listBox1ItemsList = new Dictionary<int, int>();  // index + ID
        Dictionary<int, int> listBox2ItemsList = new Dictionary<int, int>();  // index + ID

        List<IDefectItem> searchList = new List<IDefectItem>();
        DbOperations db = new DbOperations();
        string tableName;
        string itemId;
        string defectName;
        public RelationForm(string tableName, DbOperations db, string itemId, string defectName)
        {
            this.itemId = itemId;
            this.db = db;
            this.tableName = tableName;
            this.defectName = defectName;
            InitializeComponent();
        }
 

        private void RelationForm_Load(object sender, EventArgs e)
        {
            fillListBox1();
            fillListBox2();
            label1.Text = defectName;
            label2.Text = "Unassigned defects";
        }
   

        public void fillListBox2()
        {
            searchList = db.loadListBox2(tableName, itemId);
            int index = 0;
            foreach (var item in searchList)
            {
                listBox2.Items.Add(item.Name);
                listBox2ItemsList.Add(index, Convert.ToInt32(item.Id));
                index++;
            }
        }

        public void fillListBox1()
        {
            searchList = db.loadListBox1(tableName, itemId);
            int index = 0;
            foreach (var item in searchList)
            {
                listBox1.Items.Add(item.Name);
                listBox1ItemsList.Add(index, Convert.ToInt32(item.Id));
                index++;
            }
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
      
        }
     
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }
        private void btnRemoveRel_Click(object sender, EventArgs e)
        {
            db.delRelation(listBox1ItemsList[listBox1.SelectedIndex],tableName);
            reloadListboxes();
        }
        private void btnAddRel_Click(object sender, EventArgs e)
        {
            db.addRelation(listBox2ItemsList[listBox2.SelectedIndex], tableName,itemId);
            reloadListboxes();
        }

        private void reloadListboxes()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox1ItemsList.Clear();
            listBox2ItemsList.Clear();
            fillListBox1();
           fillListBox2();
        }
    }
}
