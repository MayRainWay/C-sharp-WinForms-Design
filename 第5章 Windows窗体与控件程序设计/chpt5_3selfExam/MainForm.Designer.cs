namespace chpt5_3selfExam
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.题型选择tToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.初级自测题PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中级自测题SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.高级自测题AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.测试1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.测试2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.帮助hToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于系统AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Font = new System.Drawing.Font("等线", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(229, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "四叶党点炮过年";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(141, 477);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(478, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "版权所有 2020-2035 中野四叶党组委员会";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.题型选择tToolStripMenuItem,
            this.帮助hToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(778, 32);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出XToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(80, 28);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            this.文件FToolStripMenuItem.Click += new System.EventHandler(this.文件FToolStripMenuItem_Click);
            // 
            // 退出XToolStripMenuItem
            // 
            this.退出XToolStripMenuItem.Name = "退出XToolStripMenuItem";
            this.退出XToolStripMenuItem.Size = new System.Drawing.Size(152, 30);
            this.退出XToolStripMenuItem.Text = "退出(&X)";
            this.退出XToolStripMenuItem.Click += new System.EventHandler(this.退出XToolStripMenuItem_Click);
            // 
            // 题型选择tToolStripMenuItem
            // 
            this.题型选择tToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.初级自测题PToolStripMenuItem,
            this.中级自测题SToolStripMenuItem,
            this.高级自测题AToolStripMenuItem,
            this.测试1ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.测试2ToolStripMenuItem,
            this.toolStripSeparator1});
            this.题型选择tToolStripMenuItem.Name = "题型选择tToolStripMenuItem";
            this.题型选择tToolStripMenuItem.Size = new System.Drawing.Size(116, 28);
            this.题型选择tToolStripMenuItem.Text = "题型选择(&T)";
            // 
            // 初级自测题PToolStripMenuItem
            // 
            this.初级自测题PToolStripMenuItem.Name = "初级自测题PToolStripMenuItem";
            this.初级自测题PToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.初级自测题PToolStripMenuItem.Text = "初级自测题(&P)";
            this.初级自测题PToolStripMenuItem.Click += new System.EventHandler(this.初级自测题PToolStripMenuItem_Click);
            // 
            // 中级自测题SToolStripMenuItem
            // 
            this.中级自测题SToolStripMenuItem.Name = "中级自测题SToolStripMenuItem";
            this.中级自测题SToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.中级自测题SToolStripMenuItem.Text = "中级自测题(&S)";
            this.中级自测题SToolStripMenuItem.Click += new System.EventHandler(this.中级自测题SToolStripMenuItem_Click);
            // 
            // 高级自测题AToolStripMenuItem
            // 
            this.高级自测题AToolStripMenuItem.Name = "高级自测题AToolStripMenuItem";
            this.高级自测题AToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.高级自测题AToolStripMenuItem.Text = "高级自测题(&A)";
            this.高级自测题AToolStripMenuItem.Click += new System.EventHandler(this.高级自测题AToolStripMenuItem_Click);
            // 
            // 测试1ToolStripMenuItem
            // 
            this.测试1ToolStripMenuItem.Name = "测试1ToolStripMenuItem";
            this.测试1ToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.测试1ToolStripMenuItem.Text = "测试1";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(207, 6);
            // 
            // 测试2ToolStripMenuItem
            // 
            this.测试2ToolStripMenuItem.Name = "测试2ToolStripMenuItem";
            this.测试2ToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.测试2ToolStripMenuItem.Text = "测试2";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(207, 6);
            // 
            // 帮助hToolStripMenuItem
            // 
            this.帮助hToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于系统AToolStripMenuItem});
            this.帮助hToolStripMenuItem.Name = "帮助hToolStripMenuItem";
            this.帮助hToolStripMenuItem.Size = new System.Drawing.Size(84, 28);
            this.帮助hToolStripMenuItem.Text = "帮助(&H)";
            // 
            // 关于系统AToolStripMenuItem
            // 
            this.关于系统AToolStripMenuItem.Name = "关于系统AToolStripMenuItem";
            this.关于系统AToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.关于系统AToolStripMenuItem.Text = "关于系统(&A)";
            this.关于系统AToolStripMenuItem.Click += new System.EventHandler(this.关于系统AToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripComboBox1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 32);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(778, 32);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::chpt5_3selfExam.Properties.Resources._00_中野四叶;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(28, 29);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "关闭所有子窗体";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "层叠排列",
            "水平平铺",
            "垂直平铺",
            "图标排列"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 32);
            this.toolStripComboBox1.ToolTipText = "子窗体排列方式";
            this.toolStripComboBox1.TextChanged += new System.EventHandler(this.toolStripComboBox1_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImage = global::chpt5_3selfExam.Properties.Resources.一花__1_;
            this.pictureBox1.Image = global::chpt5_3selfExam.Properties.Resources.五等分的花嫁__7_;
            this.pictureBox1.Location = new System.Drawing.Point(191, 178);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(357, 296);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(778, 544);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "中野四叶天下第一！";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 题型选择tToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 初级自测题PToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 中级自测题SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 高级自测题AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助hToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于系统AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 测试1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 测试2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
    }
}

