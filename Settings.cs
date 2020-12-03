using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyUtility
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = File.AppendText(AdfViewer.fileName))
            {   
                sw.WriteLine(txtAdsLinks.Text);
            }
            MessageBox.Show("Save successfully!");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAdsLinks.Clear();
        }

        private void txtAdsLinks_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAdsLinks.Text))
            {
                btnSave.Enabled = true;
                btnClear.Enabled = true;
            }else
            {
                btnSave.Enabled = false;
                btnClear.Enabled = false;
            }
        }
    }
}
