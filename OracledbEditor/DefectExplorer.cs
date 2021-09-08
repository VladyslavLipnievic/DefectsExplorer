using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Newtonsoft.Json;
using CrystalDecisions.CrystalReports.Engine;
namespace OracledbEditor
{
    public partial class DefectExplorer : Form
    {
        public static Configuration config = new Configuration();
        DbOperations db = new DbOperations();
        Dictionary<TreeNode, char> nodeMap = new Dictionary<TreeNode, char>();
        IDefectItem defectItem = new Defect();
        IDefectItem searchItem;
        List<TreeNode> searchItemsList = new List<TreeNode>();
        int searchIndex = 0;
        public string itemTypeId = "";
        public string itemType = "";
        string ItemName;
        bool treeExpanded = false;
        TreeNode rootNode;
        TreeNode defectNode;
        TreeNode defectTypeNode;
        TreeNode defectPositionNode;
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
            tabSearchType.SelectedIndexChanged += new EventHandler(Tabs_SelectedIndexChanged);
            txtName.DoubleClick += new EventHandler(btnSearch_Click);
            txtDescription.DoubleClick += new EventHandler(btnSearch_Click);
            this.Activated += AfterLoading;
            // treeView1.Nodes[0].Expand();
            // GetSelectedItem();
            TabSelectedIndex();
        }
        public void tabPage2_Click(object sender, EventArgs e)
        {

        }
        private void AfterLoading(object sender, EventArgs e)
        {
            this.Activated += AfterLoading;
            txtName.Text = "";
            txtDescription.Text = "";
        }
        private void searchedItemType()
        {
            label1.Text = itemType + " name";
            label2.Text = itemType + " description";
        }
        public void cleanInput()
        {
            txtName.Text = "";
            txtDescription.Text = "";
        }
        public void ReadConfig()
        {
            string json;
            json = File.ReadAllText("config.json");
            config = JsonConvert.DeserializeObject<Configuration>(json);
        }
        void PrintTree()
        {
            rootNode = treeView1.Nodes.Add("root");
            nodeMap[rootNode] = 'r';
            foreach (var defect in db.defectlist)
            {
                defectNode = rootNode.Nodes.Add(defect.Name);
                defectNode.Tag = defect;
                defectNode.Name = defect.Name;
                if (defect.nHidden == 1)
                {
                    defectNode.ForeColor = Color.Red;
                }
                nodeMap[defectNode] = 'd';
                foreach (var defectType in db.defectTypeList)
                {
                    if (defectType.Defectid == defect.Id)
                    {
                        defectTypeNode = defectNode.Nodes.Add(defectType.Name);
                        defectTypeNode.Tag = defectType;
                        defectTypeNode.Name = defectType.Name;

                        if (defectType.nHidden == 1)
                        {
                            defectTypeNode.ForeColor = Color.Red;
                        }
                        nodeMap[defectTypeNode] = 't';
                        foreach (var defectPosition in db.defectPositionList)
                        {
                            if (defectPosition.DefectTypeId == defectType.Id)
                            {
                                defectPositionNode = defectTypeNode.Nodes.Add(defectPosition.Name);
                                defectPositionNode.Tag = defectPosition;
                                defectPositionNode.Name = defectPosition.Name;
                                if (defectPosition.nHidden == 1)
                                {
                                    defectPositionNode.ForeColor = Color.Red;
                                }
                                nodeMap[defectPositionNode] = 'p';
                            }
                        }
                    }
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && treeView1.SelectedNode.Tag.ToString() != "r" && treeView1.SelectedNode != null)
            {
                if (ckBoxValueCheck() == true)
                {
                    saveToDb("1");
                    ckBoxHidden.Checked = true;
                }
                else
                {
                    saveToDb("0");
                    ckBoxHidden.Checked = false;
                }
                RefreshTree();
                tlTxtSearch.Tag = ItemName;
                searchButton();
            }
        }
        private void checkIfHiddenDefect(IDefectItem defectItem)
        {
            if (defectItem.nHidden == 1)
            {
                ckBoxHidden.Checked = true;
            }
            else
            {
                ckBoxHidden.Checked = false;
            }
        }
        IDefectItem GetSelectedItem()
        {
            if (treeView1.SelectedNode != null)
            {
                switch (nodeMap[treeView1.SelectedNode])
                {
                    case 'd':
                        defectItem = treeView1.SelectedNode.Tag as Defect;
                        itemType = "Defect";
                        tabSearchType.SelectedIndex = 0;
                        ItemName = treeView1.SelectedNode.Text;
                        checkIfHiddenDefect(defectItem);
                        rootNode.Tag = "0";
                        break;
                    case 't':
                        defectItem = treeView1.SelectedNode.Tag as DefectType;
                        itemType = "Defect type";
                        checkIfHiddenDefect(defectItem);
                        ItemName = treeView1.SelectedNode.Text;
                        tabSearchType.SelectedIndex = 1;
                        rootNode.Tag = "0";
                        break;
                    case 'p':
                        defectItem = treeView1.SelectedNode.Tag as DefectPosition;
                        itemType = "Defect position";
                        checkIfHiddenDefect(defectItem);
                        ItemName = treeView1.SelectedNode.Text;
                        tabSearchType.SelectedIndex = 2;
                        rootNode.Tag = "0";
                        break;
                    case 'r':
                        rootNode.Tag = "r";
                        defectItem.Id = 0;
                        break;
                    default:
                        break;
                }
            }
            return defectItem;
        }
        public void SearchNode(TreeNode treeNode, bool searchTree)
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
            if (searchTree)
            {
                if (treeNode.Text.Contains(tlTxtSearch.Tag.ToString()))
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
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            IDefectItem defItem = GetSelectedItem();
            if (defItem != null)
            {
                itemTypeId = defItem.Id.ToString();
                DisplayItem(defItem);
            }
        }
        private void TabSelectedIndex()
        {
            if (tabSearchType.SelectedIndex == 0)
            {
                cleanInput();
                itemType = "Defect";
                searchedItemType();
            }
            else if (tabSearchType.SelectedIndex == 1)
            {
                cleanInput();
                itemType = "Defect type";
                searchedItemType();
            }
            else if (tabSearchType.SelectedIndex == 2)
            {
                cleanInput();
                itemType = "Defect position";
                searchedItemType();
            }
        }
        private string GetTableNameFromTab()
        {
            if (tabSearchType.SelectedTab == tabSearchType.TabPages[0])
            {
                defectItem = treeView1.SelectedNode.Tag as Defect;
                searchedItemType();
                return "defects";
            }
            else if (tabSearchType.SelectedTab == tabSearchType.TabPages[1])
            {
                defectItem = treeView1.SelectedNode.Tag as DefectType;
                searchedItemType();
                return "defect_types";
            }
            else if (tabSearchType.SelectedTab == tabSearchType.TabPages[2])
            {
                defectItem = treeView1.SelectedNode.Tag as DefectPosition;
                searchedItemType();
                return "defect_position";
            }
            return "";


        }
        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)//for updating entries
        {
            TabSelectedIndex();
        }
        private void forSearchandDoubleClick()
        {
            SearchWindow objUI = new SearchWindow(itemType, db, GetTableNameFromTab(), txtName.Text, txtDescription.Text, ckBoxValueCheck());
            var result = objUI.ShowDialog();
           
            if (result == DialogResult.OK)
            {
                
                IDefectItem defItem = objUI.SelectedItem;
                DisplayItem(defItem);
                SelectTreeItem(defItem);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //treeView1.Nodes[0].Expand();
         
            
            forSearchandDoubleClick();

           // treeView1.SelectedNode = treeView1.Nodes[0].Nodes[0];
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
            treeView1.Nodes[0].Expand();
            treeView1.SelectedNode = treeView1.Nodes[0];
            
            //jai reikia pasirinkti child elementa treeView1.SelectedNode = treeView1.Nodes[0].[0];
        }
        void saveToDb(string nHidden)
        {
            IDefectItem defectItem = GetSelectedItem();
            try
            {
                db.UpdateDB(defectItem.TableName, "sname", txtName.Text, defectItem.Id);
                db.UpdateDB(defectItem.TableName, "sdescription", txtDescription.Text, defectItem.Id);
                db.UpdateDB(defectItem.TableName, "nHidden", nHidden, defectItem.Id);
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
        private void expandTreeView()
        {
            foreach (TreeNode tn in treeView1.Nodes)
            {
                {
                    if (tn.Level == 0)
                        tn.Expand();
                }
            }
        }
        private bool ckBoxValueCheck()
        {
            if (ckBoxHidden.Checked == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                if (ckBoxValueCheck() == true)
                {
                    db.addNewRow("defects", txtName.Text, txtDescription.Text, "1");
                }
                else
                {
                    db.addNewRow("defects", txtName.Text, txtDescription.Text, "0");
                }
                RefreshTree();
                expandTreeView();
            }
        }
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (rootNode.Tag.ToString() != "r" && treeView1.SelectedNode != null)
            {
                try
                {
                    IDefectItem defectItem = GetSelectedItem();
                    db.deleteRow(defectItem.TableName, defectItem.Id);
                    treeView1.SelectedNode.Remove();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to update db. Error: " + ex.Message);
                }
            }
        }
        public void searchButton()
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
        private void tlBtnSearch_Click_1(object sender, EventArgs e)
        {
            tlTxtSearch.Tag = tlTxtSearch.Text;
            searchButton();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (searchIndex + 1 <= searchItemsList.Count - 1)
            {
                searchIndex++;
                treeView1.SelectedNode = searchItemsList[searchIndex];
                treeView1.Focus();
            }
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (searchIndex - 1 >= 0)
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
            Clear();
        }
        private void Clear()
        {
            txtName.Text = "";
            txtDescription.Text = "";
            itemTypeId = "0";
        }
        private void tlBtnPrintCr_Click(object sender, EventArgs e)
        {
            PrintcrTree rpUI = new PrintcrTree(config);
            var result = rpUI.ShowDialog();
        }
        private void loadReportWindow()
        {
            reportPrint rpUI = new reportPrint(db, itemTypeId, config, defectItem.Name);
            var result = rpUI.ShowDialog();
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
        private void Defect_Click(object sender, EventArgs e)
        {

        }
        private void lblType_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        private void btnSelect_Click_1(object sender, EventArgs e)
        {
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
        }
        private void txtName_Double_Click(object sender, EventArgs e)
        {
            forSearchandDoubleClick();
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (treeExpanded)
            {

                treeView1.Nodes[0].Expand();
                // treeView1.CollapseAll();
                treeExpanded = false;
            }
            else
            {
                treeView1.Nodes[0].Collapse();
                //  treeView1.ExpandAll();
                treeExpanded = true;
            }
        }
        private void ckBoxHidden_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            loadReportWindow();
        }
    }
}
