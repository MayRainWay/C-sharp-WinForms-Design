namespace chapt6_2_CProcess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnCalculatorStart = new System.Windows.Forms.Button();
            this.btnCalculatorStopAll = new System.Windows.Forms.Button();
            this.btnSelfExamStart = new System.Windows.Forms.Button();
            this.btnSelfExamStopAll = new System.Windows.Forms.Button();
            this.CalculatorProcess = new System.Diagnostics.Process();
            this.SuspendLayout();
            // 
            // btnCalculatorStart
            // 
            this.btnCalculatorStart.Location = new System.Drawing.Point(44, 61);
            this.btnCalculatorStart.Name = "btnCalculatorStart";
            this.btnCalculatorStart.Size = new System.Drawing.Size(221, 59);
            this.btnCalculatorStart.TabIndex = 0;
            this.btnCalculatorStart.Text = "启动一个计算器";
            this.btnCalculatorStart.UseVisualStyleBackColor = true;
            this.btnCalculatorStart.Click += new System.EventHandler(this.btnCalculatorStart_Click);
            // 
            // btnCalculatorStopAll
            // 
            this.btnCalculatorStopAll.Location = new System.Drawing.Point(336, 61);
            this.btnCalculatorStopAll.Name = "btnCalculatorStopAll";
            this.btnCalculatorStopAll.Size = new System.Drawing.Size(243, 59);
            this.btnCalculatorStopAll.TabIndex = 0;
            this.btnCalculatorStopAll.Text = "关闭全部计算器";
            this.btnCalculatorStopAll.UseVisualStyleBackColor = true;
            this.btnCalculatorStopAll.Click += new System.EventHandler(this.btnCalculatorStopAll_Click);
            // 
            // btnSelfExamStart
            // 
            this.btnSelfExamStart.Location = new System.Drawing.Point(44, 185);
            this.btnSelfExamStart.Name = "btnSelfExamStart";
            this.btnSelfExamStart.Size = new System.Drawing.Size(221, 61);
            this.btnSelfExamStart.TabIndex = 0;
            this.btnSelfExamStart.Text = "启动一个上机自测系统";
            this.btnSelfExamStart.UseVisualStyleBackColor = true;
            this.btnSelfExamStart.Click += new System.EventHandler(this.btnSelfExamStart_Click);
            // 
            // btnSelfExamStopAll
            // 
            this.btnSelfExamStopAll.Location = new System.Drawing.Point(336, 185);
            this.btnSelfExamStopAll.Name = "btnSelfExamStopAll";
            this.btnSelfExamStopAll.Size = new System.Drawing.Size(243, 61);
            this.btnSelfExamStopAll.TabIndex = 0;
            this.btnSelfExamStopAll.Text = "关闭全部上机自测系统";
            this.btnSelfExamStopAll.UseVisualStyleBackColor = true;
            this.btnSelfExamStopAll.Click += new System.EventHandler(this.btnSelfExamStopAll_Click);
            // 
            // CalculatorProcess
            // 
            this.CalculatorProcess.StartInfo.Domain = "";
            this.CalculatorProcess.StartInfo.FileName = "\"C:\\Program Files (x86)\\foobar2000\\foobar2000.exe\"";
            this.CalculatorProcess.StartInfo.LoadUserProfile = false;
            this.CalculatorProcess.StartInfo.Password = null;
            this.CalculatorProcess.StartInfo.StandardErrorEncoding = null;
            this.CalculatorProcess.StartInfo.StandardOutputEncoding = null;
            this.CalculatorProcess.StartInfo.UserName = "";
            this.CalculatorProcess.SynchronizingObject = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 326);
            this.Controls.Add(this.btnSelfExamStopAll);
            this.Controls.Add(this.btnSelfExamStart);
            this.Controls.Add(this.btnCalculatorStopAll);
            this.Controls.Add(this.btnCalculatorStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "6.2进程开发技术";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCalculatorStart;
        private System.Windows.Forms.Button btnCalculatorStopAll;
        private System.Windows.Forms.Button btnSelfExamStart;
        private System.Windows.Forms.Button btnSelfExamStopAll;
        private System.Diagnostics.Process CalculatorProcess;
    }
}

