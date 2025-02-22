namespace OutlookAddIn
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown numMinAttachmentSize;
        private System.Windows.Forms.NumericUpDown numMaxAttachmentSize;
        private System.Windows.Forms.TextBox txtExcludedExtensions;
        private System.Windows.Forms.Label lblFolderPath;
        private System.Windows.Forms.Label lblMinAttachmentSize;
        private System.Windows.Forms.Label lblMaxAttachmentSize;
        private System.Windows.Forms.Label lblExcludedExtensions;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Label lblActive;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.numMinAttachmentSize = new System.Windows.Forms.NumericUpDown();
            this.numMaxAttachmentSize = new System.Windows.Forms.NumericUpDown();
            this.txtExcludedExtensions = new System.Windows.Forms.TextBox();
            this.lblFolderPath = new System.Windows.Forms.Label();
            this.lblMinAttachmentSize = new System.Windows.Forms.Label();
            this.lblMaxAttachmentSize = new System.Windows.Forms.Label();
            this.lblExcludedExtensions = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.lblActive = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numMinAttachmentSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxAttachmentSize)).BeginInit();
            this.SuspendLayout();

            // txtFolderPath
            this.txtFolderPath.Location = new System.Drawing.Point(150, 20);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(300, 20);
            this.txtFolderPath.TabIndex = 0;

            // btnBrowse
            this.btnBrowse.Location = new System.Drawing.Point(460, 18);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(380, 220);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(460, 220);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // numMinAttachmentSize
            this.numMinAttachmentSize.Location = new System.Drawing.Point(150, 60);
            this.numMinAttachmentSize.Maximum = new decimal(new int[] {
            104857600, // 100 MB
            0,
            0,
            0});
            this.numMinAttachmentSize.Name = "numMinAttachmentSize";
            this.numMinAttachmentSize.Size = new System.Drawing.Size(120, 20);
            this.numMinAttachmentSize.TabIndex = 4;

            // numMaxAttachmentSize
            this.numMaxAttachmentSize.Location = new System.Drawing.Point(150, 100);
            this.numMaxAttachmentSize.Maximum = new decimal(new int[] {
            104857600, // 100 MB
            0,
            0,
            0});
            this.numMaxAttachmentSize.Name = "numMaxAttachmentSize";
            this.numMaxAttachmentSize.Size = new System.Drawing.Size(120, 20);
            this.numMaxAttachmentSize.TabIndex = 5;

            // txtExcludedExtensions
            this.txtExcludedExtensions.Location = new System.Drawing.Point(150, 140);
            this.txtExcludedExtensions.Name = "txtExcludedExtensions";
            this.txtExcludedExtensions.Size = new System.Drawing.Size(300, 20);
            this.txtExcludedExtensions.TabIndex = 6;

            // lblFolderPath
            this.lblFolderPath.AutoSize = true;
            this.lblFolderPath.Location = new System.Drawing.Point(20, 23);
            this.lblFolderPath.Name = "lblFolderPath";
            this.lblFolderPath.Size = new System.Drawing.Size(64, 13);
            this.lblFolderPath.TabIndex = 7;
            this.lblFolderPath.Text = "Folder Path:";

            // lblMinAttachmentSize
            this.lblMinAttachmentSize.AutoSize = true;
            this.lblMinAttachmentSize.Location = new System.Drawing.Point(20, 63);
            this.lblMinAttachmentSize.Name = "lblMinAttachmentSize";
            this.lblMinAttachmentSize.Size = new System.Drawing.Size(107, 13);
            this.lblMinAttachmentSize.TabIndex = 8;
            this.lblMinAttachmentSize.Text = "Min Attachment Size:";

            // lblMaxAttachmentSize
            this.lblMaxAttachmentSize.AutoSize = true;
            this.lblMaxAttachmentSize.Location = new System.Drawing.Point(20, 103);
            this.lblMaxAttachmentSize.Name = "lblMaxAttachmentSize";
            this.lblMaxAttachmentSize.Size = new System.Drawing.Size(110, 13);
            this.lblMaxAttachmentSize.TabIndex = 9;
            this.lblMaxAttachmentSize.Text = "Max Attachment Size:";

            // lblExcludedExtensions
            this.lblExcludedExtensions.AutoSize = true;
            this.lblExcludedExtensions.Location = new System.Drawing.Point(20, 143);
            this.lblExcludedExtensions.Name = "lblExcludedExtensions";
            this.lblExcludedExtensions.Size = new System.Drawing.Size(104, 13);
            this.lblExcludedExtensions.TabIndex = 10;
            this.lblExcludedExtensions.Text = "Excluded Extensions:";

            // chkActive
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(150, 180);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(56, 17);
            this.chkActive.TabIndex = 11;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;

            // lblActive
            this.lblActive.AutoSize = true;
            this.lblActive.Location = new System.Drawing.Point(20, 181);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(40, 13);
            this.lblActive.TabIndex = 12;
            this.lblActive.Text = "Active:";

            // SettingsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 260);
            this.Controls.Add(this.lblActive);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.lblExcludedExtensions);
            this.Controls.Add(this.lblMaxAttachmentSize);
            this.Controls.Add(this.lblMinAttachmentSize);
            this.Controls.Add(this.lblFolderPath);
            this.Controls.Add(this.txtExcludedExtensions);
            this.Controls.Add(this.numMaxAttachmentSize);
            this.Controls.Add(this.numMinAttachmentSize);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFolderPath);
            this.Name = "SettingsForm";
            this.Text = "Attachment Settings";
            ((System.ComponentModel.ISupportInitialize)(this.numMinAttachmentSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxAttachmentSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}