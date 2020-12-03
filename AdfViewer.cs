using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace MyUtility
{
    public partial class AdfViewer : Form
    {
        static bool isRunning = false;
        System.Threading.Thread thread;
        const int REFRESH_VIEWADS = 1;
        const int CHECK_INTERNET_CONNECTION = 2;
        const int VIEWADS = 3;

        #region Methods Auto-Generated

        public AdfViewer()
        {
            InitializeComponent();
            //StartUpManager.AddApplicationToCurrentUserStartup("AdsClicker");            
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool AnimateWindow(System.IntPtr hWnd, int time, AnimateWindowFlags flags);
        [System.Flags]
        enum AnimateWindowFlags
        {
            AW_HOR_POSITIVE = 0x00000001,
            AW_HOR_NEGATIVE = 0x00000002,
            AW_VER_POSITIVE = 0x00000004,
            AW_VER_NEGATIVE = 0x00000008,
            AW_CENTER = 0x00000010,
            AW_HIDE = 0x00010000,
            AW_ACTIVATE = 0x00020000,
            AW_SLIDE = 0x00040000,
            AW_BLEND = 0x00080000
        }

        private void WindowsInSystemTray(bool inTray)
        {
            if (inTray)
            {
                this.ShowInTaskbar = false;
                AnimateWindow(this.Handle, 50, AnimateWindowFlags.AW_BLEND | AnimateWindowFlags.AW_HIDE);
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(500);
            }
            else
            {
                this.ShowInTaskbar = true;
                this.WindowState = FormWindowState.Normal;
                AnimateWindow(this.Handle, 700, AnimateWindowFlags.AW_BLEND | AnimateWindowFlags.AW_ACTIVATE);
                this.Activate();
                notifyIcon1.Visible = false;
            }
        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            //backgroundWorker1.RunWorkerAsync(1);                       
            //GetListAdsRequest();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //backgroundWorker1.RunWorkerAsync(2);  
            //CheckInternetConnection();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (e.Cancel)
            {
                backgroundWorker1.CancelAsync();
            }
            else
            {
                if (e.Argument.Equals(REFRESH_VIEWADS))
                {
                    //thread = new System.Threading.Thread(RefreshPlayList);
                }
                else if (e.Argument.Equals(CHECK_INTERNET_CONNECTION))
                {
                    thread = new System.Threading.Thread(CheckInternetConnection);
                }
                else
                {   
                    string link = (string)e.Argument;                    
                    //WebBrowser wbr = e.Argument as WebBrowser;
                    //thread = new Thread(new ParameterizedThreadStart(ViewAd));
                    //thread.Start(link);                                       
                    //ViewAds(link);                       
                    //GetListAds(wbr);
                }
                //thread.Start();                
            }        
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {            
            myBrowser.Refresh();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {   
            thread.Abort();
            thread = null;
        }

        private void AdsClicker_Load(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipText = "Your application is still running" + System.Environment.NewLine + "Double click into icon to show application.";
            //WindowsInSystemTray(true);
            //GetListAdsRequest(); 
        }

        private void showMainWindowToolStrip_Click(object sender, EventArgs e)
        {
            WindowsInSystemTray(false);
        }

        private void exitToolStrip_Click(object sender, EventArgs e)
        {
            notifyIcon1.Dispose();            
            this.Close();
            this.Dispose();   
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowsInSystemTray(false);
        }

        private void AdsClicker_FormClosing(object sender, FormClosingEventArgs e)
        {            
            e.Cancel = true;
            WindowsInSystemTray(true);
        }

        private void AdsClicker_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                //WindowsInSystemTray(true);
            }
        }

        private void btnFinishedLogin_Click(object sender, EventArgs e)
        {
            //btnFinishedLogin.Visible = false;
            //GetListAdsRequest();
        }
        
        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings st = new Settings();
            st.ShowDialog();
        }

        private void btnViewAds_Click(object sender, EventArgs e)
        {
            GetListAdsRequest();
        }

        #endregion

        #region Methods

        const string VIEW_ADS_URL = "https://www.neobux.com/m/v/";                
        const string LOGIN_URL = "https://www.neobux.com/m/l/";
        const string USERNAME = "phatnt987";
        const string PASSWORD = "pA55WordFormE123";
        public static int index = 1, len = 0;        
        bool finished = false;
        public static string link = "";
        public static string fileName = "AdsLinksList.txt";

        private void LoginRequest()
        {
            if (!IsAvailableNetworkActive())
            {
                picLoading.Visible = true;
                lblConnectionErr.Visible = true;
            }
            else
            {
                myBrowser.Navigate(LOGIN_URL);
                myBrowser.ScriptErrorsSuppressed = true;
                myBrowser.DocumentCompleted += wbr_DocumentCompleted_LoginRequest;
            }
        }

        private void wbr_DocumentCompleted_LoginRequest(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser wbr = sender as WebBrowser;
            try
            {
                if (wbr.ReadyState == WebBrowserReadyState.Complete)
                {
                    lblLoading.Visible = false;
                    picLoading.Visible = false;

                    HtmlElement form = wbr.Document.GetElementById("loginform");
                    if (form != null)
                    {
                        wbr.Document.GetElementById("Kf1").SetAttribute("value", USERNAME);
                        wbr.Document.GetElementById("Kf2").SetAttribute("value", PASSWORD);

                        string type = wbr.Document.GetElementById("Kf3").GetAttribute("type");
                        if (type == "hidden")
                        {
                            form.InvokeMember("submit");
                            System.Threading.Thread.Sleep(1000);
                            GetListAdsRequest();
                        }
                        else
                        {                         
                            //btnFinishedLogin.Visible = true;                            
                        }

                        myBrowser.DocumentCompleted -= wbr_DocumentCompleted_LoginRequest;
                    }
                }
            }
            catch (Exception ex)
            {
                lblConnectionErr.Text = ex.Message;
            }
        }

        private void GetListAdsRequest()
        {
            if (!IsAvailableNetworkActive())
            {
                picLoading.Visible = true;
                lblConnectionErr.Visible = true;
                isRunning = false;
            }
            else
            {
                isRunning = true;
                lblLoading.Visible = true;
                myBrowser.Navigate(VIEW_ADS_URL);                
                myBrowser.DocumentCompleted += wbr_DocumentCompleted_ListAdsRequest;
            }
        }

        private void wbr_DocumentCompleted_ListAdsRequest(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser wbr = sender as WebBrowser;
            try
            {
                //if (wbr.ReadyState == WebBrowserReadyState.Interactive)
                //{
                    lblLoading.Visible = false;
                    picLoading.Visible = false;
                //}

                if (wbr.ReadyState == WebBrowserReadyState.Complete)
                {
                    GetListAds();
                    //HtmlElement acc = wbr.Document.GetElementById("t_conta");
                    //if (acc == null)
                    //{
                    //    LoginRequest();                        
                    //}else
                    //{                        
                    //    GetListAds(wbr);
                    //}

                    myBrowser.DocumentCompleted -= wbr_DocumentCompleted_ListAdsRequest;
                }
            }
            catch (Exception ex)
            {                
                lblConnectionErr.Text = ex.Message;                
            }
        }

        private void GetListAds()
        {            
            var lines = File.ReadAllLines(fileName);
            len = lines.Length;
            foreach (var line in lines)
            {
                link = line;
                ViewAds v = new ViewAds();
                v.Show();

                if (ViewAds.finished)
                {
                    Thread.Sleep(3000);
                    continue;
                }
            }
        }

        private void GetListAds(WebBrowser wbr)
        {            
            HtmlElementCollection ads = default(HtmlElementCollection);
            ads = wbr.Document.GetElementsByTagName("div");
            foreach (HtmlElement curAd in ads)
            {
                if (curAd.GetAttribute("className").ToString() == "adfu")
                {
                    string codeString = String.Format("$('.adfu').length;");
                    object value = wbr.Document.InvokeScript("eval", new[] { codeString });
                    int.TryParse(value.ToString(), out len);

                    curAd.InvokeMember("Click");
                    curAd.SetAttribute("class", "ad0");
                    HtmlElement el = curAd.Parent.NextSibling.FirstChild.NextSibling.FirstChild;
                    link = el.GetAttribute("href") + "&vl=3F00165BBABA60884D0E91CC3B802C0E60BC43EADACD3E2EA7B02755169DB84E31558BCB3C29C1185E9F9BC550C2410DB45A2D774A1BD172";

                    //backgroundWorker1.RunWorkerAsync(wbr);
                    if (index == 1)
                    {
                        lblAds.Visible = true;
                        lblAds.Text = "Viewing ad: " + index + " of " + len;

                        //backgroundWorker1.RunWorkerAsync(link);
                        
                        ViewAds v = new ViewAds();
                        v.Show();                        

                        //thread = new Thread(new ParameterizedThreadStart(ViewAd));
                        //thread.Start(link);    
                        index++;
                        if (ViewAds.finished)
                        {                            
                            wbr.Refresh();                            
                        }                        
                    }                    
                }
                else if (curAd.GetAttribute("className").ToString() == "adf")
                {
                    string codeString = String.Format("$('.adf').length;");
                    object value = wbr.Document.InvokeScript("eval", new[] { codeString });
                    int.TryParse(value.ToString(), out len);

                    curAd.InvokeMember("Click");
                    curAd.SetAttribute("class", "ad0");
                    HtmlElement el = curAd.Parent.NextSibling.FirstChild.NextSibling.FirstChild;
                    link = el.GetAttribute("href") + "&vl=3F00165BBABA60884D0E91CC3B802C0E60BC43EADACD3E2EA7B02755169DB84E31558BCB3C29C1185E9F9BC550C2410DB45A2D774A1BD172";

                    //backgroundWorker1.RunWorkerAsync(wbr);
                    if (index == 1)
                    {
                        lblAds.Visible = true;
                        lblAds.Text = "Viewing ad: " + index + " of " + len;

                        //backgroundWorker1.RunWorkerAsync(link);

                        ViewAds v = new ViewAds();
                        v.Show();

                        //thread = new Thread(new ParameterizedThreadStart(ViewAd));
                        //thread.Start(link);    
                        index++;
                        if (ViewAds.finished)
                        {
                            wbr.Refresh();
                        }
                    }
                }
                else if (curAd.GetAttribute("className").ToString() == "ad30")
                {
                    string codeString = String.Format("$('.mbx .ad30').length;");
                    object value = wbr.Document.InvokeScript("eval", new[] { codeString });
                    int.TryParse(value.ToString(), out len);

                    curAd.InvokeMember("Click");
                    curAd.SetAttribute("class", "ad0");
                    HtmlElement el = curAd.Parent.NextSibling.FirstChild.NextSibling.FirstChild;
                    link = el.GetAttribute("href") + "&vl=3F00165BBABA60884D0E91CC3B802C0E60BC43EADACD3E2EA7B02755169DB84E31558BCB3C29C1185E9F9BC550C2410DB45A2D774A1BD172";

                    //backgroundWorker1.RunWorkerAsync(wbr);
                    if (index == 1)
                    {
                        lblAds.Visible = true;
                        lblAds.Text = "Viewing ad: " + index + " of " + len;

                        //backgroundWorker1.RunWorkerAsync(link);

                        ViewAds v = new ViewAds();
                        v.Show();

                        //thread = new Thread(new ParameterizedThreadStart(ViewAd));
                        //thread.Start(link);    
                        index++;
                        if (ViewAds.finished)
                        {
                            wbr.Refresh();
                        }
                    }
                }
            }
        }

        private void ViewAd(object obj)
        {
            do
            {
                System.Threading.Thread.Sleep(3000);                
            } while (!IsAvailableNetworkActive());

            string link = (string)obj;            
            WebBrowser wbr = new WebBrowser();
            wbr.Navigate(link);
            wbr.ScriptErrorsSuppressed = true;
            wbr.DocumentCompleted += wbr_DocumentCompleted_ViewAdsRequest;                            
        }

        private void wbr_DocumentCompleted_ViewAdsRequest(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser wbr = sender as WebBrowser;
            try
            {
                if (wbr.ReadyState == WebBrowserReadyState.Complete)
                {
                    HtmlElement closePanel = wbr.Document.GetElementById("o1");
                    do
                    {
                        System.Threading.Thread.Sleep(3000);
                    } while (closePanel == null);

                    picLoading.Visible = false;
                    lblLoading.Visible = false;

                    HtmlElementCollection collections = wbr.Document.GetElementsByTagName("a");
                    foreach (HtmlElement element in collections)
                    {
                        if (element.GetAttribute("class") == "button small2 orange")
                        {
                            element.InvokeMember("Click");
                        }
                    }

                    finished = true;
                    wbr.DocumentCompleted -= wbr_DocumentCompleted_ViewAdsRequest;
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;

                lblLoading.Text = ex.Message;
            }
        }

        private void ViewAd(WebBrowser wbr, object obj)
        {
            string link = (string)obj;
            //System.Text.StringBuilder scriptCode = new System.Text.StringBuilder();
            //scriptCode.Append("function ShowPopup(){");
            //scriptCode.AppendFormat(" var w=window.open('{0}','_blank');", link);
            //scriptCode.Append("}");
            //myBrowser.Document.InvokeScript("execScript", new Object[] { scriptCode.ToString(), "JavaScript" });
            //myBrowser.Document.InvokeScript("ExecuteJS");
            HtmlElement scriptEl = myBrowser.Document.CreateElement("script");
            scriptEl.InnerText = "function ShowPopup() { window.open('" + link + "','_blank');" + " }";
            myBrowser.Document.GetElementsByTagName("head")[0].AppendChild(scriptEl);
            myBrowser.Document.InvokeScript("ShowPopup");
            System.Threading.Thread.Sleep(10000);
        }

        // Check if Internet is connected?
        public static bool IsAvailableNetworkActive()
        {         
            var interfaces = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();
            foreach (var item in interfaces)
            {
                if (item.NetworkInterfaceType == System.Net.NetworkInformation.NetworkInterfaceType.Loopback
                    || item.NetworkInterfaceType == System.Net.NetworkInformation.NetworkInterfaceType.Tunnel)
                    continue;
              
                if (item.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up 
                    && item.GetIPv4Statistics().BytesSent > 0 && item.GetIPv4Statistics().BytesReceived > 0)
                {
                    return true;
                }
            }
            return false;
        }
        
        private void CheckInternetConnection()
        {
            if (!IsAvailableNetworkActive())
            {
                myBrowser.Visible = false;
                picLoading.Visible = true;
                lblConnectionErr.Visible = true;
            }
            else if (!isRunning)
            {
                lblConnectionErr.Visible = false;
                picLoading.Visible = false;
                myBrowser.Visible = true;                
            }
        }
        #endregion       
    }
}
