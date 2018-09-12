namespace ND6L
{
    partial class frm_Query
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelX111 = new DevComponents.DotNetBar.LabelX();
            this.buttOutInfo = new DevComponents.DotNetBar.ButtonX();
            this.buttQuery = new DevComponents.DotNetBar.ButtonX();
            this.dgvmain = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.labelX108 = new DevComponents.DotNetBar.LabelX();
            this.labelX109 = new DevComponents.DotNetBar.LabelX();
            this.dtpEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dtpBegin = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.Door = new System.Windows.Forms.ComboBox();
            this.labelX110 = new DevComponents.DotNetBar.LabelX();
            this.LineNumber = new System.Windows.Forms.NumericUpDown();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LowerLeft2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.machineID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Storey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UppeLeft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LowerLeft1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sadf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBegin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX111
            // 
            // 
            // 
            // 
            this.labelX111.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX111.Location = new System.Drawing.Point(151, 11);
            this.labelX111.Name = "labelX111";
            this.labelX111.Size = new System.Drawing.Size(70, 23);
            this.labelX111.TabIndex = 31;
            this.labelX111.Text = "查询行数：";
            // 
            // buttOutInfo
            // 
            this.buttOutInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttOutInfo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttOutInfo.Location = new System.Drawing.Point(925, 9);
            this.buttOutInfo.Name = "buttOutInfo";
            this.buttOutInfo.Size = new System.Drawing.Size(75, 23);
            this.buttOutInfo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttOutInfo.TabIndex = 29;
            this.buttOutInfo.Text = "导出";
            this.buttOutInfo.Click += new System.EventHandler(this.buttOutInfo_Click);
            // 
            // buttQuery
            // 
            this.buttQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttQuery.Location = new System.Drawing.Point(844, 9);
            this.buttQuery.Name = "buttQuery";
            this.buttQuery.Size = new System.Drawing.Size(75, 23);
            this.buttQuery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttQuery.TabIndex = 26;
            this.buttQuery.Text = "查询";
            this.buttQuery.Click += new System.EventHandler(this.buttQuery_Click);
            // 
            // dgvmain
            // 
            this.dgvmain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvmain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvmain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvmain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.LowerLeft2,
            this.Column1,
            this.machineID,
            this.Storey,
            this.SyTime,
            this.UppeLeft,
            this.LowerLeft1,
            this.sadf});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvmain.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvmain.EnableHeadersVisualStyles = false;
            this.dgvmain.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgvmain.Location = new System.Drawing.Point(3, 38);
            this.dgvmain.Name = "dgvmain";
            this.dgvmain.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvmain.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvmain.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvmain.RowTemplate.Height = 23;
            this.dgvmain.Size = new System.Drawing.Size(1018, 722);
            this.dgvmain.TabIndex = 25;
            // 
            // labelX108
            // 
            // 
            // 
            // 
            this.labelX108.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX108.Location = new System.Drawing.Point(290, 13);
            this.labelX108.Name = "labelX108";
            this.labelX108.Size = new System.Drawing.Size(68, 23);
            this.labelX108.TabIndex = 24;
            this.labelX108.Text = "采集时间：";
            // 
            // labelX109
            // 
            // 
            // 
            // 
            this.labelX109.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX109.Location = new System.Drawing.Point(598, 17);
            this.labelX109.Name = "labelX109";
            this.labelX109.Size = new System.Drawing.Size(10, 19);
            this.labelX109.TabIndex = 23;
            this.labelX109.Text = "~";
            // 
            // dtpEnd
            // 
            // 
            // 
            // 
            this.dtpEnd.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtpEnd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpEnd.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtpEnd.ButtonDropDown.Visible = true;
            this.dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEnd.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtpEnd.IsPopupCalendarOpen = false;
            this.dtpEnd.Location = new System.Drawing.Point(623, 11);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtpEnd.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpEnd.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtpEnd.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtpEnd.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtpEnd.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpEnd.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtpEnd.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtpEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtpEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtpEnd.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpEnd.MonthCalendar.DisplayMonth = new System.DateTime(2017, 5, 1, 0, 0, 0, 0);
            this.dtpEnd.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.dtpEnd.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtpEnd.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpEnd.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtpEnd.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpEnd.MonthCalendar.TodayButtonVisible = true;
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(215, 21);
            this.dtpEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtpEnd.TabIndex = 22;
            this.dtpEnd.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time24H;
            // 
            // dtpBegin
            // 
            // 
            // 
            // 
            this.dtpBegin.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtpBegin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpBegin.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtpBegin.ButtonDropDown.Visible = true;
            this.dtpBegin.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpBegin.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtpBegin.IsPopupCalendarOpen = false;
            this.dtpBegin.Location = new System.Drawing.Point(358, 11);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtpBegin.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpBegin.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtpBegin.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtpBegin.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtpBegin.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpBegin.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtpBegin.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtpBegin.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtpBegin.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtpBegin.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpBegin.MonthCalendar.DisplayMonth = new System.DateTime(2017, 5, 1, 0, 0, 0, 0);
            this.dtpBegin.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.dtpBegin.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtpBegin.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpBegin.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtpBegin.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpBegin.MonthCalendar.TodayButtonVisible = true;
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(224, 21);
            this.dtpBegin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtpBegin.TabIndex = 21;
            this.dtpBegin.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time24H;
            // 
            // Door
            // 
            this.Door.FormattingEnabled = true;
            this.Door.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.Door.Location = new System.Drawing.Point(70, 12);
            this.Door.Name = "Door";
            this.Door.Size = new System.Drawing.Size(75, 20);
            this.Door.TabIndex = 27;
            // 
            // labelX110
            // 
            // 
            // 
            // 
            this.labelX110.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX110.Location = new System.Drawing.Point(4, 11);
            this.labelX110.Name = "labelX110";
            this.labelX110.Size = new System.Drawing.Size(66, 23);
            this.labelX110.TabIndex = 30;
            this.labelX110.Text = "机器门号：";
            // 
            // LineNumber
            // 
            this.LineNumber.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.LineNumber.Location = new System.Drawing.Point(214, 12);
            this.LineNumber.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.LineNumber.Name = "LineNumber";
            this.LineNumber.Size = new System.Drawing.Size(70, 21);
            this.LineNumber.TabIndex = 32;
            this.LineNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LineNumber.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // LowerLeft2
            // 
            this.LowerLeft2.DataPropertyName = "WriteTime";
            this.LowerLeft2.HeaderText = "采集时间";
            this.LowerLeft2.Name = "LowerLeft2";
            this.LowerLeft2.ReadOnly = true;
            this.LowerLeft2.Width = 200;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Door";
            this.Column1.HeaderText = "门号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 80;
            // 
            // machineID
            // 
            this.machineID.DataPropertyName = "UpperLimitOfTemperature";
            this.machineID.HeaderText = "温度上限";
            this.machineID.Name = "machineID";
            this.machineID.ReadOnly = true;
            // 
            // Storey
            // 
            this.Storey.DataPropertyName = "LowerTemperatureLimit";
            this.Storey.HeaderText = "温度下限";
            this.Storey.Name = "Storey";
            this.Storey.ReadOnly = true;
            // 
            // SyTime
            // 
            this.SyTime.DataPropertyName = "SetValueMonitoringTemperature";
            this.SyTime.HeaderText = "设定温度";
            this.SyTime.Name = "SyTime";
            this.SyTime.ReadOnly = true;
            // 
            // UppeLeft
            // 
            this.UppeLeft.DataPropertyName = "MonitoringTemperature";
            this.UppeLeft.HeaderText = "监控温度";
            this.UppeLeft.Name = "UppeLeft";
            this.UppeLeft.ReadOnly = true;
            // 
            // LowerLeft1
            // 
            this.LowerLeft1.DataPropertyName = "RunTime";
            dataGridViewCellStyle2.Format = "yyyy-MM-dd HH:mm:ss.fff";
            this.LowerLeft1.DefaultCellStyle = dataGridViewCellStyle2;
            this.LowerLeft1.HeaderText = "运行时间";
            this.LowerLeft1.Name = "LowerLeft1";
            this.LowerLeft1.ReadOnly = true;
            // 
            // sadf
            // 
            this.sadf.DataPropertyName = "SetTime";
            this.sadf.HeaderText = "设定时间";
            this.sadf.Name = "sadf";
            this.sadf.ReadOnly = true;
            // 
            // frm_Query
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1024, 772);
            this.Controls.Add(this.LineNumber);
            this.Controls.Add(this.labelX111);
            this.Controls.Add(this.labelX110);
            this.Controls.Add(this.buttOutInfo);
            this.Controls.Add(this.Door);
            this.Controls.Add(this.buttQuery);
            this.Controls.Add(this.dgvmain);
            this.Controls.Add(this.labelX108);
            this.Controls.Add(this.labelX109);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpBegin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Query";
            this.Text = "query";
            this.Load += new System.EventHandler(this.query_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvmain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBegin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineNumber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX111;
        private DevComponents.DotNetBar.ButtonX buttOutInfo;
        private DevComponents.DotNetBar.ButtonX buttQuery;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvmain;
        private DevComponents.DotNetBar.LabelX labelX108;
        private DevComponents.DotNetBar.LabelX labelX109;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtpEnd;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtpBegin;
        private System.Windows.Forms.ComboBox Door;
        private DevComponents.DotNetBar.LabelX labelX110;
        private System.Windows.Forms.NumericUpDown LineNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn LowerLeft2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn machineID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Storey;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn UppeLeft;
        private System.Windows.Forms.DataGridViewTextBoxColumn LowerLeft1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sadf;
    }
}