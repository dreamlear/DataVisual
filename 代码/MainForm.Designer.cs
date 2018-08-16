namespace TestParseTraco
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
            this.buttonLoadFile = new System.Windows.Forms.Button();
            this.listviewFileInfo = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textCondition = new System.Windows.Forms.TextBox();
            this.listviewVariable = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.warningTextBox = new System.Windows.Forms.TextBox();
            this.comboBoxSelect = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMax = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.listThreshold = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnMin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnMax = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonExport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonLoadFile
            // 
            this.buttonLoadFile.Location = new System.Drawing.Point(18, 10);
            this.buttonLoadFile.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLoadFile.Name = "buttonLoadFile";
            this.buttonLoadFile.Size = new System.Drawing.Size(112, 34);
            this.buttonLoadFile.TabIndex = 0;
            this.buttonLoadFile.Text = "加载文件";
            this.buttonLoadFile.UseVisualStyleBackColor = true;
            this.buttonLoadFile.Click += new System.EventHandler(this.buttonLoadFile_Click);
            // 
            // listviewFileInfo
            // 
            this.listviewFileInfo.AllowColumnReorder = true;
            this.listviewFileInfo.AllowDrop = true;
            this.listviewFileInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listviewFileInfo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listviewFileInfo.FullRowSelect = true;
            this.listviewFileInfo.GridLines = true;
            this.listviewFileInfo.Location = new System.Drawing.Point(2, 57);
            this.listviewFileInfo.Margin = new System.Windows.Forms.Padding(4);
            this.listviewFileInfo.MultiSelect = false;
            this.listviewFileInfo.Name = "listviewFileInfo";
            this.listviewFileInfo.Size = new System.Drawing.Size(424, 196);
            this.listviewFileInfo.TabIndex = 9;
            this.listviewFileInfo.UseCompatibleStateImageBehavior = false;
            this.listviewFileInfo.View = System.Windows.Forms.View.Details;
            this.listviewFileInfo.SelectedIndexChanged += new System.EventHandler(this.listviewFileInfo_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名称";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "时间";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "描述";
            this.columnHeader3.Width = 120;
            // 
            // textCondition
            // 
            this.textCondition.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textCondition.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textCondition.Location = new System.Drawing.Point(2, 264);
            this.textCondition.Margin = new System.Windows.Forms.Padding(4);
            this.textCondition.Multiline = true;
            this.textCondition.Name = "textCondition";
            this.textCondition.ReadOnly = true;
            this.textCondition.Size = new System.Drawing.Size(424, 109);
            this.textCondition.TabIndex = 13;
            // 
            // listviewVariable
            // 
            this.listviewVariable.AllowColumnReorder = true;
            this.listviewVariable.AllowDrop = true;
            this.listviewVariable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listviewVariable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listviewVariable.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listviewVariable.FullRowSelect = true;
            this.listviewVariable.GridLines = true;
            this.listviewVariable.Location = new System.Drawing.Point(2, 384);
            this.listviewVariable.Margin = new System.Windows.Forms.Padding(4);
            this.listviewVariable.Name = "listviewVariable";
            this.listviewVariable.Size = new System.Drawing.Size(424, 396);
            this.listviewVariable.TabIndex = 15;
            this.listviewVariable.UseCompatibleStateImageBehavior = false;
            this.listviewVariable.View = System.Windows.Forms.View.Details;
            this.listviewVariable.SelectedIndexChanged += new System.EventHandler(this.listviewVariable_SelectedIndexChanged);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "名称";
            this.columnHeader5.Width = 224;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "类型";
            this.columnHeader6.Width = 80;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "地址";
            this.columnHeader7.Width = 150;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.AutoScrollMargin = new System.Drawing.Size(1, 1);
            this.flowLayoutPanel.ForeColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel.Location = new System.Drawing.Point(433, 57);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(1467, 573);
            this.flowLayoutPanel.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("思源黑体 Bold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(430, 633);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 27);
            this.label1.TabIndex = 19;
            this.label1.Text = "警示框";
            // 
            // warningTextBox
            // 
            this.warningTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.warningTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.warningTextBox.Font = new System.Drawing.Font("思源黑体 Bold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.warningTextBox.ForeColor = System.Drawing.Color.Red;
            this.warningTextBox.Location = new System.Drawing.Point(433, 663);
            this.warningTextBox.Multiline = true;
            this.warningTextBox.Name = "warningTextBox";
            this.warningTextBox.ReadOnly = true;
            this.warningTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.warningTextBox.Size = new System.Drawing.Size(849, 117);
            this.warningTextBox.TabIndex = 20;
            // 
            // comboBoxSelect
            // 
            this.comboBoxSelect.Font = new System.Drawing.Font("思源黑体 Regular", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxSelect.FormattingEnabled = true;
            this.comboBoxSelect.Location = new System.Drawing.Point(535, 10);
            this.comboBoxSelect.Name = "comboBoxSelect";
            this.comboBoxSelect.Size = new System.Drawing.Size(327, 39);
            this.comboBoxSelect.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("思源黑体 Regular", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(431, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 31);
            this.label2.TabIndex = 22;
            this.label2.Text = "选择参数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("思源黑体 Regular", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(890, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 31);
            this.label3.TabIndex = 23;
            this.label3.Text = "阈值范围：最小值\r\n";
            // 
            // textBoxMin
            // 
            this.textBoxMin.Font = new System.Drawing.Font("思源黑体 Regular", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxMin.Location = new System.Drawing.Point(1091, 10);
            this.textBoxMin.Name = "textBoxMin";
            this.textBoxMin.Size = new System.Drawing.Size(100, 39);
            this.textBoxMin.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("思源黑体 Regular", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(1216, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 31);
            this.label4.TabIndex = 25;
            this.label4.Text = "最大值";
            // 
            // textBoxMax
            // 
            this.textBoxMax.Font = new System.Drawing.Font("思源黑体 Regular", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxMax.Location = new System.Drawing.Point(1299, 10);
            this.textBoxMax.Name = "textBoxMax";
            this.textBoxMax.Size = new System.Drawing.Size(100, 39);
            this.textBoxMax.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("思源黑体 Bold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(1314, 633);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 27);
            this.label5.TabIndex = 27;
            this.label5.Text = "参数阈值情况";
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonConfirm.Font = new System.Drawing.Font("思源黑体 Regular", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonConfirm.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.buttonConfirm.Location = new System.Drawing.Point(1466, 7);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(110, 43);
            this.buttonConfirm.TabIndex = 29;
            this.buttonConfirm.Text = "确定";
            this.buttonConfirm.UseVisualStyleBackColor = false;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonReset.Font = new System.Drawing.Font("思源黑体 Regular", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonReset.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.buttonReset.Location = new System.Drawing.Point(1605, 7);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(110, 43);
            this.buttonReset.TabIndex = 30;
            this.buttonReset.Text = "重置";
            this.buttonReset.UseVisualStyleBackColor = false;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // listThreshold
            // 
            this.listThreshold.AllowColumnReorder = true;
            this.listThreshold.AllowDrop = true;
            this.listThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listThreshold.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnMin,
            this.columnMax});
            this.listThreshold.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listThreshold.FullRowSelect = true;
            this.listThreshold.GridLines = true;
            this.listThreshold.Location = new System.Drawing.Point(1319, 664);
            this.listThreshold.Margin = new System.Windows.Forms.Padding(4);
            this.listThreshold.Name = "listThreshold";
            this.listThreshold.Size = new System.Drawing.Size(581, 116);
            this.listThreshold.TabIndex = 31;
            this.listThreshold.UseCompatibleStateImageBehavior = false;
            this.listThreshold.View = System.Windows.Forms.View.Details;
            // 
            // columnName
            // 
            this.columnName.Text = "参数名称";
            this.columnName.Width = 300;
            // 
            // columnMin
            // 
            this.columnMin.Text = "最小阈值";
            this.columnMin.Width = 120;
            // 
            // columnMax
            // 
            this.columnMax.Text = "最大阈值";
            this.columnMax.Width = 120;
            // 
            // buttonExport
            // 
            this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExport.Font = new System.Drawing.Font("思源黑体 Regular", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonExport.Location = new System.Drawing.Point(1204, 633);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(78, 29);
            this.buttonExport.TabIndex = 32;
            this.buttonExport.Text = "导出";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1924, 786);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.listThreshold);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxMax);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxMin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxSelect);
            this.Controls.Add(this.warningTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.listviewVariable);
            this.Controls.Add(this.textCondition);
            this.Controls.Add(this.listviewFileInfo);
            this.Controls.Add(this.buttonLoadFile);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "高铁运行参数可视化分析模块";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLoadFile;
        private System.Windows.Forms.ListView listviewFileInfo;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TextBox textCondition;
        private System.Windows.Forms.ListView listviewVariable;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox warningTextBox;
        private System.Windows.Forms.ComboBox comboBoxSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxMin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxMax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.ListView listThreshold;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnMin;
        private System.Windows.Forms.ColumnHeader columnMax;
        private System.Windows.Forms.Button buttonExport;
    }
}

