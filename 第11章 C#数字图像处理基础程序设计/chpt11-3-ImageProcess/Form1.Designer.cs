namespace chpt11_3_ImageProcess
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExpand = new System.Windows.Forms.Button();
            this.btnSharpen = new System.Windows.Forms.Button();
            this.btnCorrode = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnRefine = new System.Windows.Forms.Button();
            this.btnBinarize = new System.Windows.Forms.Button();
            this.btnChainCode = new System.Windows.Forms.Button();
            this.btnHistogram = new System.Windows.Forms.Button();
            this.btnEdgeDetect = new System.Windows.Forms.Button();
            this.btnGray = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(360, 280);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 296);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "源图像";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(744, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "源图像（待处理）";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnLoad);
            this.groupBox1.Location = new System.Drawing.Point(12, 317);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 129);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图像控制";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(34, 81);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 36);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存处理图";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(34, 37);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(127, 36);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "打开源图";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExpand);
            this.groupBox2.Controls.Add(this.btnSharpen);
            this.groupBox2.Controls.Add(this.btnCorrode);
            this.groupBox2.Controls.Add(this.btnFilter);
            this.groupBox2.Controls.Add(this.btnRefine);
            this.groupBox2.Controls.Add(this.btnBinarize);
            this.groupBox2.Controls.Add(this.btnChainCode);
            this.groupBox2.Controls.Add(this.btnHistogram);
            this.groupBox2.Controls.Add(this.btnEdgeDetect);
            this.groupBox2.Controls.Add(this.btnGray);
            this.groupBox2.Location = new System.Drawing.Point(218, 317);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(789, 129);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图像处理";
            // 
            // btnExpand
            // 
            this.btnExpand.Location = new System.Drawing.Point(647, 81);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(127, 36);
            this.btnExpand.TabIndex = 0;
            this.btnExpand.Text = "膨胀";
            this.btnExpand.UseVisualStyleBackColor = true;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // btnSharpen
            // 
            this.btnSharpen.Location = new System.Drawing.Point(647, 37);
            this.btnSharpen.Name = "btnSharpen";
            this.btnSharpen.Size = new System.Drawing.Size(127, 36);
            this.btnSharpen.TabIndex = 0;
            this.btnSharpen.Text = "锐化";
            this.btnSharpen.UseVisualStyleBackColor = true;
            this.btnSharpen.Click += new System.EventHandler(this.btnSharpen_Click);
            // 
            // btnCorrode
            // 
            this.btnCorrode.Location = new System.Drawing.Point(501, 81);
            this.btnCorrode.Name = "btnCorrode";
            this.btnCorrode.Size = new System.Drawing.Size(127, 36);
            this.btnCorrode.TabIndex = 0;
            this.btnCorrode.Text = "腐蚀";
            this.btnCorrode.UseVisualStyleBackColor = true;
            this.btnCorrode.Click += new System.EventHandler(this.btnCorrode_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(501, 37);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(127, 36);
            this.btnFilter.TabIndex = 0;
            this.btnFilter.Text = "滤波";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnRefine
            // 
            this.btnRefine.Location = new System.Drawing.Point(345, 82);
            this.btnRefine.Name = "btnRefine";
            this.btnRefine.Size = new System.Drawing.Size(127, 36);
            this.btnRefine.TabIndex = 0;
            this.btnRefine.Text = "细化";
            this.btnRefine.UseVisualStyleBackColor = true;
            this.btnRefine.Click += new System.EventHandler(this.btnRefine_Click);
            // 
            // btnBinarize
            // 
            this.btnBinarize.Location = new System.Drawing.Point(345, 37);
            this.btnBinarize.Name = "btnBinarize";
            this.btnBinarize.Size = new System.Drawing.Size(127, 36);
            this.btnBinarize.TabIndex = 0;
            this.btnBinarize.Text = "二值化";
            this.btnBinarize.UseVisualStyleBackColor = true;
            this.btnBinarize.Click += new System.EventHandler(this.btnBinarize_Click);
            // 
            // btnChainCode
            // 
            this.btnChainCode.Location = new System.Drawing.Point(191, 82);
            this.btnChainCode.Name = "btnChainCode";
            this.btnChainCode.Size = new System.Drawing.Size(127, 36);
            this.btnChainCode.TabIndex = 0;
            this.btnChainCode.Text = "链码提取";
            this.btnChainCode.UseVisualStyleBackColor = true;
            this.btnChainCode.Click += new System.EventHandler(this.btnChainCode_Click);
            // 
            // btnHistogram
            // 
            this.btnHistogram.Location = new System.Drawing.Point(191, 37);
            this.btnHistogram.Name = "btnHistogram";
            this.btnHistogram.Size = new System.Drawing.Size(127, 36);
            this.btnHistogram.TabIndex = 0;
            this.btnHistogram.Text = "灰度直方图";
            this.btnHistogram.UseVisualStyleBackColor = true;
            this.btnHistogram.Click += new System.EventHandler(this.btnHistogram_Click);
            // 
            // btnEdgeDetect
            // 
            this.btnEdgeDetect.Location = new System.Drawing.Point(47, 81);
            this.btnEdgeDetect.Name = "btnEdgeDetect";
            this.btnEdgeDetect.Size = new System.Drawing.Size(127, 36);
            this.btnEdgeDetect.TabIndex = 0;
            this.btnEdgeDetect.Text = "边缘检测";
            this.btnEdgeDetect.UseVisualStyleBackColor = true;
            this.btnEdgeDetect.Click += new System.EventHandler(this.btnEdgeDetect_Click);
            // 
            // btnGray
            // 
            this.btnGray.Location = new System.Drawing.Point(47, 37);
            this.btnGray.Name = "btnGray";
            this.btnGray.Size = new System.Drawing.Size(127, 36);
            this.btnGray.TabIndex = 0;
            this.btnGray.Text = "灰度化";
            this.btnGray.UseVisualStyleBackColor = true;
            this.btnGray.Click += new System.EventHandler(this.btnGray_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 458);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnExpand;
        private System.Windows.Forms.Button btnSharpen;
        private System.Windows.Forms.Button btnCorrode;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnRefine;
        private System.Windows.Forms.Button btnBinarize;
        private System.Windows.Forms.Button btnChainCode;
        private System.Windows.Forms.Button btnHistogram;
        private System.Windows.Forms.Button btnEdgeDetect;
        private System.Windows.Forms.Button btnGray;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

