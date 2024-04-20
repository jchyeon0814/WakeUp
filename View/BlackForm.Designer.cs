namespace wakeUp
{
    partial class BlackForm
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
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnl시계 = new System.Windows.Forms.Panel();
            this.lbss2 = new System.Windows.Forms.Label();
            this.lbss1 = new System.Windows.Forms.Label();
            this.lbmm2 = new System.Windows.Forms.Label();
            this.lbHH2 = new System.Windows.Forms.Label();
            this.lbHH1 = new System.Windows.Forms.Label();
            this.lbmm1 = new System.Windows.Forms.Label();
            this.lbSeparator2 = new System.Windows.Forms.Label();
            this.lbSeparator1 = new System.Windows.Forms.Label();
            this.pnl날씨 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn시계 = new System.Windows.Forms.Button();
            this.btn타이머 = new System.Windows.Forms.Button();
            this.btn날씨 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.pnl시계.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 50;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pnl시계);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1143, 358);
            this.panel2.TabIndex = 10;
            this.panel2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CloseFullScreen);
            // 
            // pnl시계
            // 
            this.pnl시계.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnl시계.Controls.Add(this.lbss2);
            this.pnl시계.Controls.Add(this.lbss1);
            this.pnl시계.Controls.Add(this.lbmm2);
            this.pnl시계.Controls.Add(this.lbHH2);
            this.pnl시계.Controls.Add(this.lbHH1);
            this.pnl시계.Controls.Add(this.lbmm1);
            this.pnl시계.Controls.Add(this.lbSeparator2);
            this.pnl시계.Controls.Add(this.lbSeparator1);
            this.pnl시계.Location = new System.Drawing.Point(51, 8);
            this.pnl시계.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pnl시계.Name = "pnl시계";
            this.pnl시계.Size = new System.Drawing.Size(1042, 350);
            this.pnl시계.TabIndex = 10;
            this.pnl시계.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CloseFullScreen);
            // 
            // lbss2
            // 
            this.lbss2.Font = new System.Drawing.Font("돋움", 120F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbss2.ForeColor = System.Drawing.Color.SlateGray;
            this.lbss2.Location = new System.Drawing.Point(863, 56);
            this.lbss2.Margin = new System.Windows.Forms.Padding(0);
            this.lbss2.Name = "lbss2";
            this.lbss2.Size = new System.Drawing.Size(133, 240);
            this.lbss2.TabIndex = 6;
            this.lbss2.Text = "0";
            this.lbss2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbss2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CloseFullScreen);
            // 
            // lbss1
            // 
            this.lbss1.Font = new System.Drawing.Font("굴림", 120F, System.Drawing.FontStyle.Bold);
            this.lbss1.ForeColor = System.Drawing.Color.SlateGray;
            this.lbss1.Location = new System.Drawing.Point(742, 56);
            this.lbss1.Margin = new System.Windows.Forms.Padding(0);
            this.lbss1.Name = "lbss1";
            this.lbss1.Size = new System.Drawing.Size(133, 240);
            this.lbss1.TabIndex = 5;
            this.lbss1.Text = "0";
            this.lbss1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbss1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CloseFullScreen);
            // 
            // lbmm2
            // 
            this.lbmm2.Font = new System.Drawing.Font("굴림", 120F, System.Drawing.FontStyle.Bold);
            this.lbmm2.ForeColor = System.Drawing.Color.SlateGray;
            this.lbmm2.Location = new System.Drawing.Point(537, 56);
            this.lbmm2.Margin = new System.Windows.Forms.Padding(0);
            this.lbmm2.Name = "lbmm2";
            this.lbmm2.Size = new System.Drawing.Size(133, 240);
            this.lbmm2.TabIndex = 4;
            this.lbmm2.Text = "0";
            this.lbmm2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbmm2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CloseFullScreen);
            // 
            // lbHH2
            // 
            this.lbHH2.Font = new System.Drawing.Font("굴림", 120F, System.Drawing.FontStyle.Bold);
            this.lbHH2.ForeColor = System.Drawing.Color.SlateGray;
            this.lbHH2.Location = new System.Drawing.Point(195, 56);
            this.lbHH2.Margin = new System.Windows.Forms.Padding(0);
            this.lbHH2.Name = "lbHH2";
            this.lbHH2.Size = new System.Drawing.Size(133, 240);
            this.lbHH2.TabIndex = 2;
            this.lbHH2.Text = "0";
            this.lbHH2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbHH2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CloseFullScreen);
            // 
            // lbHH1
            // 
            this.lbHH1.Font = new System.Drawing.Font("굴림", 120F, System.Drawing.FontStyle.Bold);
            this.lbHH1.ForeColor = System.Drawing.Color.SlateGray;
            this.lbHH1.Location = new System.Drawing.Point(73, 56);
            this.lbHH1.Margin = new System.Windows.Forms.Padding(0);
            this.lbHH1.Name = "lbHH1";
            this.lbHH1.Size = new System.Drawing.Size(133, 240);
            this.lbHH1.TabIndex = 1;
            this.lbHH1.Text = "0";
            this.lbHH1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbHH1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CloseFullScreen);
            // 
            // lbmm1
            // 
            this.lbmm1.Font = new System.Drawing.Font("굴림", 120F, System.Drawing.FontStyle.Bold);
            this.lbmm1.ForeColor = System.Drawing.Color.SlateGray;
            this.lbmm1.Location = new System.Drawing.Point(415, 56);
            this.lbmm1.Margin = new System.Windows.Forms.Padding(0);
            this.lbmm1.Name = "lbmm1";
            this.lbmm1.Size = new System.Drawing.Size(133, 240);
            this.lbmm1.TabIndex = 3;
            this.lbmm1.Text = "0";
            this.lbmm1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbmm1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CloseFullScreen);
            // 
            // lbSeparator2
            // 
            this.lbSeparator2.Font = new System.Drawing.Font("굴림", 120F, System.Drawing.FontStyle.Bold);
            this.lbSeparator2.ForeColor = System.Drawing.Color.SlateGray;
            this.lbSeparator2.Location = new System.Drawing.Point(657, 56);
            this.lbSeparator2.Margin = new System.Windows.Forms.Padding(0);
            this.lbSeparator2.Name = "lbSeparator2";
            this.lbSeparator2.Size = new System.Drawing.Size(100, 240);
            this.lbSeparator2.TabIndex = 8;
            this.lbSeparator2.Text = ":";
            this.lbSeparator2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbSeparator2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CloseFullScreen);
            // 
            // lbSeparator1
            // 
            this.lbSeparator1.Font = new System.Drawing.Font("굴림", 120F, System.Drawing.FontStyle.Bold);
            this.lbSeparator1.ForeColor = System.Drawing.Color.SlateGray;
            this.lbSeparator1.Location = new System.Drawing.Point(327, 56);
            this.lbSeparator1.Margin = new System.Windows.Forms.Padding(0);
            this.lbSeparator1.Name = "lbSeparator1";
            this.lbSeparator1.Size = new System.Drawing.Size(100, 240);
            this.lbSeparator1.TabIndex = 7;
            this.lbSeparator1.Text = ":";
            this.lbSeparator1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbSeparator1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CloseFullScreen);
            // 
            // pnl날씨
            // 
            this.pnl날씨.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl날씨.Location = new System.Drawing.Point(873, 364);
            this.pnl날씨.Margin = new System.Windows.Forms.Padding(2);
            this.pnl날씨.Name = "pnl날씨";
            this.pnl날씨.Size = new System.Drawing.Size(219, 214);
            this.pnl날씨.TabIndex = 11;
            this.pnl날씨.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CloseFullScreen);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn시계);
            this.panel3.Controls.Add(this.btn타이머);
            this.panel3.Controls.Add(this.btn날씨);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 602);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1143, 73);
            this.panel3.TabIndex = 13;
            // 
            // btn시계
            // 
            this.btn시계.BackColor = System.Drawing.Color.DimGray;
            this.btn시계.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn시계.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn시계.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn시계.ForeColor = System.Drawing.Color.Black;
            this.btn시계.Location = new System.Drawing.Point(142, 12);
            this.btn시계.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn시계.Name = "btn시계";
            this.btn시계.Size = new System.Drawing.Size(128, 52);
            this.btn시계.TabIndex = 2;
            this.btn시계.Text = "시계 끄기";
            this.btn시계.UseVisualStyleBackColor = false;
            this.btn시계.Click += new System.EventHandler(this.btn시계_Click);
            // 
            // btn타이머
            // 
            this.btn타이머.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btn타이머.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn타이머.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn타이머.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn타이머.ForeColor = System.Drawing.Color.SlateGray;
            this.btn타이머.Location = new System.Drawing.Point(9, 12);
            this.btn타이머.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn타이머.Name = "btn타이머";
            this.btn타이머.Size = new System.Drawing.Size(128, 52);
            this.btn타이머.TabIndex = 1;
            this.btn타이머.Text = "타이머 끄기";
            this.btn타이머.UseVisualStyleBackColor = false;
            this.btn타이머.Click += new System.EventHandler(this.btn타이머_Click);
            // 
            // btn날씨
            // 
            this.btn날씨.BackColor = System.Drawing.Color.DimGray;
            this.btn날씨.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn날씨.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn날씨.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn날씨.ForeColor = System.Drawing.Color.Black;
            this.btn날씨.Location = new System.Drawing.Point(275, 12);
            this.btn날씨.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn날씨.Name = "btn날씨";
            this.btn날씨.Size = new System.Drawing.Size(128, 52);
            this.btn날씨.TabIndex = 0;
            this.btn날씨.Text = "날씨 보이기";
            this.btn날씨.UseVisualStyleBackColor = false;
            this.btn날씨.Click += new System.EventHandler(this.btn날씨_Click);
            // 
            // BlackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1143, 675);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnl날씨);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "BlackForm";
            this.Text = "BlackForm";
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CloseFullScreen);
            this.panel2.ResumeLayout(false);
            this.pnl시계.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnl시계;
        private System.Windows.Forms.Label lbss2;
        private System.Windows.Forms.Label lbss1;
        private System.Windows.Forms.Label lbmm2;
        private System.Windows.Forms.Label lbHH2;
        private System.Windows.Forms.Label lbHH1;
        private System.Windows.Forms.Label lbmm1;
        private System.Windows.Forms.Label lbSeparator2;
        private System.Windows.Forms.Label lbSeparator1;
        private System.Windows.Forms.Panel pnl날씨;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn날씨;
        private System.Windows.Forms.Button btn타이머;
        private System.Windows.Forms.Button btn시계;
    }
}