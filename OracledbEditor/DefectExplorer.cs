using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Newtonsoft.Json;

namespace OracledbEditor
{
    public partial class DefectExplorer : Form
    {
        public static Configuration config = new Configuration();
        DbOperations db = new DbOperations();
        Dictionary<TreeNode, char> nodeMap = new Dictionary<TreeNode, char>();
        string itemType = "";

        public DefectExplorer()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            db.CloseConn();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                ReadConfig();
                db.OpenConnection();
                db.SelectDefects();
                db.SelectDefectTypes();
                db.SelectDefectPosition();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            PrintTree();

        }
        public void ReadConfig()
        {
            string json;
            json = File.ReadAllText("config.json");
            config = JsonConvert.DeserializeObject<Configuration>(json);
        }
        void PrintTree()
        {
            TreeNode defectNode;
            TreeNode defectTypeNode;
            TreeNode defectPositionNode;

            foreach (var defect in db.defectlist)
            {
                defectNode = treeView1.Nodes.Add(defect.Name);
                defectNode.Tag = defect;
                nodeMap[defectNode] = 'd';
                foreach (var defectType in db.defectTypeList)
                {
                    if (defectType.Defectid == defect.Id)
                    {
                        defectTypeNode = defectNode.Nodes.Add(defectType.Name);
                        defectTypeNode.Tag = defectType;
                        nodeMap[defectTypeNode] = 't';
                        foreach (var defectPosition in db.defectPositionList)
                        {
                            if (defectPosition.DefectTypeId == defectType.Id)
                            {
                                defectPositionNode = defectTypeNode.Nodes.Add(defectPosition.Name);
                                defectPositionNode.Tag = defectPosition;
                                nodeMap[defectPositionNode] = 'p';
                            }
                        }
                    }

                }
            }
        }

        private void btnSelect_Click_1(object sender, EventArgs e)
        {


        }


        private void txtName_TextChanged(object sender, EventArgs e)
        {

            //txtName.Text = defectItem.Name;
            //txtDescription.Text = defectItem.Description;

        }
        IDefectItem GetSelectedItem()
        {
            IDefectItem defectItem = new Defect();

            switch (nodeMap[treeView1.SelectedNode])
            {
                case 'd':
                    defectItem = treeView1.SelectedNode.Tag as Defect;
                    itemType = "Defect";
                    break;
                case 't':
                    defectItem = treeView1.SelectedNode.Tag as DefectType;
                    itemType = "Defect type";
                    break;
                case 'p':
                    defectItem = treeView1.SelectedNode.Tag as DefectPosition;
                    itemType = "Defect position";
                    break;
                default:
                    break;
            }

            return defectItem;
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            IDefectItem defectItem = GetSelectedItem();
            txtName.Text = defectItem.Name;
            txtDescription.Text = defectItem.Description;
            lblType.Text = itemType;


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void label2_Click(object sender, EventArgs e)
        {

        }




        private void RefreshTree()
        {
            db.clearList();
            treeView1.Nodes.Clear();
            db.SelectDefects();
            db.SelectDefectTypes();
            db.SelectDefectPosition();
            PrintTree();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tlBtnRefresh_Click(object sender, EventArgs e)
        {
            RefreshTree();
        }
        void saveToDb()
        {
            IDefectItem defectItem = GetSelectedItem();
            try
            {
                // public void UpdateDB(string tableName, string colName, string newValue, int id)
                db.UpdateDB(defectItem.TableName, "sname", txtName.Text, defectItem.Id);
                db.UpdateDB(defectItem.TableName, "sdescription", txtDescription.Text, defectItem.Id);
                treeView1.SelectedNode.Text = txtName.Text;

                IDefectItem defectItemFromTxtForm = GetSelectedItem();
                defectItemFromTxtForm.Name = txtName.Text;
                defectItemFromTxtForm.Description = txtDescription.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update db. Error: " + ex.Message);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            saveToDb();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
          
                //addNewRow(string tableName, string Name, string Description)
                db.addNewRow("defects", txtName.Text, txtDescription.Text);
                RefreshTree();



            
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
          
                // 
                IDefectItem defectItem = GetSelectedItem();
                try
                {

                    db.deleteRow(defectItem.TableName, defectItem.Id);
                    treeView1.SelectedNode.Remove();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to update db. Error: " + ex.Message);
                }
            
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
