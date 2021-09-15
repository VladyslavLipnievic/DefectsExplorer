
namespace OracledbEditor
{
    partial class RelationForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.btnAddRel = new System.Windows.Forms.Button();
            this.btnRemoveRel = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(331, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(326, 42);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(227, 303);
            this.listBox2.TabIndex = 3;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btnAddRel
            // 
            this.btnAddRel.Location = new System.Drawing.Point(264, 202);
            this.btnAddRel.Name = "btnAddRel";
            this.btnAddRel.Size = new System.Drawing.Size(32, 23);
            this.btnAddRel.TabIndex = 4;
            this.btnAddRel.Text = "<";
            this.btnAddRel.UseVisualStyleBackColor = true;
            this.btnAddRel.Click += new System.EventHandler(this.btnAddRel_Click);
            // 
            // btnRemoveRel
            // 
            this.btnRemoveRel.Location = new System.Drawing.Point(264, 158);
            this.btnRemoveRel.Name = "btnRemoveRel";
            this.btnRemoveRel.Size = new System.Drawing.Size(32, 23);
            this.btnRemoveRel.TabIndex = 5;
            this.btnRemoveRel.Text = ">";
            this.btnRemoveRel.UseVisualStyleBackColor = true;
            this.btnRemoveRel.Click += new System.EventHandler(this.btnRemoveRel_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 41);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(224, 303);
            this.listBox1.TabIndex = 6;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged_1);
            // 
            // RelationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 354);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnRemoveRel);
            this.Controls.Add(this.btnAddRel);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RelationForm";
            this.Text = "RelationForm";
            this.Load += new System.EventHandler(this.RelationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button btnAddRel;
        private System.Windows.Forms.Button btnRemoveRel;
        private System.Windows.Forms.ListBox listBox1;
    }
}