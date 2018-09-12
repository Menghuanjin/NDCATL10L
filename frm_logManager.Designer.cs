namespace ND6L
{
    partial class frm_logManager
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_logManager));
            this.SetCSV = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.btnSet = new DevComponents.DotNetBar.ButtonX();
            this.RefreshTime = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.SuspendLayout();
            // 
            // SetCSV
            // 
            // 
            // 
            // 
            this.SetCSV.Border.Class = "TextBoxBorder";
            this.SetCSV.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.SetCSV.ButtonCustom.Tooltip = "";
            this.SetCSV.ButtonCustom2.Tooltip = "";
            this.SetCSV.Location = new System.Drawing.Point(105, 54);
            this.SetCSV.Name = "SetCSV";
            this.SetCSV.PreventEnterBeep = true;
            this.SetCSV.Size = new System.Drawing.Size(180, 21);
            this.SetCSV.TabIndex = 25;
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(1, 54);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(100, 23);
            this.labelX6.TabIndex = 24;
            this.labelX6.Text = "CSV文件夹路径：";
            // 
            // btnSet
            // 
            this.btnSet.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSet.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSet.Location = new System.Drawing.Point(126, 117);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(97, 23);
            this.btnSet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSet.TabIndex = 23;
            this.btnSet.Text = "修改";
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // RefreshTime
            // 
            // 
            // 
            // 
            this.RefreshTime.Border.Class = "TextBoxBorder";
            this.RefreshTime.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.RefreshTime.ButtonCustom.Tooltip = "";
            this.RefreshTime.ButtonCustom2.Tooltip = "";
            this.RefreshTime.Location = new System.Drawing.Point(105, 14);
            this.RefreshTime.Name = "RefreshTime";
            this.RefreshTime.PreventEnterBeep = true;
            this.RefreshTime.Size = new System.Drawing.Size(180, 21);
            this.RefreshTime.TabIndex = 20;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(21, 14);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(108, 23);
            this.labelX4.TabIndex = 19;
            this.labelX4.Text = "刷新时间(秒)：";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154))))));
            // 
            // logManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(367, 285);
            this.Controls.Add(this.SetCSV);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.RefreshTime);
            this.Controls.Add(this.labelX4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "logManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "logManager";
            this.Load += new System.EventHandler(this.logManager_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX SetCSV;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.ButtonX btnSet;
       public DevComponents.DotNetBar.Controls.TextBoxX RefreshTime;
       private DevComponents.DotNetBar.LabelX labelX4;
       private DevComponents.DotNetBar.StyleManager styleManager1;
    }
}