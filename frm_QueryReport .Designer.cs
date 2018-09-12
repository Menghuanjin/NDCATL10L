namespace ND6L
{
    partial class frm_Log
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LineNumber = new System.Windows.Forms.NumericUpDown();
            this.labelX111 = new DevComponents.DotNetBar.LabelX();
            this.buttOutInfo = new DevComponents.DotNetBar.ButtonX();
            this.buttQuery = new DevComponents.DotNetBar.ButtonX();
            this.dgvmain = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.labelX108 = new DevComponents.DotNetBar.LabelX();
            this.labelX109 = new DevComponents.DotNetBar.LabelX();
            this.dtpEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dtpBegin = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErrorTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErrorContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.LineNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBegin)).BeginInit();
            this.SuspendLayout();
            // 
            // LineNumber
            // 
            this.LineNumber.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.LineNumber.Location = new System.Drawing.Point(62, 12);
            this.LineNumber.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.LineNumber.Name = "LineNumber";
            this.LineNumber.Size = new System.Drawing.Size(119, 21);
            this.LineNumber.TabIndex = 43;
            this.LineNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LineNumber.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // labelX111
            // 
            // 
            // 
            // 
            this.labelX111.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX111.Location = new System.Drawing.Point(3, 11);
            this.labelX111.Name = "labelX111";
            this.labelX111.Size = new System.Drawing.Size(70, 23);
            this.labelX111.TabIndex = 42;
            this.labelX111.Text = "查询行数：";
            // 
            // buttOutInfo
            // 
            this.buttOutInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttOutInfo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttOutInfo.Location = new System.Drawing.Point(925, 11);
            this.buttOutInfo.Name = "buttOutInfo";
            this.buttOutInfo.Size = new System.Drawing.Size(75, 23);
            this.buttOutInfo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttOutInfo.TabIndex = 40;
            this.buttOutInfo.Text = "导出";
            this.buttOutInfo.Click += new System.EventHandler(this.buttOutInfo_Click);
            // 
            // buttQuery
            // 
            this.buttQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttQuery.Location = new System.Drawing.Point(844, 11);
            this.buttQuery.Name = "buttQuery";
            this.buttQuery.Size = new System.Drawing.Size(75, 23);
            this.buttQuery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttQuery.TabIndex = 38;
            this.buttQuery.Text = "查询";
            this.buttQuery.Click += new System.EventHandler(this.buttQuery_Click);
            // 
            // dgvmain
            // 
            this.dgvmain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvmain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.dgvmain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvmain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.ErrorTime,
            this.ErrorContent});
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvmain.DefaultCellStyle = dataGridViewCellStyle26;
            this.dgvmain.EnableHeadersVisualStyles = false;
            this.dgvmain.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgvmain.Location = new System.Drawing.Point(3, 40);
            this.dgvmain.Name = "dgvmain";
            this.dgvmain.ReadOnly = true;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvmain.RowHeadersDefaultCellStyle = dataGridViewCellStyle27;
            dataGridViewCellStyle28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvmain.RowsDefaultCellStyle = dataGridViewCellStyle28;
            this.dgvmain.RowTemplate.Height = 23;
            this.dgvmain.Size = new System.Drawing.Size(1018, 722);
            this.dgvmain.TabIndex = 37;
            // 
            // labelX108
            // 
            // 
            // 
            // 
            this.labelX108.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX108.Location = new System.Drawing.Point(187, 12);
            this.labelX108.Name = "labelX108";
            this.labelX108.Size = new System.Drawing.Size(110, 23);
            this.labelX108.TabIndex = 36;
            this.labelX108.Text = "开始报警时间段：";
            // 
            // labelX109
            // 
            // 
            // 
            // 
            this.labelX109.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX109.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX109.Location = new System.Drawing.Point(545, 20);
            this.labelX109.Name = "labelX109";
            this.labelX109.Size = new System.Drawing.Size(33, 16);
            this.labelX109.TabIndex = 35;
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
            this.dtpEnd.Location = new System.Drawing.Point(580, 13);
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
            this.dtpEnd.Size = new System.Drawing.Size(245, 21);
            this.dtpEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtpEnd.TabIndex = 34;
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
            this.dtpBegin.Location = new System.Drawing.Point(295, 13);
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
            this.dtpBegin.Size = new System.Drawing.Size(242, 21);
            this.dtpBegin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtpBegin.TabIndex = 33;
            this.dtpBegin.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time24H;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // ErrorTime
            // 
            this.ErrorTime.DataPropertyName = "ErrorTime";
            this.ErrorTime.HeaderText = "报警发生时间";
            this.ErrorTime.Name = "ErrorTime";
            this.ErrorTime.ReadOnly = true;
            this.ErrorTime.Width = 300;
            // 
            // ErrorContent
            // 
            this.ErrorContent.DataPropertyName = "ErrorContent";
            this.ErrorContent.HeaderText = "报警内容";
            this.ErrorContent.Name = "ErrorContent";
            this.ErrorContent.ReadOnly = true;
            this.ErrorContent.Width = 500;
            // 
            // frm_Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1024, 772);
            this.Controls.Add(this.LineNumber);
            this.Controls.Add(this.labelX111);
            this.Controls.Add(this.buttOutInfo);
            this.Controls.Add(this.buttQuery);
            this.Controls.Add(this.dgvmain);
            this.Controls.Add(this.labelX108);
            this.Controls.Add(this.labelX109);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpBegin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Log";
            this.Text = "frm_Log";
            this.Load += new System.EventHandler(this.frm_Log_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LineNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBegin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown LineNumber;
        private DevComponents.DotNetBar.LabelX labelX111;
        private DevComponents.DotNetBar.ButtonX buttOutInfo;
        private DevComponents.DotNetBar.ButtonX buttQuery;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvmain;
        private DevComponents.DotNetBar.LabelX labelX108;
        private DevComponents.DotNetBar.LabelX labelX109;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtpEnd;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtpBegin;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErrorTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErrorContent;
    }
}