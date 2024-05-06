using SHDocVw;
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
using wakeUp.Service;
using wakeUp.View;

namespace wakeUp
{
    public partial class BlackForm : Form
    {
        System.Windows.Forms.WebBrowser webBrowser;

        private static bool useTimer = true;

        public BlackForm()
        {
            InitializeComponent();

            SetUseTimer(true);
            SetShowClock(true);
            SetShowWhether(false);
        }

        public static bool IsUseTimer()
        {
            return useTimer;
        }

        public void ShowFullScreen(Point location)
        {
            this.Show();
            this.Location = location;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            timer.Start();
        }

        public void CloseFullScreen()
        {
            timer.Stop();
            this.Close();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("HH:mm:ss");

            SetLbTime(time);

            SetUseTimer(useTimer);
        }

        public void SetLbTime(string time)
        {
            if (lbss2.Text != time[7].ToString())
            {
                lbss2.Text = time[7].ToString();
            }
            if (lbss1.Text != time[6].ToString())
            {
                lbss1.Text = time[6].ToString();
            }
            if (lbmm2.Text != time[4].ToString())
            {
                lbmm2.Text = time[4].ToString();
            }
            if (lbmm1.Text != time[3].ToString())
            {
                lbmm1.Text = time[3].ToString();
            }
            if (lbHH2.Text != time[1].ToString())
            {
                lbHH2.Text = time[1].ToString();
            }
            if (lbHH1.Text != time[0].ToString())
            {
                lbHH1.Text = time[0].ToString();
            }
        }

        private void CloseFullScreen(object sender, MouseEventArgs e)
        {
            CloseFullScreen();
        }

        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var browser = webBrowser.ActiveXInstance as SHDocVw.InternetExplorer;
            browser.ExecWB(SHDocVw.OLECMDID.OLECMDID_OPTICAL_ZOOM, SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT, 80, IntPtr.Zero);
            webBrowser.Document.Window.ScrollTo(0, 150);
        }

        private void btn타이머_Click(object sender, EventArgs e)
        {
            useTimer = !useTimer;
            
            SetUseTimer(useTimer);
        }


        private void btn시계_Click(object sender, EventArgs e)
        {
            SetShowClock(!pnl시계.Visible);
        }

        private void btn날씨_Click(object sender, EventArgs e)
        {
            SetShowWhether(!pnl날씨.Visible);
        }

        private void btn설정_Click(object sender, EventArgs e)
        {
            DialogResult dr = new Settings().ShowDialog();
            if(dr == DialogResult.OK)
            {

            }
        }

        public void SetShowWhether(bool show)
        {
            if (show)
            {
                this.pnl날씨.Controls.Clear();

                webBrowser = new System.Windows.Forms.WebBrowser();
                this.pnl날씨.Controls.Add(webBrowser);
                webBrowser.Dock = DockStyle.Fill;
                webBrowser.Margin = new System.Windows.Forms.Padding(0);
                webBrowser.Padding = new System.Windows.Forms.Padding(0);
                webBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;
                webBrowser.Scale(new SizeF(0.5f, 0.5f));
                webBrowser.Url = new Uri("https://search.naver.com/search.naver?sm=tab_hty.top&where=nexearch&query=%EC%84%9C%EC%9A%B8+%EB%82%A0%EC%94%A8&oquery=%EC%84%9C%EC%9A%B8+%EC%98%A4%EB%8A%98%EB%82%A0%EC%94%A8&tqi=h0lORsp0J1Zssl%2BjF6NssssssIh-167064");

                pnl날씨.Show();

                btn날씨.Text = "날씨 끄기";
                btn날씨.ForeColor = Color.SlateGray;
                btn날씨.BackColor = Color.FromArgb(0x0A2020);
            }
            else
            {
                pnl날씨.Hide();
                btn날씨.Text = "날씨 보이기";

                btn날씨.ForeColor = Color.Black;
                btn날씨.BackColor = Color.DimGray;
            }
        }

        public void SetShowClock(bool show)
        {
            if (show)
            {
                pnl시계.Show();

                btn시계.Text = "시계 끄기";
                btn시계.ForeColor = Color.SlateGray;

                btn시계.BackColor = Color.FromArgb(0x0A2020);
            }
            else
            {
                pnl시계.Hide();

                btn시계.Text = "시계 보이기";
                btn시계.ForeColor = Color.Black;
                btn시계.BackColor = Color.DimGray;
            }
        }

        private void SetUseTimer(bool use)
        {
            if(use)
            {
                if (btn타이머.Text != "타이머 끄기")
                {
                    btn타이머.Text = "타이머 끄기";
                }
                btn타이머.ForeColor = Color.SlateGray;
                btn타이머.BackColor = Color.FromArgb(0x0A2020);
            }
            else
            {
                if (btn타이머.Text != "타이머 켜기")
                {
                    btn타이머.Text = "타이머 켜기";
                }

                btn타이머.ForeColor = Color.Black;
                btn타이머.BackColor = Color.DimGray;
            }
        }

    }

    
}
