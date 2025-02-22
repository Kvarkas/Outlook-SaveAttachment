using System;
using System.Windows.Forms;

namespace OutlookAddIn
{
    public partial class SettingsForm : Form
    {
        // Make the FolderPath, MinAttachmentSize, MaxAttachmentSize, ExcludedExtensions, and Active properties public
        public string FolderPath { get; private set; }
        public long MinAttachmentSize { get; private set; }
        public long MaxAttachmentSize { get; private set; }
        public string ExcludedExtensions { get; private set; }
        public bool Active { get; private set; }

        public SettingsForm(string currentFolderPath, long currentMinSize, long currentMaxSize, string currentExcludedExtensions, bool currentActive)
        {
            InitializeComponent();
            txtFolderPath.Text = currentFolderPath;
            numMinAttachmentSize.Value = currentMinSize;
            numMaxAttachmentSize.Value = currentMaxSize;
            txtExcludedExtensions.Text = currentExcludedExtensions;
            chkActive.Checked = currentActive;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select a folder to save email attachments";
                folderDialog.ShowNewFolderButton = true; // Allow creating new folders

                // Set the initial directory (if a folder is already selected)
                if (!string.IsNullOrEmpty(txtFolderPath.Text))
                {
                    folderDialog.SelectedPath = txtFolderPath.Text;
                }

                // Show the dialog and check if the user clicked OK
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    // Update the text box with the selected folder path
                    txtFolderPath.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Set the properties to the values in the form
            FolderPath = txtFolderPath.Text;
            MinAttachmentSize = (long)numMinAttachmentSize.Value;
            MaxAttachmentSize = (long)numMaxAttachmentSize.Value;
            ExcludedExtensions = txtExcludedExtensions.Text;
            Active = chkActive.Checked;

            // Close the form and indicate success
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Close the form without saving
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}