namespace Lotto
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCurrentLottoNum = new System.Windows.Forms.Label();
            this.cbxTurnNum = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReNew = new System.Windows.Forms.Button();
            this.btnAnalyst = new System.Windows.Forms.Button();
            this.LottoGridView = new System.Windows.Forms.DataGridView();
            this.UpdateProgressBar = new System.Windows.Forms.ProgressBar();
            this.btnSelectAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LottoGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCurrentLottoNum
            // 
            this.lblCurrentLottoNum.AutoSize = true;
            this.lblCurrentLottoNum.Font = new System.Drawing.Font("굴림", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCurrentLottoNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblCurrentLottoNum.Location = new System.Drawing.Point(18, 42);
            this.lblCurrentLottoNum.Name = "lblCurrentLottoNum";
            this.lblCurrentLottoNum.Size = new System.Drawing.Size(0, 29);
            this.lblCurrentLottoNum.TabIndex = 0;
            // 
            // cbxTurnNum
            // 
            this.cbxTurnNum.FormattingEnabled = true;
            this.cbxTurnNum.Location = new System.Drawing.Point(689, 45);
            this.cbxTurnNum.Name = "cbxTurnNum";
            this.cbxTurnNum.Size = new System.Drawing.Size(121, 20);
            this.cbxTurnNum.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(816, 44);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReNew
            // 
            this.btnReNew.Location = new System.Drawing.Point(19, 530);
            this.btnReNew.Name = "btnReNew";
            this.btnReNew.Size = new System.Drawing.Size(75, 23);
            this.btnReNew.TabIndex = 3;
            this.btnReNew.Text = "갱신";
            this.btnReNew.UseVisualStyleBackColor = true;
            this.btnReNew.Click += new System.EventHandler(this.btnReNew_Click);
            // 
            // btnAnalyst
            // 
            this.btnAnalyst.Location = new System.Drawing.Point(816, 531);
            this.btnAnalyst.Name = "btnAnalyst";
            this.btnAnalyst.Size = new System.Drawing.Size(75, 23);
            this.btnAnalyst.TabIndex = 4;
            this.btnAnalyst.Text = "분석";
            this.btnAnalyst.UseVisualStyleBackColor = true;
            this.btnAnalyst.Click += new System.EventHandler(this.btnAnalyst_Click);
            // 
            // LottoGridView
            // 
            this.LottoGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LottoGridView.Location = new System.Drawing.Point(13, 107);
            this.LottoGridView.Name = "LottoGridView";
            this.LottoGridView.RowTemplate.Height = 23;
            this.LottoGridView.Size = new System.Drawing.Size(879, 405);
            this.LottoGridView.TabIndex = 5;
            // 
            // UpdateProgressBar
            // 
            this.UpdateProgressBar.Location = new System.Drawing.Point(101, 531);
            this.UpdateProgressBar.Name = "UpdateProgressBar";
            this.UpdateProgressBar.Size = new System.Drawing.Size(703, 23);
            this.UpdateProgressBar.TabIndex = 6;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(817, 73);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 7;
            this.btnSelectAll.Text = "전체조회";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 572);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.UpdateProgressBar);
            this.Controls.Add(this.LottoGridView);
            this.Controls.Add(this.btnAnalyst);
            this.Controls.Add(this.btnReNew);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cbxTurnNum);
            this.Controls.Add(this.lblCurrentLottoNum);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LottoGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCurrentLottoNum;
        private System.Windows.Forms.ComboBox cbxTurnNum;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReNew;
        private System.Windows.Forms.Button btnAnalyst;
        private System.Windows.Forms.DataGridView LottoGridView;
        private System.Windows.Forms.ProgressBar UpdateProgressBar;
        private System.Windows.Forms.Button btnSelectAll;
    }
}

