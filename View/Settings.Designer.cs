namespace wakeUp.View
{
    partial class Settings
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn저장 = new System.Windows.Forms.Button();
            this.pnl설정컨테이너 = new System.Windows.Forms.Panel();
            this.pnl샘플 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx제목키워드 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx채널명 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbx시간 = new System.Windows.Forms.TextBox();
            this.btn추가 = new System.Windows.Forms.Button();
            this.btn삭제 = new System.Windows.Forms.Button();
            this.chk = new System.Windows.Forms.CheckBox();
            this.cbo실행타입 = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            this.pnl설정컨테이너.SuspendLayout();
            this.pnl샘플.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2060, 47);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn삭제);
            this.panel2.Controls.Add(this.btn추가);
            this.panel2.Controls.Add(this.btn저장);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 891);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2060, 90);
            this.panel2.TabIndex = 1;
            // 
            // btn저장
            // 
            this.btn저장.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn저장.BackColor = System.Drawing.Color.Gainsboro;
            this.btn저장.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn저장.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn저장.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn저장.ForeColor = System.Drawing.Color.Black;
            this.btn저장.Location = new System.Drawing.Point(1882, 10);
            this.btn저장.Name = "btn저장";
            this.btn저장.Size = new System.Drawing.Size(166, 69);
            this.btn저장.TabIndex = 4;
            this.btn저장.Text = "저장";
            this.btn저장.UseVisualStyleBackColor = false;
            this.btn저장.Click += new System.EventHandler(this.btn저장_Click);
            // 
            // pnl설정컨테이너
            // 
            this.pnl설정컨테이너.AutoScroll = true;
            this.pnl설정컨테이너.BackColor = System.Drawing.Color.White;
            this.pnl설정컨테이너.Controls.Add(this.pnl샘플);
            this.pnl설정컨테이너.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl설정컨테이너.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pnl설정컨테이너.Location = new System.Drawing.Point(0, 47);
            this.pnl설정컨테이너.Name = "pnl설정컨테이너";
            this.pnl설정컨테이너.Size = new System.Drawing.Size(2060, 844);
            this.pnl설정컨테이너.TabIndex = 2;
            // 
            // pnl샘플
            // 
            this.pnl샘플.AutoSize = true;
            this.pnl샘플.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl샘플.Controls.Add(this.cbo실행타입);
            this.pnl샘플.Controls.Add(this.chk);
            this.pnl샘플.Controls.Add(this.label4);
            this.pnl샘플.Controls.Add(this.label3);
            this.pnl샘플.Controls.Add(this.tbx제목키워드);
            this.pnl샘플.Controls.Add(this.label2);
            this.pnl샘플.Controls.Add(this.tbx채널명);
            this.pnl샘플.Controls.Add(this.label1);
            this.pnl샘플.Controls.Add(this.tbx시간);
            this.pnl샘플.Location = new System.Drawing.Point(20, 0);
            this.pnl샘플.Name = "pnl샘플";
            this.pnl샘플.Size = new System.Drawing.Size(2040, 75);
            this.pnl샘플.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("돋움", 9F);
            this.label4.Location = new System.Drawing.Point(967, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "실행 타입 :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("돋움", 9F);
            this.label3.Location = new System.Drawing.Point(1286, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "제목키워드 :";
            // 
            // tbx제목키워드
            // 
            this.tbx제목키워드.Font = new System.Drawing.Font("돋움", 9F);
            this.tbx제목키워드.Location = new System.Drawing.Point(1438, 22);
            this.tbx제목키워드.MaxLength = 50;
            this.tbx제목키워드.Name = "tbx제목키워드";
            this.tbx제목키워드.Size = new System.Drawing.Size(311, 35);
            this.tbx제목키워드.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("돋움", 9F);
            this.label2.Location = new System.Drawing.Point(474, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "채널명 : ";
            // 
            // tbx채널명
            // 
            this.tbx채널명.Font = new System.Drawing.Font("돋움", 9F);
            this.tbx채널명.Location = new System.Drawing.Point(586, 18);
            this.tbx채널명.MaxLength = 20;
            this.tbx채널명.Name = "tbx채널명";
            this.tbx채널명.Size = new System.Drawing.Size(335, 35);
            this.tbx채널명.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("돋움", 9F);
            this.label1.Location = new System.Drawing.Point(118, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "시간(hhmm) : ";
            // 
            // tbx시간
            // 
            this.tbx시간.Font = new System.Drawing.Font("돋움", 9F);
            this.tbx시간.Location = new System.Drawing.Point(276, 18);
            this.tbx시간.MaxLength = 4;
            this.tbx시간.Name = "tbx시간";
            this.tbx시간.Size = new System.Drawing.Size(169, 35);
            this.tbx시간.TabIndex = 0;
            // 
            // btn추가
            // 
            this.btn추가.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn추가.BackColor = System.Drawing.Color.Gainsboro;
            this.btn추가.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn추가.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn추가.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn추가.ForeColor = System.Drawing.Color.Black;
            this.btn추가.Location = new System.Drawing.Point(12, 9);
            this.btn추가.Name = "btn추가";
            this.btn추가.Size = new System.Drawing.Size(166, 69);
            this.btn추가.TabIndex = 5;
            this.btn추가.Text = "추가";
            this.btn추가.UseVisualStyleBackColor = false;
            this.btn추가.Click += new System.EventHandler(this.btn추가_Click);
            // 
            // btn삭제
            // 
            this.btn삭제.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn삭제.BackColor = System.Drawing.Color.Gainsboro;
            this.btn삭제.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn삭제.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn삭제.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn삭제.ForeColor = System.Drawing.Color.Black;
            this.btn삭제.Location = new System.Drawing.Point(184, 10);
            this.btn삭제.Name = "btn삭제";
            this.btn삭제.Size = new System.Drawing.Size(166, 69);
            this.btn삭제.TabIndex = 6;
            this.btn삭제.Text = "삭제";
            this.btn삭제.UseVisualStyleBackColor = false;
            this.btn삭제.Click += new System.EventHandler(this.btn삭제_Click);
            // 
            // chk
            // 
            this.chk.Font = new System.Drawing.Font("굴림", 15F);
            this.chk.Location = new System.Drawing.Point(44, 22);
            this.chk.Name = "chk";
            this.chk.Size = new System.Drawing.Size(28, 27);
            this.chk.TabIndex = 8;
            this.chk.UseVisualStyleBackColor = true;
            // 
            // cbo실행타입
            // 
            this.cbo실행타입.DisplayMember = "display";
            this.cbo실행타입.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo실행타입.FormattingEnabled = true;
            this.cbo실행타입.Location = new System.Drawing.Point(1103, 20);
            this.cbo실행타입.Name = "cbo실행타입";
            this.cbo실행타입.Size = new System.Drawing.Size(147, 32);
            this.cbo실행타입.TabIndex = 10;
            this.cbo실행타입.ValueMember = "value";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2060, 981);
            this.Controls.Add(this.pnl설정컨테이너);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Settings";
            this.Text = "설정";
            this.panel2.ResumeLayout(false);
            this.pnl설정컨테이너.ResumeLayout(false);
            this.pnl설정컨테이너.PerformLayout();
            this.pnl샘플.ResumeLayout(false);
            this.pnl샘플.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnl설정컨테이너;
        private System.Windows.Forms.Button btn저장;
        private System.Windows.Forms.Panel pnl샘플;
        private System.Windows.Forms.TextBox tbx시간;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx제목키워드;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx채널명;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn추가;
        private System.Windows.Forms.Button btn삭제;
        private System.Windows.Forms.CheckBox chk;
        private System.Windows.Forms.ComboBox cbo실행타입;
    }
}