namespace MyUtility
{
    partial class ViewAds
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
            this.myBrowser = new System.Windows.Forms.WebBrowser();
            this.lblLoading = new System.Windows.Forms.Label();
            this.lblConnectionErr = new System.Windows.Forms.Label();
            this.picLoading = new System.Windows.Forms.PictureBox();
            this.lblAds = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // myBrowser
            // 
            this.myBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myBrowser.Location = new System.Drawing.Point(1, 33);
            this.myBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.myBrowser.Name = "myBrowser";
            this.myBrowser.Size = new System.Drawing.Size(780, 381);
            this.myBrowser.TabIndex = 0;
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.BackColor = System.Drawing.Color.White;
            this.lblLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoading.ForeColor = System.Drawing.Color.Blue;
            this.lblLoading.Location = new System.Drawing.Point(321, 194);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(141, 13);
            this.lblLoading.TabIndex = 2;
            this.lblLoading.Text = "Loading ... Please wait!";
            // 
            // lblConnectionErr
            // 
            this.lblConnectionErr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConnectionErr.AutoSize = true;
            this.lblConnectionErr.BackColor = System.Drawing.Color.White;
            this.lblConnectionErr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectionErr.ForeColor = System.Drawing.Color.Red;
            this.lblConnectionErr.Location = new System.Drawing.Point(218, 195);
            this.lblConnectionErr.Name = "lblConnectionErr";
            this.lblConnectionErr.Size = new System.Drawing.Size(346, 13);
            this.lblConnectionErr.TabIndex = 3;
            this.lblConnectionErr.Text = "Internet Connection Error! Please wait while reconnecting...";
            this.lblConnectionErr.Visible = false;
            // 
            // picLoading
            // 
            this.picLoading.BackColor = System.Drawing.Color.White;
            this.picLoading.Image = global::MyUtility.Properties.Resources.loading1;
            this.picLoading.Location = new System.Drawing.Point(358, 122);
            this.picLoading.Name = "picLoading";
            this.picLoading.Size = new System.Drawing.Size(66, 59);
            this.picLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoading.TabIndex = 4;
            this.picLoading.TabStop = false;
            // 
            // lblAds
            // 
            this.lblAds.AutoSize = true;
            this.lblAds.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAds.ForeColor = System.Drawing.Color.Blue;
            this.lblAds.Location = new System.Drawing.Point(3, 9);
            this.lblAds.Name = "lblAds";
            this.lblAds.Size = new System.Drawing.Size(77, 16);
            this.lblAds.TabIndex = 5;
            this.lblAds.Text = "Viewing ad: ";
            // 
            // ViewAds
            // 
            this.ClientSize = new System.Drawing.Size(782, 365);
            this.Controls.Add(this.lblAds);
            this.Controls.Add(this.picLoading);
            this.Controls.Add(this.lblConnectionErr);
            this.Controls.Add(this.lblLoading);
            this.Controls.Add(this.myBrowser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ViewAds";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View ads";
            this.Load += new System.EventHandler(this.ViewAds_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser myBrowser;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.Label lblConnectionErr;
        private System.Windows.Forms.PictureBox picLoading;
        private System.Windows.Forms.Label lblAds;
    }
}