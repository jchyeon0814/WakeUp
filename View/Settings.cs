using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wakeUp.Model;

namespace wakeUp.View
{
    public partial class Settings : Form
    {
        private YoutubeTimeTableModel youtubeTimeTableModel;

        private List<YoutubeTimeTable> youtubeTimeTables = null;
        public Settings()
        {
            InitializeComponent();

            try
            {
                youtubeTimeTableModel = YoutubeTimeTableModel.GetSingletonInstance();

                youtubeTimeTables = youtubeTimeTableModel.Select();

                SetPnl설정컨테이너Data(youtubeTimeTables);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn저장_Click(object sender, EventArgs e)
        {
            try
            {
                List<YoutubeTimeTable> youtubeTimeTableList = GetPnl설정컨테이너Data();

                youtubeTimeTableModel.DeleteNInsert(youtubeTimeTableList);

                youtubeTimeTables = youtubeTimeTableModel.Select();

                SetPnl설정컨테이너Data(youtubeTimeTables);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn추가_Click(object sender, EventArgs e)
        {
            try
            {
                Panel pnlNew = CreateItem(new YoutubeTimeTable("0000"));
                pnl설정컨테이너.Controls.Add(pnlNew);
                pnl설정컨테이너.Controls.SetChildIndex(pnlNew, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn삭제_Click(object sender, EventArgs e)
        {
            try
            {
                List<YoutubeTimeTable> youtubeTimeTableList = new List<YoutubeTimeTable>();

                int count = pnl설정컨테이너.Controls.Count;

                List<Panel> panels = new List<Panel>();
                for (int i = 0; i < count; i++)
                {
                    Panel pnlItem = pnl설정컨테이너.Controls[i] as Panel;
                    if (pnlItem == null)
                    {
                        continue;
                    }

                    YoutubeTimeTable youtubeTimeTable = pnlItem.Tag as YoutubeTimeTable;
                    if (youtubeTimeTable == null)
                    {
                        continue;
                    }

                    CheckBox chk = pnlItem.Controls.Find(this.chk.Name, false)[0] as CheckBox;
                
                    if(chk.Checked)
                    {
                        panels.Add(pnlItem);
                    }
                }

                foreach(Panel panel in panels)
                {
                    pnl설정컨테이너.Controls.Remove(panel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void SetPnl설정컨테이너Data(List<YoutubeTimeTable> youtubeTimeTableList)
        {
            pnl설정컨테이너.Controls.Clear();

            for (int i = youtubeTimeTableList.Count - 1; i >= 0; i--)
            {
                YoutubeTimeTable youtubeTimeTable = youtubeTimeTableList[i];

                pnl설정컨테이너.Controls.Add(CreateItem(youtubeTimeTable));
            }
        }

        public Panel CreateItem(YoutubeTimeTable youtubeTimeTable)
        {
            Panel pnl샘플 = new Panel();
            pnl샘플.Tag = youtubeTimeTable;

            DataTable dt = new DataTable();
            dt.Columns.Add(this.cbo실행타입.DisplayMember);
            dt.Columns.Add(this.cbo실행타입.ValueMember, typeof(int));
            dt.Rows.Add("중지", (int) YoutubeTimeTable.ExecuteMode.NONE);
            dt.Rows.Add("실시간", (int) YoutubeTimeTable.ExecuteMode.REALTIME);
            dt.Rows.Add("가장최근", (int) YoutubeTimeTable.ExecuteMode.RECENTLY);

            CheckBox chk = new CheckBox();
            TextBox tbx시간 = new TextBox();
            Label label4 = new Label();
            Label label3 = new Label();
            TextBox tbx제목키워드 = new TextBox();
            Label label2 = new Label();
            TextBox tbx채널명 = new TextBox();
            Label label1 = new Label();
            ComboBox cbo실행타입 = new ComboBox();

            pnl샘플.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnl샘플.Controls.Add(chk);
            pnl샘플.Controls.Add(label4);
            pnl샘플.Controls.Add(label3);
            pnl샘플.Controls.Add(tbx제목키워드);
            pnl샘플.Controls.Add(label2);
            pnl샘플.Controls.Add(tbx채널명);
            pnl샘플.Controls.Add(label1);
            pnl샘플.Controls.Add(tbx시간);
            pnl샘플.Controls.Add(cbo실행타입);
            pnl샘플.Dock = System.Windows.Forms.DockStyle.Top;
            pnl샘플.Location = new System.Drawing.Point(0, 0);
            pnl샘플.Size = this.pnl샘플.Size;
            pnl샘플.TabIndex = 0;
            // 
            // chk
            // 
            chk.Font = this.chk.Font;
            chk.Location = this.chk.Location;
            chk.Name = this.chk.Name;
            chk.Size = this.chk.Size;
            chk.UseVisualStyleBackColor = this.chk.UseVisualStyleBackColor;
            // 
            // list실행타입
            // 
            // 
            // cbo실행타입
            // 
            cbo실행타입.FormattingEnabled = this.cbo실행타입.FormattingEnabled;
            cbo실행타입.Location = this.cbo실행타입.Location;
            cbo실행타입.Name = this.cbo실행타입.Name;
            cbo실행타입.Size = this.cbo실행타입.Size;
            cbo실행타입.TabIndex = this.cbo실행타입.TabIndex;
            cbo실행타입.DropDownStyle = this.cbo실행타입.DropDownStyle;
            cbo실행타입.DataSource = dt;
            cbo실행타입.DisplayMember =this.cbo실행타입.DisplayMember;
            cbo실행타입.ValueMember = this.cbo실행타입.ValueMember;
            cbo실행타입.BindingContext = new BindingContext();
            cbo실행타입.SelectedValue = youtubeTimeTable.GetExecuteModeValue();
            // 
            // tbx시간
            // 
            tbx시간.Font = this.tbx시간.Font;
            tbx시간.Location = this.tbx시간.Location;
            tbx시간.Size = this.tbx시간.Size;
            tbx시간.Text = youtubeTimeTable.GetStartTime();
            tbx시간.MaxLength = this.tbx시간.MaxLength;
            tbx시간.Name = this.tbx시간.Name;
            // 
            // label1
            // 
            label1.AutoSize = this.label1.AutoSize;
            label1.Font = this.label1.Font;
            label1.Location = this.label1.Location;
            label1.Size = this.label1.Size;
            label1.Text = this.label1.Text;
            // 
            // label2
            // 
            label2.AutoSize = this.label2.AutoSize;
            label2.Font = this.label2.Font;
            label2.Location = this.label2.Location;
            label2.Size = this.label2.Size;
            label2.Text = this.label2.Text;
            // 
            // tbx채널명
            // 
            tbx채널명.Font = this.tbx채널명.Font;
            tbx채널명.Location = this.tbx채널명.Location;
            tbx채널명.Size = this.tbx채널명.Size;
            tbx채널명.Text = youtubeTimeTable.GetChannel();
            tbx채널명.MaxLength = this.tbx채널명.MaxLength;
            tbx채널명.Name = this.tbx채널명.Name;
            // 
            // label3
            // 
            label3.AutoSize = this.label3.AutoSize;
            label3.Font = this.label3.Font;
            label3.Location = this.label3.Location;
            label3.Size = this.label3.Size;
            label3.Text = this.label3.Text;
            // 
            // tbx제목키워드
            // 
            tbx제목키워드.Font = this.tbx제목키워드.Font;
            tbx제목키워드.Location = this.tbx제목키워드.Location;
            tbx제목키워드.Size = this.tbx제목키워드.Size;
            tbx제목키워드.Text = youtubeTimeTable.GetTitleKeyword();
            tbx제목키워드.MaxLength = this.tbx제목키워드.MaxLength;
            tbx제목키워드.Name = this.tbx제목키워드.Name;
            // 
            // label4
            // 
            label4.AutoSize = this.label4.AutoSize;
            label4.Font = this.label4.Font;
            label4.Location = this.label4.Location;
            label4.Size = this.label4.Size;
            label4.Text = this.label4.Text;

            return pnl샘플;
        }
        
        public List<YoutubeTimeTable> GetPnl설정컨테이너Data()
        {
            List<YoutubeTimeTable> youtubeTimeTableList = new List<YoutubeTimeTable>();

            for(int i = 0; i < pnl설정컨테이너.Controls.Count; i++)
            {
                Panel pnlItem = pnl설정컨테이너.Controls[i] as Panel;
                if(pnlItem == null)
                {
                    continue;
                }

                YoutubeTimeTable youtubeTimeTable = pnlItem.Tag as YoutubeTimeTable;
                if(youtubeTimeTable == null)
                {
                    continue;
                }

                TextBox tbx시간 = pnlItem.Controls.Find(this.tbx시간.Name, false)[0] as TextBox;
                TextBox tbx채널명 = pnlItem.Controls.Find(this.tbx채널명.Name, false)[0] as TextBox;
                TextBox tbx제목키워드 = pnlItem.Controls.Find(this.tbx제목키워드.Name, false)[0] as TextBox;
                ComboBox cbo실행타입 = pnlItem.Controls.Find(this.cbo실행타입.Name, false)[0] as ComboBox;
                
                int d실행 = Int32.Parse(cbo실행타입.SelectedValue.ToString());

                youtubeTimeTable.SetStartTime(tbx시간.Text);
                youtubeTimeTable.SetChannel(tbx채널명.Text);
                youtubeTimeTable.SetTitleKeyword(tbx제목키워드.Text);
                youtubeTimeTable.SetExecuteModeValue(d실행);

                youtubeTimeTableList.Add(youtubeTimeTable);
            }

            return youtubeTimeTableList;
        }

        
    }
}
