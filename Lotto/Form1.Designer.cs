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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReNew = new System.Windows.Forms.Button();
            this.btnAnalyst = new System.Windows.Forms.Button();
            this.txtHtml = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(381, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(568, 93);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(721, 89);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnReNew
            // 
            this.btnReNew.Location = new System.Drawing.Point(26, 565);
            this.btnReNew.Name = "btnReNew";
            this.btnReNew.Size = new System.Drawing.Size(75, 23);
            this.btnReNew.TabIndex = 3;
            this.btnReNew.Text = "갱신";
            this.btnReNew.UseVisualStyleBackColor = true;
            // 
            // btnAnalyst
            // 
            this.btnAnalyst.Location = new System.Drawing.Point(108, 565);
            this.btnAnalyst.Name = "btnAnalyst";
            this.btnAnalyst.Size = new System.Drawing.Size(75, 23);
            this.btnAnalyst.TabIndex = 4;
            this.btnAnalyst.Text = "분석";
            this.btnAnalyst.UseVisualStyleBackColor = true;
            this.btnAnalyst.Click += new System.EventHandler(this.btnAnalyst_Click);
            // 
            // txtHtml
            // 
            this.txtHtml.Location = new System.Drawing.Point(82, 221);
            this.txtHtml.Multiline = true;
            this.txtHtml.Name = "txtHtml";
            this.txtHtml.Size = new System.Drawing.Size(714, 248);
            this.txtHtml.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 618);
            this.Controls.Add(this.txtHtml);
            this.Controls.Add(this.btnAnalyst);
            this.Controls.Add(this.btnReNew);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReNew;
        private System.Windows.Forms.Button btnAnalyst;
        private System.Windows.Forms.TextBox txtHtml;
    }
}

