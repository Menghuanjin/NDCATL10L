namespace ND6L
{
    partial class frm_Authority
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Authority));
            this.label2 = new System.Windows.Forms.Label();
            this.SetPwodr = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.Increase = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.dgvmain = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErrorTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErrorContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.Authority = new System.Windows.Forms.ComboBox();
            this.SetName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.Order = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.Revise = new System.Windows.Forms.Button();
            this.Query = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmain)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 49;
            this.label2.Text = "密码：";
            // 
            // SetPwodr
            // 
            // 
            // 
            // 
            this.SetPwodr.Border.Class = "TextBoxBorder";
            this.SetPwodr.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.SetPwodr.Location = new System.Drawing.Point(218, 12);
            this.SetPwodr.Name = "SetPwodr";
            this.SetPwodr.PreventEnterBeep = true;
            this.SetPwodr.Size = new System.Drawing.Size(95, 21);
            this.SetPwodr.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 48;
            this.label1.Text = "用 户：";
            // 
            // Increase
            // 
            this.Increase.Location = new System.Drawing.Point(677, 15);
            this.Increase.Name = "Increase";
            this.Increase.Size = new System.Drawing.Size(61, 23);
            this.Increase.TabIndex = 59;
            this.Increase.Text = "增加";
            this.Increase.UseVisualStyleBackColor = true;
            this.Increase.Click += new System.EventHandler(this.button1_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(913, 13);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(57, 23);
            this.Delete.TabIndex = 60;
            this.Delete.Text = "删除";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonItem1
            // 
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "buttonItem1";
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
            this.ErrorTime,
            this.ErrorContent,
            this.Column1});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvmain.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvmain.EnableHeadersVisualStyles = false;
            this.dgvmain.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgvmain.Location = new System.Drawing.Point(5, 44);
            this.dgvmain.Name = "dgvmain";
            this.dgvmain.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvmain.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvmain.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvmain.RowTemplate.Height = 23;
            this.dgvmain.Size = new System.Drawing.Size(1020, 588);
            this.dgvmain.TabIndex = 61;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "序号";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // ErrorTime
            // 
            this.ErrorTime.DataPropertyName = "Name";
            this.ErrorTime.HeaderText = "用户：";
            this.ErrorTime.Name = "ErrorTime";
            this.ErrorTime.ReadOnly = true;
            this.ErrorTime.Width = 250;
            // 
            // ErrorContent
            // 
            this.ErrorContent.DataPropertyName = "Password";
            this.ErrorContent.HeaderText = "密码：";
            this.ErrorContent.Name = "ErrorContent";
            this.ErrorContent.ReadOnly = true;
            this.ErrorContent.Width = 250;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Authority";
            this.Column1.HeaderText = "权限";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 250;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(333, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 62;
            this.label3.Text = "权限：";
            // 
            // Authority
            // 
            this.Authority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Authority.FormattingEnabled = true;
            this.Authority.Items.AddRange(new object[] {
            "操作员",
            "管理员",
            "工程师"});
            this.Authority.Location = new System.Drawing.Point(380, 13);
            this.Authority.Name = "Authority";
            this.Authority.Size = new System.Drawing.Size(95, 20);
            this.Authority.TabIndex = 63;
            // 
            // SetName
            // 
            // 
            // 
            // 
            this.SetName.Border.Class = "TextBoxBorder";
            this.SetName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.SetName.Location = new System.Drawing.Point(65, 12);
            this.SetName.Name = "SetName";
            this.SetName.PreventEnterBeep = true;
            this.SetName.Size = new System.Drawing.Size(95, 21);
            this.SetName.TabIndex = 66;
            // 
            // Order
            // 
            // 
            // 
            // 
            this.Order.Border.Class = "TextBoxBorder";
            this.Order.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Order.Location = new System.Drawing.Point(551, 14);
            this.Order.Name = "Order";
            this.Order.PreventEnterBeep = true;
            this.Order.Size = new System.Drawing.Size(95, 21);
            this.Order.TabIndex = 67;
            // 
            // Revise
            // 
            this.Revise.Location = new System.Drawing.Point(757, 15);
            this.Revise.Name = "Revise";
            this.Revise.Size = new System.Drawing.Size(61, 23);
            this.Revise.TabIndex = 68;
            this.Revise.Text = "修改";
            this.Revise.UseVisualStyleBackColor = true;
            this.Revise.Click += new System.EventHandler(this.Revise_Click);
            // 
            // Query
            // 
            this.Query.Location = new System.Drawing.Point(837, 14);
            this.Query.Name = "Query";
            this.Query.Size = new System.Drawing.Size(61, 23);
            this.Query.TabIndex = 69;
            this.Query.Text = "查询";
            this.Query.UseVisualStyleBackColor = true;
            this.Query.Click += new System.EventHandler(this.Query_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(504, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 70;
            this.label4.Text = "序号：";
            // 
            // frm_Authority
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(973, 643);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Query);
            this.Controls.Add(this.Revise);
            this.Controls.Add(this.Order);
            this.Controls.Add(this.SetName);
            this.Controls.Add(this.Authority);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvmain);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Increase);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SetPwodr);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_Authority";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.UserSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvmain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.TextBoxX SetPwodr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Increase;
        private System.Windows.Forms.Button Delete;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvmain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Authority;
        private DevComponents.DotNetBar.Controls.TextBoxX SetName;
        private DevComponents.DotNetBar.Controls.TextBoxX Order;
        private System.Windows.Forms.Button Revise;
        private System.Windows.Forms.Button Query;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErrorTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErrorContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}