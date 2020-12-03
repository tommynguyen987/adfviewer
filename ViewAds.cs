using System;
using System.Windows.Forms;

namespace MyUtility
{
    public partial class ViewAds : Form
    {
        public ViewAds()
        {
            InitializeComponent();        
        }
      
        #region Methods

        public static bool finished = false;

        private void ViewAds_Load(object sender, EventArgs e)
        {
            ViewAd(AdfViewer.link);
        }

        private void ViewAd(string link)
        {
            if (!AdfViewer.IsAvailableNetworkActive())
            {
                picLoading.Visible = true;
                lblConnectionErr.Visible = true;             
            }
            else
            {
                lblConnectionErr.Visible = false;             
                myBrowser.Navigate(link);
                myBrowser.ScriptErrorsSuppressed = true;
                myBrowser.DocumentCompleted += wbr_DocumentCompleted_ViewAdsRequest;
                lblAds.Text += AdfViewer.index + " of " + AdfViewer.len;
            }
        }

        private void wbr_DocumentCompleted_ViewAdsRequest(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser wbr = sender as WebBrowser;
            try
            {
                if (wbr.ReadyState == WebBrowserReadyState.Complete)
                {
                    if (AdfViewer.link.StartsWith("http://ouo.io") || 
                        AdfViewer.link.StartsWith("http://uskip.me"))
                    {
                        HtmlElement checkSection = wbr.Document.GetElementById("recaptcha-anchor");
                        do
                        {
                            System.Threading.Thread.Sleep(3000);
                        } while (checkSection == null);
                        checkSection.InvokeMember("Click");
                        System.Threading.Thread.Sleep(6000);
                    }
                    else if (AdfViewer.link.StartsWith("http://bc.vc"))
                    {
                        HtmlElement skipSection = wbr.Document.GetElementById("skip_btt");
                        do
                        {
                            System.Threading.Thread.Sleep(6000);
                        } while (skipSection == null);
                        skipSection.InvokeMember("Click");
                    }
                    else if (AdfViewer.link.StartsWith("http://goadfly.tk") || 
                             AdfViewer.link.StartsWith("http://goadult.tk"))
                    {
                        HtmlElement skipSection = wbr.Document.GetElementById("skip_button");
                        do
                        {
                            System.Threading.Thread.Sleep(6000);
                        } while (skipSection == null);
                        skipSection.InvokeMember("Click");                        
                    }
                    else if (AdfViewer.link.StartsWith("http://linkshrink.net"))
                    {                        
                        HtmlElement skipSection = wbr.Document.GetElementById("btd");
                        do
                        {
                            System.Threading.Thread.Sleep(6000);
                        } while (skipSection == null);
                        skipSection.InvokeMember("Click");
                    }

                    else if (AdfViewer.link.StartsWith("http://goadult.tk"))
                    {
                        HtmlElement skipSection = wbr.Document.GetElementById("skip_button");
                        do
                        {
                            System.Threading.Thread.Sleep(6000);
                        } while (skipSection == null);
                        skipSection.InvokeMember("Click");
                    }        

                    wbr.DocumentCompleted -= wbr_DocumentCompleted_ViewAdsRequest;
                    wbr.Dispose();
                    finished = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;

                lblLoading.Text = ex.Message;
            }
        }
        
        #endregion               
    }
}
