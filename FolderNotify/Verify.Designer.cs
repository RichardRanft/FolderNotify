namespace FolderNotify
{
    /* Summary
       The Verify form is used to confirm removal of a watched path
       from the application database.                               */
    partial class Verify
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
            this.btnProceedRemove = new System.Windows.Forms.Button();
            this.btnCancelRemove = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblWatchPath = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProceedRemove
            // 
            this.btnProceedRemove.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnProceedRemove.Location = new System.Drawing.Point(50, 84);
            this.btnProceedRemove.Name = "btnProceedRemove";
            this.btnProceedRemove.Size = new System.Drawing.Size(75, 23);
            this.btnProceedRemove.TabIndex = 0;
            this.btnProceedRemove.Text = "Remove";
            this.btnProceedRemove.UseVisualStyleBackColor = true;
            // 
            // btnCancelRemove
            // 
            this.btnCancelRemove.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelRemove.Location = new System.Drawing.Point(165, 84);
            this.btnCancelRemove.Name = "btnCancelRemove";
            this.btnCancelRemove.Size = new System.Drawing.Size(75, 23);
            this.btnCancelRemove.TabIndex = 1;
            this.btnCancelRemove.Text = "Cancel";
            this.btnCancelRemove.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Are you sure?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Remove watcher for";
            // 
            // lblWatchPath
            // 
            this.lblWatchPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWatchPath.AutoSize = true;
            this.lblWatchPath.Location = new System.Drawing.Point(3, 3);
            this.lblWatchPath.MaximumSize = new System.Drawing.Size(266, 0);
            this.lblWatchPath.Name = "lblWatchPath";
            this.lblWatchPath.Size = new System.Drawing.Size(0, 13);
            this.lblWatchPath.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.lblWatchPath);
            this.panel1.Location = new System.Drawing.Point(13, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 46);
            this.panel1.TabIndex = 5;
            // 
            // Verify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 115);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelRemove);
            this.Controls.Add(this.btnProceedRemove);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Verify";
            this.Text = "Confirm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProceedRemove;
        private System.Windows.Forms.Button btnCancelRemove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblWatchPath;
        private System.Windows.Forms.Panel panel1;
    }
}