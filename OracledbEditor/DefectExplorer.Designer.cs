
namespace OracledbEditor
{
    partial class DefectExplorer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DefectExplorer));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnPrint = new System.Windows.Forms.Button();
            this.ckBoxHidden = new System.Windows.Forms.CheckBox();
            this.tabSearchType = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tlBtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tlBtnSearch = new System.Windows.Forms.ToolStripButton();
            this.tlTxtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.tlBtnPrintCr = new System.Windows.Forms.ToolStripButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabSearchType.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(247, 395);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(6, 109);
            this.txtDescription.MaxLength = 254;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(362, 20);
            this.txtDescription.TabIndex = 12;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(6, 70);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(362, 20);
            this.txtName.TabIndex = 11;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Description";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Name";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnPrint);
            this.splitContainer1.Panel2.Controls.Add(this.ckBoxHidden);
            this.splitContainer1.Panel2.Controls.Add(this.tabSearchType);
            this.splitContainer1.Panel2.Controls.Add(this.btnClear);
            this.splitContainer1.Panel2.Controls.Add(this.btnSearch);
            this.splitContainer1.Panel2.Controls.Add(this.btnDelete);
            this.splitContainer1.Panel2.Controls.Add(this.btnInsert);
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.txtName);
            this.splitContainer1.Panel2.Controls.Add(this.txtDescription);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(622, 395);
            this.splitContainer1.SplitterDistance = 247;
            this.splitContainer1.TabIndex = 16;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(306, 28);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(61, 23);
            this.btnPrint.TabIndex = 22;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click_1);
            // 
            // ckBoxHidden
            // 
            this.ckBoxHidden.AutoSize = true;
            this.ckBoxHidden.Location = new System.Drawing.Point(10, 135);
            this.ckBoxHidden.Name = "ckBoxHidden";
            this.ckBoxHidden.Size = new System.Drawing.Size(60, 17);
            this.ckBoxHidden.TabIndex = 21;
            this.ckBoxHidden.Text = "Hidden";
            this.ckBoxHidden.UseVisualStyleBackColor = true;
            this.ckBoxHidden.CheckedChanged += new System.EventHandler(this.ckBoxHidden_CheckedChanged);
            // 
            // tabSearchType
            // 
            this.tabSearchType.Controls.Add(this.tabPage1);
            this.tabSearchType.Controls.Add(this.tabPage2);
            this.tabSearchType.Controls.Add(this.tabPage3);
            this.tabSearchType.Location = new System.Drawing.Point(6, 3);
            this.tabSearchType.Name = "tabSearchType";
            this.tabSearchType.SelectedIndex = 0;
            this.tabSearchType.Size = new System.Drawing.Size(294, 21);
            this.tabSearchType.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(286, 0);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Defect";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(286, 0);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Defect type";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(286, 0);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Defect position";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(247, 28);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(57, 23);
            this.btnClear.TabIndex = 18;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(189, 28);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(57, 23);
            this.btnSearch.TabIndex = 17;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(128, 28);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(57, 23);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(68, 28);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(57, 23);
            this.btnInsert.TabIndex = 16;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(6, 28);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(57, 23);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tlBtnRefresh
            // 
            this.tlBtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlBtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tlBtnRefresh.Image")));
            this.tlBtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlBtnRefresh.Name = "tlBtnRefresh";
            this.tlBtnRefresh.Size = new System.Drawing.Size(23, 22);
            this.tlBtnRefresh.Text = "Refresh";
            this.tlBtnRefresh.ToolTipText = "Refresh";
            this.tlBtnRefresh.Click += new System.EventHandler(this.tlBtnRefresh_Click);
            // 
            // tlBtnSearch
            // 
            this.tlBtnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlBtnSearch.Image = ((System.Drawing.Image)(resources.GetObject("tlBtnSearch.Image")));
            this.tlBtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlBtnSearch.Name = "tlBtnSearch";
            this.tlBtnSearch.Size = new System.Drawing.Size(23, 22);
            this.tlBtnSearch.Text = "Search";
            this.tlBtnSearch.ToolTipText = "Search";
            this.tlBtnSearch.Click += new System.EventHandler(this.tlBtnSearch_Click_1);
            // 
            // tlTxtSearch
            // 
            this.tlTxtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlTxtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tlTxtSearch.Name = "tlTxtSearch";
            this.tlTxtSearch.Size = new System.Drawing.Size(150, 25);
            this.tlTxtSearch.ToolTipText = "Enter your search here";
            this.tlTxtSearch.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlBtnSearch,
            this.tlTxtSearch,
            this.toolStripButton2,
            this.toolStripButton1,
            this.tlBtnRefresh,
            this.toolStripButton3,
            this.tlBtnPrintCr});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(642, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            this.toolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip_ItemClicked);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "tlBtnNext";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Expand";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // tlBtnPrintCr
            // 
            this.tlBtnPrintCr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlBtnPrintCr.Image = ((System.Drawing.Image)(resources.GetObject("tlBtnPrintCr.Image")));
            this.tlBtnPrintCr.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlBtnPrintCr.Name = "tlBtnPrintCr";
            this.tlBtnPrintCr.Size = new System.Drawing.Size(23, 22);
            this.tlBtnPrintCr.Text = "Print";
            this.tlBtnPrintCr.Click += new System.EventHandler(this.tlBtnPrintCr_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "defect.png");
            this.imageList1.Images.SetKeyName(1, "defectposition.png");
            this.imageList1.Images.SetKeyName(2, "defecttype.png");
            this.imageList1.Images.SetKeyName(3, "defectHidden.png");
            this.imageList1.Images.SetKeyName(4, "defectpositionHidden.png");
            this.imageList1.Images.SetKeyName(5, "defecttypeHidden.png");
            // 
            // DefectExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 430);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.splitContainer1);
            this.Name = "DefectExplorer";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabSearchType.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ToolStripButton tlBtnRefresh;
        private System.Windows.Forms.ToolStripButton tlBtnSearch;
        private System.Windows.Forms.ToolStripTextBox tlTxtSearch;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TabControl tabSearchType;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolStripButton tlBtnPrintCr;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.CheckBox ckBoxHidden;
        private System.Windows.Forms.Button btnPrint;
    }
}

