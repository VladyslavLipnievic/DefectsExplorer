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
        //IDefectItem defItem = new Defect();
        IDefectItem searchItem;
        List<TreeNode> searchItemsList = new List<TreeNode>();
        int searchIndex = 0;
        public string itemType = "";
        public DefectExplorer()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
            treeView1.ImageList = imageList1;
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
                defectNode.Name = defect.Name;
                defectNode.ImageIndex = 0;
                defectNode.SelectedImageIndex = 0;
                nodeMap[defectNode] = 'd';
                foreach (var defectType in db.defectTypeList)
                {
                    if (defectType.Defectid == defect.Id)
                    {
                        defectTypeNode = defectNode.Nodes.Add(defectType.Name);
                        defectTypeNode.Tag = defectType;
                        defectTypeNode.Name = defectType.Name;
                        defectTypeNode.ImageIndex = 1;
                        defectTypeNode.SelectedImageIndex = 1;
                        nodeMap[defectTypeNode] = 't';
                        foreach (var defectPosition in db.defectPositionList)
                        {
                            if (defectPosition.DefectTypeId == defectType.Id)
                            {
                                defectPositionNode = defectTypeNode.Nodes.Add(defectPosition.Name);
                                defectPositionNode.Tag = defectPosition;
                                defectPositionNode.Name = defectPosition.Name;
                                defectPositionNode.ImageIndex = 2;
                                defectPositionNode.SelectedImageIndex = 2;
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
        }
        IDefectItem GetSelectedItem()
        {
            IDefectItem defectItem = new Defect();
            if (treeView1.SelectedNode != null)
            {
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
            }
            return defectItem;
        }
        private void SearchNode(TreeNode treeNode, bool searchTree)
        {
            IDefectItem defectItem = new Defect();
            if (itemType == "Defect" && treeNode.Tag is Defect)
            {
                defectItem = treeNode.Tag as Defect;
            }
            else if (itemType == "Defect type" && treeNode.Tag is DefectType)
            {
                defectItem = treeNode.Tag as DefectType;
            }
            else if (itemType == "Defect position" && treeNode.Tag is DefectPosition)
            {
                defectItem = treeNode.Tag as DefectPosition;
            }
            if(searchTree)
            {
                if(treeNode.Text.Contains(tlTxtSearch.Text))
                {
                    searchItemsList.Add(treeNode);
                }
            }
            else
            {
                if (searchItem.Id == defectItem.Id)
                {
                    treeView1.SelectedNode = treeNode;
                    treeView1.Focus();
                }
            }
            foreach (TreeNode node in treeNode.Nodes)
            {
                SearchNode(node, searchTree);
            }
        }
        void SelectTreeItem(IDefectItem defItem)
        {
            searchItem = defItem;
            foreach (TreeNode node in treeView1.Nodes)
            {
                SearchNode(node, false);
            }
        }
        void SearchTree()
        {
            searchItemsList.Clear();
            foreach (TreeNode node in treeView1.Nodes)
            {
                SearchNode(node, true);
            }
        }
        void DisplayItem(IDefectItem defItem)
        {
            txtName.Text = defItem.Name;
            txtDescription.Text = defItem.Description;
            label1.Text = itemType + " name";
            label2.Text = itemType + " description";
            lblType.Text = itemType;
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            IDefectItem defItem = GetSelectedItem();
            DisplayItem(defItem);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            WindowPopUp objUI = new WindowPopUp(itemType, db, GetSelectedItem().TableName, txtName.Text, txtDescription.Text);
            var result = objUI.ShowDialog();
            if (result == DialogResult.OK)
            {
                IDefectItem defItem = objUI.SelectedItem;
                DisplayItem(defItem);
                SelectTreeItem(defItem);
            }
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
        private void tlBtnSearch_Click(object sender, EventArgs e)
        {
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
        }
        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
        }
        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
        }
        private void tlBtnSearch_Click_1(object sender, EventArgs e)
        {
            searchIndex = 0;
            searchItemsList.Clear();
            SearchTree();
            if (searchItemsList.Count > 0)
            {
                treeView1.SelectedNode = searchItemsList[0];
                treeView1.Focus();
            }            
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if(searchIndex + 1<= searchItemsList.Count - 1)
            {
                searchIndex++;
                treeView1.SelectedNode = searchItemsList[searchIndex];
                treeView1.Focus();
            }
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (searchIndex -1 >= 0)
            {
                searchIndex--;
                treeView1.SelectedNode = searchItemsList[searchIndex];
                treeView1.Focus();
            }
        }
        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtDescription.Text = "";
        }
    }
}
