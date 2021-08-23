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
        Dictionary<TreeNode, char> nodeMap = new Dictionary<TreeNode, char>();
        IDefectItem selectedItem;
        string tableName = "";

        public Form1()
        {
            InitializeComponent();
            // Console.WriteLine("loaded");
            this.FormClosing += Form1_FormClosing;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            qs.closeConn();
        }


        private void Form1_Load(object sender, EventArgs e)
        {   
            qs.selectDefects();
            qs.selectDefectTypes();
            qs.selectDefectPosition();
            printTree();
        }


        void printTree()
        {

            TreeNode defectNode;
            TreeNode defectTypeNode;
            TreeNode defectPositionNode;


            foreach (var defect in qs.defectlist)
            {

                defectNode = treeView1.Nodes.Add(defect.Name);
                defectNode.Tag = defect;
                nodeMap[defectNode] = 'd';
                foreach (var defectType in qs.defectTypeList)
                {
                    if (defectType.Defectid == defect.Id)
                    {
                        defectTypeNode = defectNode.Nodes.Add(defectType.Name);
                        defectTypeNode.Tag = defectType;
                        nodeMap[defectTypeNode] = 't';
                        foreach (var defectPosition in qs.defectPositionList)
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


     /*   public void UpdateDB(string tableName, string colName, string newValue, int id)
        {
            string sql = $"update {tableName} set {colName} = '{newValue}' where nid = {id}";
            OracleCommand cmd = new OracleCommand(sql, dBConnection.conn);
            cmd.ExecuteNonQuery();
        }*/


        private void button7_Click(object sender, EventArgs e)
        {

            string conString = "User Id=praktika_vladyslav;Password=praktika;Data Source=192.168.0.188:1521/startas";
            OracleConnection con = new OracleConnection(conString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText =$"insert into {tableName} values (8,'split8', 'driver asdasdasdads')";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

       

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
          // 
            IDefectItem defectItem = GetSelectedItem();
            try
            {
               
               qs.deleteRow(defectItem.TableName, defectItem.Id);
               treeView1.SelectedNode.Remove();
                //  treeView1.SelectedNode.Text = txtName.Text;

                /*    IDefectItem defectItemFromTxtForm = GetSelectedItem();
                    defectItemFromTxtForm.Name = txtName.Text;
                    defectItemFromTxtForm.Description = txtDescription.Text;*/


                /*  txtName.Text = defectItem2.Name;
                  txtDescription.Text = defectItem.Description;*/
                /*   txtName.Text = defectItem.Name;
                   txtDescription.Text = defectItem.Description;*/

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update db. Error: " + ex.Message);
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {

            IDefectItem defectItem = GetSelectedItem();
            try
            {
               // public void UpdateDB(string tableName, string colName, string newValue, int id)
                qs.UpdateDB(defectItem.TableName, "sname", txtName.Text, defectItem.Id);
                qs.UpdateDB(defectItem.TableName, "sdescription", txtDescription.Text, defectItem.Id);
                treeView1.SelectedNode.Text = txtName.Text;
                
                IDefectItem defectItemFromTxtForm = GetSelectedItem();
                defectItemFromTxtForm.Name = txtName.Text;
                defectItemFromTxtForm.Description = txtDescription.Text;
                

                /*  txtName.Text = defectItem2.Name;
                  txtDescription.Text = defectItem.Description;*/
                /*   txtName.Text = defectItem.Name;
                   txtDescription.Text = defectItem.Description;*/

            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to update db. Error: " + ex.Message);
            }
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
                    break;
                case 't':
                    defectItem = treeView1.SelectedNode.Tag as DefectType;
                    break;
                case 'p':
                    defectItem = treeView1.SelectedNode.Tag as DefectPosition;
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
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

  

        private void label2_Click(object sender, EventArgs e)
        {

        }

  

   

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            qs.clearList();
            treeView1.Nodes.Clear();
            qs.selectDefects();
            qs.selectDefectTypes();
            qs.selectDefectPosition();
            printTree();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }
    }
}
