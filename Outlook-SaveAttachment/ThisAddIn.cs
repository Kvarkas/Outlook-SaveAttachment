using OutlookAddIn;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace Outlook_SaveAttachment
{
    public partial class ThisAddIn
    {
        private Outlook.Items _items;
        private Ribbon _ribbon;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            try
            {
                Outlook.Application application = this.Application;
                Outlook.NameSpace ns = application.Session;
                Outlook.MAPIFolder inbox = ns.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
                _items = inbox.Items;

                _items.ItemAdd += new Outlook.ItemsEvents_ItemAddEventHandler(Items_ItemAdd);

                _ribbon = new Ribbon();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during startup: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Items_ItemAdd(object item)
        {
            if (item is Outlook.MailItem mailItem && Properties.Settings.Default.Active)
            {
                // Check if the email has attachments
                if (mailItem.Attachments.Count > 0)
                {
                    SaveAttachments(mailItem);
                }
            }
        }

        private void SaveAttachments(Outlook.MailItem mailItem)
        {
            // Get the folder path from settings
            string saveFolder = Properties.Settings.Default.AttachmentFolderPath;

            // If the setting is empty, show the settings form to the user
            if (string.IsNullOrEmpty(saveFolder))
            {
                MessageBox.Show("Please configure the attachment folder path.");
                ShowSettingsForm();

                // Check again after the settings form is closed
                saveFolder = Properties.Settings.Default.AttachmentFolderPath;

                // If the user didn't set a folder path, use the default
                if (string.IsNullOrEmpty(saveFolder))
                {
                    saveFolder = @"C:\EmailAttachments"; // Default folder
                }
            }

            // Get the minimum and maximum attachment sizes and excluded extensions from settings
            long minAttachmentSize = Properties.Settings.Default.MinAttachmentSize;
            long maxAttachmentSize = Properties.Settings.Default.MaxAttachmentSize;
            string[] excludedExtensions = Properties.Settings.Default.ExcludedExtensions
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            // Extract sender and receiver information
            string senderEmail = mailItem.SenderEmailAddress ?? "UnknownSender";
            string senderName = mailItem.SenderName ?? "UnknownSender";
            string receiverEmail = mailItem.ReceivedByName ?? "UnknownReceiver"; // Receiver's email
            DateTime receivedDate = mailItem.ReceivedTime;

            // Format the sender's name
            string senderDisplayName = senderEmail;
            if (!senderName.Equals(senderEmail, StringComparison.OrdinalIgnoreCase))
            {
                senderDisplayName = $"{senderEmail} ({senderName})";
            }

            // Create the folder structure
            string year = receivedDate.Year.ToString();
            string month = receivedDate.Month.ToString("00"); // Ensure two digits
            string day = receivedDate.Day.ToString("00"); // Ensure two digits

            string emailFolder = Path.Combine(saveFolder, receiverEmail, year, month, day, senderDisplayName);

            // Ensure the folder exists
            if (!Directory.Exists(emailFolder))
            {
                Directory.CreateDirectory(emailFolder);
            }

            // Save each attachment
            foreach (Outlook.Attachment attachment in mailItem.Attachments)
            {
                string fileName = attachment.FileName;
                string fileExtension = Path.GetExtension(fileName)?.ToLowerInvariant();

                // Check if the attachment should be skipped
                if (ShouldSkipAttachment(attachment, minAttachmentSize, maxAttachmentSize, excludedExtensions, fileExtension))
                {
                    continue;
                }

                string filePath = Path.Combine(emailFolder, fileName);

                // Check if the file already exists
                if (File.Exists(filePath))
                {
                    // Skip saving this attachment
                    continue;
                }

                // Save the attachment
                attachment.SaveAsFile(filePath);
            }
        }

        private bool ShouldSkipAttachment(Outlook.Attachment attachment, long minAttachmentSize, long maxAttachmentSize, string[] excludedExtensions, string fileExtension)
        {
            // Skip if the attachment size is smaller than the minimum allowed size
            if (attachment.Size < minAttachmentSize)
            {
                Console.WriteLine($"Skipped small attachment: {attachment.FileName} (Size: {attachment.Size} bytes)");
                return true;
            }

            // Skip if the attachment size exceeds the maximum allowed size
            if (attachment.Size > maxAttachmentSize)
            {
                Console.WriteLine($"Skipped large attachment: {attachment.FileName} (Size: {attachment.Size} bytes)");
                return true;
            }

            // Skip if the attachment extension is in the excluded list
            if (excludedExtensions.Contains(fileExtension))
            {
                Console.WriteLine($"Skipped excluded attachment: {attachment.FileName} (Extension: {fileExtension})");
                return true;
            }

            return false;
        }


        private void ShowSettingsForm()
        {
            SettingsForm settingsForm = new SettingsForm(
                Properties.Settings.Default.AttachmentFolderPath,
                Properties.Settings.Default.MinAttachmentSize,
                Properties.Settings.Default.MaxAttachmentSize,
                Properties.Settings.Default.ExcludedExtensions,
                Properties.Settings.Default.Active);

            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                // Save the new settings
                Properties.Settings.Default.AttachmentFolderPath = settingsForm.FolderPath;
                Properties.Settings.Default.MinAttachmentSize = settingsForm.MinAttachmentSize;
                Properties.Settings.Default.MaxAttachmentSize = settingsForm.MaxAttachmentSize;
                Properties.Settings.Default.ExcludedExtensions = settingsForm.ExcludedExtensions;
                Properties.Settings.Default.Active = settingsForm.Active;
                Properties.Settings.Default.Save();

                // Notify the user
                MessageBox.Show("Settings saved successfully!", "Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Settings were not saved.", "Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            if (_items != null)
            {
                Marshal.ReleaseComObject(_items);
            }
        }

        

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }
}
