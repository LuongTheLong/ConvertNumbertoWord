namespace Client3
{
    partial class Client3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client3));
            this.txbNhap = new System.Windows.Forms.TextBox();
            this.txbKetqua = new System.Windows.Forms.TextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdbtnTP = new System.Windows.Forms.RadioButton();
            this.rdbtnTA = new System.Windows.Forms.RadioButton();
            this.rdbtnTV = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.IPv4txb = new System.Windows.Forms.TextBox();
            this.connectbtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txbNhap
            // 
            this.txbNhap.Enabled = false;
            this.txbNhap.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNhap.Location = new System.Drawing.Point(151, 127);
            this.txbNhap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txbNhap.Name = "txbNhap";
            this.txbNhap.Size = new System.Drawing.Size(477, 26);
            this.txbNhap.TabIndex = 0;
            this.txbNhap.TextChanged += new System.EventHandler(this.txbNhap_TextChanged);
            this.txbNhap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbNhap_KeyDown);
            this.txbNhap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbNhap_KeyPress);
            // 
            // txbKetqua
            // 
            this.txbKetqua.Enabled = false;
            this.txbKetqua.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbKetqua.Location = new System.Drawing.Point(151, 280);
            this.txbKetqua.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txbKetqua.Multiline = true;
            this.txbKetqua.Name = "txbKetqua";
            this.txbKetqua.ReadOnly = true;
            this.txbKetqua.Size = new System.Drawing.Size(477, 60);
            this.txbKetqua.TabIndex = 1;
            // 
            // btnConvert
            // 
            this.btnConvert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnConvert.Enabled = false;
            this.btnConvert.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnConvert.Location = new System.Drawing.Point(320, 203);
            this.btnConvert.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(106, 35);
            this.btnConvert.TabIndex = 2;
            this.btnConvert.Text = "Trao đổi";
            this.btnConvert.UseVisualStyleBackColor = false;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnReset.Enabled = false;
            this.btnReset.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnReset.Location = new System.Drawing.Point(476, 203);
            this.btnReset.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(107, 35);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Làm mới";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(104, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(525, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "PHẦN MỀM TRAO ĐỔI SỐ THÀNH CHỮ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(16, 129);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Số cần chuyển:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(16, 282);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Kết quả:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rdbtnTP);
            this.panel1.Controls.Add(this.rdbtnTA);
            this.panel1.Controls.Add(this.rdbtnTV);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(151, 170);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(110, 97);
            this.panel1.TabIndex = 7;
            // 
            // rdbtnTP
            // 
            this.rdbtnTP.AutoSize = true;
            this.rdbtnTP.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnTP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rdbtnTP.Location = new System.Drawing.Point(10, 74);
            this.rdbtnTP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdbtnTP.Name = "rdbtnTP";
            this.rdbtnTP.Size = new System.Drawing.Size(104, 20);
            this.rdbtnTP.TabIndex = 11;
            this.rdbtnTP.Text = "Tiếng Pháp";
            this.rdbtnTP.UseVisualStyleBackColor = true;
            // 
            // rdbtnTA
            // 
            this.rdbtnTA.AutoSize = true;
            this.rdbtnTA.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnTA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rdbtnTA.Location = new System.Drawing.Point(10, 41);
            this.rdbtnTA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdbtnTA.Name = "rdbtnTA";
            this.rdbtnTA.Size = new System.Drawing.Size(95, 20);
            this.rdbtnTA.TabIndex = 10;
            this.rdbtnTA.Text = "Tiếng Anh";
            this.rdbtnTA.UseVisualStyleBackColor = true;
            // 
            // rdbtnTV
            // 
            this.rdbtnTV.AutoSize = true;
            this.rdbtnTV.Checked = true;
            this.rdbtnTV.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnTV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rdbtnTV.Location = new System.Drawing.Point(10, 9);
            this.rdbtnTV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdbtnTV.Name = "rdbtnTV";
            this.rdbtnTV.Size = new System.Drawing.Size(96, 20);
            this.rdbtnTV.TabIndex = 9;
            this.rdbtnTV.TabStop = true;
            this.rdbtnTV.Text = "Tiếng việt";
            this.rdbtnTV.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(16, 196);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ngôn ngữ:";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnExit.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnExit.Location = new System.Drawing.Point(567, 355);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(107, 35);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(16, 79);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "IPv4Address:";
            // 
            // IPv4txb
            // 
            this.IPv4txb.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPv4txb.Location = new System.Drawing.Point(151, 76);
            this.IPv4txb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.IPv4txb.Name = "IPv4txb";
            this.IPv4txb.Size = new System.Drawing.Size(349, 26);
            this.IPv4txb.TabIndex = 11;
            this.IPv4txb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IPv4txb_KeyPress);
            // 
            // connectbtn
            // 
            this.connectbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.connectbtn.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.connectbtn.Location = new System.Drawing.Point(521, 72);
            this.connectbtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.connectbtn.Name = "connectbtn";
            this.connectbtn.Size = new System.Drawing.Size(106, 35);
            this.connectbtn.TabIndex = 12;
            this.connectbtn.Text = "Connect";
            this.connectbtn.UseVisualStyleBackColor = false;
            this.connectbtn.Click += new System.EventHandler(this.connectbtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(148, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Example: 192.168.0.1";
            // 
            // Client3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(683, 399);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.connectbtn);
            this.Controls.Add(this.IPv4txb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.txbKetqua);
            this.Controls.Add(this.txbNhap);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Client3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm trao đổi số thành chữ";
            this.Load += new System.EventHandler(this.Client3_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbNhap;
        private System.Windows.Forms.TextBox txbKetqua;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdbtnTA;
        private System.Windows.Forms.RadioButton rdbtnTV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.RadioButton rdbtnTP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox IPv4txb;
        private System.Windows.Forms.Button connectbtn;
        private System.Windows.Forms.Label label6;
    }
}

