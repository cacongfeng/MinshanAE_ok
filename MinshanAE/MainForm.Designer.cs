namespace MinshanAE
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.axPageLayoutControl1 = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AttTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WaterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ResidentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TrafficToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RegionCB = new System.Windows.Forms.CheckBox();
            this.TypeCB = new System.Windows.Forms.CheckBox();
            this.ResidentCB = new System.Windows.Forms.CheckBox();
            this.TrafficCB = new System.Windows.Forms.CheckBox();
            this.WaterCB = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 25);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(756, 28);
            this.axToolbarControl1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(611, 389);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.axMapControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(603, 363);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "地图";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(3, 3);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(597, 357);
            this.axMapControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.axLicenseControl1);
            this.tabPage2.Controls.Add(this.axPageLayoutControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(603, 363);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "打印";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(216, 235);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 1;
            // 
            // axPageLayoutControl1
            // 
            this.axPageLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axPageLayoutControl1.Location = new System.Drawing.Point(3, 3);
            this.axPageLayoutControl1.Name = "axPageLayoutControl1";
            this.axPageLayoutControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPageLayoutControl1.OcxState")));
            this.axPageLayoutControl1.Size = new System.Drawing.Size(597, 357);
            this.axPageLayoutControl1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.ToolToolStripMenuItem,
            this.AttTableToolStripMenuItem,
            this.AboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(756, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.FileToolStripMenuItem.Text = "文件";
            // 
            // ToolToolStripMenuItem
            // 
            this.ToolToolStripMenuItem.Name = "ToolToolStripMenuItem";
            this.ToolToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.ToolToolStripMenuItem.Text = "工具";
            // 
            // AttTableToolStripMenuItem
            // 
            this.AttTableToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TypeToolStripMenuItem,
            this.WaterToolStripMenuItem,
            this.ResidentToolStripMenuItem,
            this.TrafficToolStripMenuItem});
            this.AttTableToolStripMenuItem.Name = "AttTableToolStripMenuItem";
            this.AttTableToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.AttTableToolStripMenuItem.Text = "属性查询";
            // 
            // TypeToolStripMenuItem
            // 
            this.TypeToolStripMenuItem.Name = "TypeToolStripMenuItem";
            this.TypeToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.TypeToolStripMenuItem.Text = "植被覆盖类型";
            this.TypeToolStripMenuItem.Click += new System.EventHandler(this.TypeToolStripMenuItem_Click);
            // 
            // WaterToolStripMenuItem
            // 
            this.WaterToolStripMenuItem.Name = "WaterToolStripMenuItem";
            this.WaterToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.WaterToolStripMenuItem.Text = "水系";
            this.WaterToolStripMenuItem.Click += new System.EventHandler(this.WaterToolStripMenuItem_Click);
            // 
            // ResidentToolStripMenuItem
            // 
            this.ResidentToolStripMenuItem.Name = "ResidentToolStripMenuItem";
            this.ResidentToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.ResidentToolStripMenuItem.Text = "居民地";
            this.ResidentToolStripMenuItem.Click += new System.EventHandler(this.ResidentToolStripMenuItem_Click);
            // 
            // TrafficToolStripMenuItem
            // 
            this.TrafficToolStripMenuItem.Name = "TrafficToolStripMenuItem";
            this.TrafficToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.TrafficToolStripMenuItem.Text = "交通";
            this.TrafficToolStripMenuItem.Click += new System.EventHandler(this.TrafficToolStripMenuItem_Click);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.AboutToolStripMenuItem.Text = "关于";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox1.ForeColor = System.Drawing.Color.Black;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "灌木林",
            "高覆盖草地",
            "针叶林",
            "农业用地",
            "中覆盖草地",
            "混交林",
            "低覆盖草地",
            "阔叶林",
            "其他用地"});
            this.comboBox1.Location = new System.Drawing.Point(631, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.Text = "选择类型";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(536, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "土地利用类型：";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 53);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 389);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axTOCControl1.Location = new System.Drawing.Point(0, 0);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(138, 241);
            this.axTOCControl1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.RegionCB);
            this.groupBox1.Controls.Add(this.TypeCB);
            this.groupBox1.Controls.Add(this.ResidentCB);
            this.groupBox1.Controls.Add(this.TrafficCB);
            this.groupBox1.Controls.Add(this.WaterCB);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 241);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(138, 148);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "标注显示";
            // 
            // RegionCB
            // 
            this.RegionCB.AutoSize = true;
            this.RegionCB.Location = new System.Drawing.Point(22, 117);
            this.RegionCB.Name = "RegionCB";
            this.RegionCB.Size = new System.Drawing.Size(60, 16);
            this.RegionCB.TabIndex = 0;
            this.RegionCB.Text = "行政区";
            this.RegionCB.UseVisualStyleBackColor = true;
            this.RegionCB.CheckedChanged += new System.EventHandler(this.RegionCB_CheckedChanged);
            // 
            // TypeCB
            // 
            this.TypeCB.AutoSize = true;
            this.TypeCB.Location = new System.Drawing.Point(22, 95);
            this.TypeCB.Name = "TypeCB";
            this.TypeCB.Size = new System.Drawing.Size(72, 16);
            this.TypeCB.TabIndex = 0;
            this.TypeCB.Text = "植被覆盖";
            this.TypeCB.UseVisualStyleBackColor = true;
            this.TypeCB.CheckedChanged += new System.EventHandler(this.TypeCB_CheckedChanged);
            // 
            // ResidentCB
            // 
            this.ResidentCB.AutoSize = true;
            this.ResidentCB.Location = new System.Drawing.Point(22, 73);
            this.ResidentCB.Name = "ResidentCB";
            this.ResidentCB.Size = new System.Drawing.Size(60, 16);
            this.ResidentCB.TabIndex = 0;
            this.ResidentCB.Text = "居民地";
            this.ResidentCB.UseVisualStyleBackColor = true;
            this.ResidentCB.CheckedChanged += new System.EventHandler(this.ResidentCB_CheckedChanged);
            // 
            // TrafficCB
            // 
            this.TrafficCB.AutoSize = true;
            this.TrafficCB.Location = new System.Drawing.Point(22, 51);
            this.TrafficCB.Name = "TrafficCB";
            this.TrafficCB.Size = new System.Drawing.Size(48, 16);
            this.TrafficCB.TabIndex = 0;
            this.TrafficCB.Text = "交通";
            this.TrafficCB.UseVisualStyleBackColor = true;
            this.TrafficCB.CheckedChanged += new System.EventHandler(this.TrafficCB_CheckedChanged);
            // 
            // WaterCB
            // 
            this.WaterCB.AutoSize = true;
            this.WaterCB.Location = new System.Drawing.Point(22, 29);
            this.WaterCB.Name = "WaterCB";
            this.WaterCB.Size = new System.Drawing.Size(48, 16);
            this.WaterCB.TabIndex = 0;
            this.WaterCB.Text = "水系";
            this.WaterCB.UseVisualStyleBackColor = true;
            this.WaterCB.CheckedChanged += new System.EventHandler(this.WaterCB_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.axTOCControl1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(138, 389);
            this.panel1.TabIndex = 8;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 53);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(753, 389);
            this.splitContainer1.SplitterDistance = 138;
            this.splitContainer1.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 442);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "岷山基础地理信息查询系统";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AttTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WaterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ResidentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TrafficToolStripMenuItem;
        private System.Windows.Forms.Splitter splitter1;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox TypeCB;
        private System.Windows.Forms.CheckBox ResidentCB;
        private System.Windows.Forms.CheckBox TrafficCB;
        private System.Windows.Forms.CheckBox WaterCB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox RegionCB;
    }
}

