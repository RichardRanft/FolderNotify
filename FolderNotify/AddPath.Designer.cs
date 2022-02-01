namespace FolderNotify
{
    /* Summary
       The AddPath form is used to add a local or UNC path to the
       watch database. By default, new path watchers are enabled and
       created when added.                                           */
    partial class AddPath
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPath));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddPath = new System.Windows.Forms.Button();
            this.tbxPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(86, 31);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAddPath
            // 
            this.btnAddPath.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAddPath.Location = new System.Drawing.Point(5, 31);
            this.btnAddPath.Name = "btnAddPath";
            this.btnAddPath.Size = new System.Drawing.Size(75, 23);
            this.btnAddPath.TabIndex = 6;
            this.btnAddPath.Text = "Load";
            this.btnAddPath.UseVisualStyleBackColor = true;
            // 
            // tbxPath
            // 
            this.tbxPath.Location = new System.Drawing.Point(76, 5);
            this.tbxPath.Name = "tbxPath";
            this.tbxPath.Size = new System.Drawing.Size(686, 20);
            this.tbxPath.TabIndex = 5;
            this.tbxPath.TextChanged += new System.EventHandler(this.tbxPath_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Folder Path:";
            // 
            // AddPath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 58);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddPath);
            this.Controls.Add(this.tbxPath);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddPath";
            this.Text = "AddPath";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddPath;
        private System.Windows.Forms.TextBox tbxPath;
        private System.Windows.Forms.Label label1;
    }
}