using OutlookAddIn;

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Office = Microsoft.Office.Core;

namespace Outlook_SaveAttachment
{
    [ComVisible(true)]
    public class Ribbon : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("Outlook_SaveAttachment.Ribbon.xml");
        }

        public void OnSettingsButtonClick(Office.IRibbonControl control)
        {
            ShowSettingsForm();
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

        private static string GetResourceText(string resourceName)
        {
            var asm = typeof(Ribbon).Assembly;
            using (var stream = asm.GetManifestResourceStream(resourceName))
            {
                if (stream == null) return null;
                using (var reader = new System.IO.StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
