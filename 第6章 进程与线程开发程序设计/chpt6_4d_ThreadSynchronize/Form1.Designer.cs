namespace chpt6_4d_ThreadSynchronize
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lbConvey = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.lstProduction = new System.Windows.Forms.ListBox();
            this.lstConvey = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(296, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "待装数量";
            // 
            // lbConvey
            // 
            this.lbConvey.AutoSize = true;
            this.lbConvey.Location = new System.Drawing.Point(329, 59);
            this.lbConvey.Name = "lbConvey";
            this.lbConvey.Size = new System.Drawing.Size(17, 18);
            this.lbConvey.TabIndex = 0;
            this.lbConvey.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(99, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "生产数量";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(495, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "已装数量";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(102, 293);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(136, 48);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "启动线程";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.Location = new System.Drawing.Point(439, 293);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(136, 44);
            this.btnAbort.TabIndex = 1;
            this.btnAbort.Text = "终止线程";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // lstProduction
            // 
            this.lstProduction.FormattingEnabled = true;
            this.lstProduction.ItemHeight = 18;
            this.lstProduction.Items.AddRange(new object[] {
            "0"});
            this.lstProduction.Location = new System.Drawing.Point(102, 56);
            this.lstProduction.Name = "lstProduction";
            this.lstProduction.Size = new System.Drawing.Size(120, 184);
            this.lstProduction.TabIndex = 4;
            // 
            // lstConvey
            // 
            this.lstConvey.FormattingEnabled = true;
            this.lstConvey.ItemHeight = 18;
            this.lstConvey.Items.AddRange(new object[] {
            "0"});
            this.lstConvey.Location = new System.Drawing.Point(455, 56);
            this.lstConvey.Name = "lstConvey";
            this.lstConvey.Size = new System.Drawing.Size(120, 184);
            this.lstConvey.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 389);
            this.Controls.Add(this.lstConvey);
            this.Controls.Add(this.lstProduction);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbConvey);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "多线程同步";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbConvey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.ListBox lstProduction;
        private System.Windows.Forms.ListBox lstConvey;
    }
}

