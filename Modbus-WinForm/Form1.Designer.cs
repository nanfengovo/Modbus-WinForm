namespace Modbus_WinForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LabIP = new Label();
            TxtIP = new TextBox();
            TxtPort = new TextBox();
            LabPort = new Label();
            LabModbusTCP = new Label();
            Txtid = new TextBox();
            LabSlaveid = new Label();
            TxtFun = new TextBox();
            LabFun = new Label();
            TxtAdd = new TextBox();
            LabAdd = new Label();
            LabQuery = new Label();
            SelectQuery = new DomainUpDown();
            TxtResult = new TextBox();
            BtnRead = new Button();
            BtnClear = new Button();
            BtnConn = new Button();
            SuspendLayout();
            // 
            // LabIP
            // 
            LabIP.AutoSize = true;
            LabIP.Location = new Point(277, 171);
            LabIP.Name = "LabIP";
            LabIP.Size = new Size(42, 31);
            LabIP.TabIndex = 0;
            LabIP.Text = "IP:";
            // 
            // TxtIP
            // 
            TxtIP.Location = new Point(445, 164);
            TxtIP.Name = "TxtIP";
            TxtIP.Size = new Size(200, 38);
            TxtIP.TabIndex = 1;
            // 
            // TxtPort
            // 
            TxtPort.Location = new Point(1207, 164);
            TxtPort.Name = "TxtPort";
            TxtPort.Size = new Size(200, 38);
            TxtPort.TabIndex = 3;
            // 
            // LabPort
            // 
            LabPort.AutoSize = true;
            LabPort.Location = new Point(1039, 171);
            LabPort.Name = "LabPort";
            LabPort.Size = new Size(68, 31);
            LabPort.TabIndex = 2;
            LabPort.Text = "Port:";
            // 
            // LabModbusTCP
            // 
            LabModbusTCP.AutoSize = true;
            LabModbusTCP.Font = new Font("Microsoft YaHei UI", 22.125F, FontStyle.Regular, GraphicsUnit.Point, 134);
            LabModbusTCP.Location = new Point(695, 48);
            LabModbusTCP.Name = "LabModbusTCP";
            LabModbusTCP.Size = new Size(403, 78);
            LabModbusTCP.TabIndex = 4;
            LabModbusTCP.Text = "Modbus-TCP";
            // 
            // Txtid
            // 
            Txtid.Location = new Point(445, 305);
            Txtid.Name = "Txtid";
            Txtid.Size = new Size(200, 38);
            Txtid.TabIndex = 6;
            // 
            // LabSlaveid
            // 
            LabSlaveid.AutoSize = true;
            LabSlaveid.Location = new Point(277, 312);
            LabSlaveid.Name = "LabSlaveid";
            LabSlaveid.Size = new Size(108, 31);
            LabSlaveid.TabIndex = 5;
            LabSlaveid.Text = "Slave id:";
            // 
            // TxtFun
            // 
            TxtFun.Location = new Point(1207, 287);
            TxtFun.Name = "TxtFun";
            TxtFun.Size = new Size(200, 38);
            TxtFun.TabIndex = 8;
            // 
            // LabFun
            // 
            LabFun.AutoSize = true;
            LabFun.Location = new Point(1039, 294);
            LabFun.Name = "LabFun";
            LabFun.Size = new Size(120, 31);
            LabFun.TabIndex = 7;
            LabFun.Text = "Function:";
            // 
            // TxtAdd
            // 
            TxtAdd.Location = new Point(501, 435);
            TxtAdd.Name = "TxtAdd";
            TxtAdd.Size = new Size(200, 38);
            TxtAdd.TabIndex = 10;
            // 
            // LabAdd
            // 
            LabAdd.AutoSize = true;
            LabAdd.Location = new Point(277, 442);
            LabAdd.Name = "LabAdd";
            LabAdd.Size = new Size(195, 31);
            LabAdd.TabIndex = 9;
            LabAdd.Text = "Address(Base0):";
            // 
            // LabQuery
            // 
            LabQuery.AutoSize = true;
            LabQuery.Location = new Point(1039, 460);
            LabQuery.Name = "LabQuery";
            LabQuery.Size = new Size(91, 31);
            LabQuery.TabIndex = 11;
            LabQuery.Text = "Query:";
            // 
            // SelectQuery
            // 
            SelectQuery.BackColor = Color.White;
            SelectQuery.Items.Add("1");
            SelectQuery.Items.Add("10");
            SelectQuery.Items.Add("2");
            SelectQuery.Items.Add("3");
            SelectQuery.Items.Add("32");
            SelectQuery.Items.Add("4");
            SelectQuery.Items.Add("5");
            SelectQuery.Items.Add("6");
            SelectQuery.Items.Add("7");
            SelectQuery.Items.Add("8");
            SelectQuery.Items.Add("9");
            SelectQuery.Location = new Point(1207, 460);
            SelectQuery.Name = "SelectQuery";
            SelectQuery.Size = new Size(240, 38);
            SelectQuery.TabIndex = 12;
            SelectQuery.Wrap = true;
            // 
            // TxtResult
            // 
            TxtResult.AcceptsTab = true;
            TxtResult.BackColor = SystemColors.ControlLightLight;
            TxtResult.Location = new Point(277, 537);
            TxtResult.Multiline = true;
            TxtResult.Name = "TxtResult";
            TxtResult.ReadOnly = true;
            TxtResult.ScrollBars = ScrollBars.Vertical;
            TxtResult.Size = new Size(1170, 706);
            TxtResult.TabIndex = 13;
            // 
            // BtnRead
            // 
            BtnRead.Location = new Point(1498, 884);
            BtnRead.Name = "BtnRead";
            BtnRead.Size = new Size(225, 55);
            BtnRead.TabIndex = 14;
            BtnRead.Text = "读取";
            BtnRead.UseVisualStyleBackColor = true;
            BtnRead.Click += BtnRead_Click;
            // 
            // BtnClear
            // 
            BtnClear.Location = new Point(1498, 1042);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(218, 52);
            BtnClear.TabIndex = 15;
            BtnClear.Text = "清空结果";
            BtnClear.UseVisualStyleBackColor = true;
            BtnClear.Click += BtnClear_Click;
            // 
            // BtnConn
            // 
            BtnConn.Location = new Point(1498, 694);
            BtnConn.Name = "BtnConn";
            BtnConn.Size = new Size(225, 55);
            BtnConn.TabIndex = 16;
            BtnConn.Text = "测试连接";
            BtnConn.UseVisualStyleBackColor = true;
            BtnConn.Click += BtnConn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1808, 1267);
            Controls.Add(BtnConn);
            Controls.Add(BtnClear);
            Controls.Add(BtnRead);
            Controls.Add(TxtResult);
            Controls.Add(SelectQuery);
            Controls.Add(LabQuery);
            Controls.Add(TxtAdd);
            Controls.Add(LabAdd);
            Controls.Add(TxtFun);
            Controls.Add(LabFun);
            Controls.Add(Txtid);
            Controls.Add(LabSlaveid);
            Controls.Add(LabModbusTCP);
            Controls.Add(TxtPort);
            Controls.Add(LabPort);
            Controls.Add(TxtIP);
            Controls.Add(LabIP);
            Name = "Form1";
            Text = "Modbus连接";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabIP;
        private TextBox TxtIP;
        private TextBox TxtPort;
        private Label LabPort;
        private Label LabModbusTCP;
        private TextBox Txtid;
        private Label LabSlaveid;
        private TextBox TxtFun;
        private Label LabFun;
        private TextBox TxtAdd;
        private Label LabAdd;
        private Label LabQuery;
        private DomainUpDown SelectQuery;
        private TextBox TxtResult;
        private Button BtnRead;
        private Button BtnClear;
        private Button BtnConn;
    }
}
