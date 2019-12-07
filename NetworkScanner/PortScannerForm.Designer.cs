namespace NetworkScanner
{
    partial class PortScannerForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.nudTimeout = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudWorkers = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudEndPort = new System.Windows.Forms.NumericUpDown();
            this.nudStartPort = new System.Windows.Forms.NumericUpDown();
            this.grdPorts = new NetworkScanner.Controls.PortsGrid();
            this.cbPortTypes = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWorkers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPorts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(271, 91);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 534);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(384, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslStatus
            // 
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Start port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "End port:";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(15, 91);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(253, 23);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "Scan for ports";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // nudTimeout
            // 
            this.nudTimeout.Location = new System.Drawing.Point(271, 38);
            this.nudTimeout.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudTimeout.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudTimeout.Name = "nudTimeout";
            this.nudTimeout.Size = new System.Drawing.Size(100, 20);
            this.nudTimeout.TabIndex = 9;
            this.nudTimeout.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(196, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Timeout:";
            // 
            // nudWorkers
            // 
            this.nudWorkers.Location = new System.Drawing.Point(90, 38);
            this.nudWorkers.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.nudWorkers.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudWorkers.Name = "nudWorkers";
            this.nudWorkers.Size = new System.Drawing.Size(100, 20);
            this.nudWorkers.TabIndex = 11;
            this.nudWorkers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Workers:";
            // 
            // nudEndPort
            // 
            this.nudEndPort.Location = new System.Drawing.Point(271, 12);
            this.nudEndPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudEndPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEndPort.Name = "nudEndPort";
            this.nudEndPort.Size = new System.Drawing.Size(100, 20);
            this.nudEndPort.TabIndex = 15;
            this.nudEndPort.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudEndPort.ValueChanged += new System.EventHandler(this.nudEndPort_ValueChanged);
            // 
            // nudStartPort
            // 
            this.nudStartPort.Location = new System.Drawing.Point(90, 12);
            this.nudStartPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudStartPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudStartPort.Name = "nudStartPort";
            this.nudStartPort.Size = new System.Drawing.Size(100, 20);
            this.nudStartPort.TabIndex = 16;
            this.nudStartPort.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudStartPort.ValueChanged += new System.EventHandler(this.nudStartPort_ValueChanged);
            // 
            // grdPorts
            // 
            this.grdPorts.AllowUserToAddRows = false;
            this.grdPorts.AllowUserToDeleteRows = false;
            this.grdPorts.AllowUserToResizeColumns = false;
            this.grdPorts.AllowUserToResizeRows = false;
            this.grdPorts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdPorts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPorts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column3});
            this.grdPorts.Items = null;
            this.grdPorts.Location = new System.Drawing.Point(15, 120);
            this.grdPorts.MultiSelect = false;
            this.grdPorts.Name = "grdPorts";
            this.grdPorts.ReadOnly = true;
            this.grdPorts.RowHeadersVisible = false;
            this.grdPorts.SelectedIndex = null;
            this.grdPorts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPorts.Size = new System.Drawing.Size(356, 411);
            this.grdPorts.TabIndex = 17;
            // 
            // cbPortTypes
            // 
            this.cbPortTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPortTypes.FormattingEnabled = true;
            this.cbPortTypes.Location = new System.Drawing.Point(271, 64);
            this.cbPortTypes.Name = "cbPortTypes";
            this.cbPortTypes.Size = new System.Drawing.Size(100, 21);
            this.cbPortTypes.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(198, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Port type:";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Id";
            this.Column1.FillWeight = 30F;
            this.Column1.HeaderText = "Id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Number";
            this.Column2.HeaderText = "Number";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Type";
            this.Column4.FillWeight = 60F;
            this.Column4.HeaderText = "Type";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "OpenedDisp";
            this.Column3.HeaderText = "Status";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // PortScannerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 556);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbPortTypes);
            this.Controls.Add(this.grdPorts);
            this.Controls.Add(this.nudStartPort);
            this.Controls.Add(this.nudEndPort);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudWorkers);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudTimeout);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PortScannerForm";
            this.Text = "Network scanner";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWorkers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPorts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.NumericUpDown nudTimeout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudWorkers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudEndPort;
        private System.Windows.Forms.NumericUpDown nudStartPort;
        private Controls.PortsGrid grdPorts;
        private System.Windows.Forms.ComboBox cbPortTypes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}

