namespace HotelManagement
{
    partial class frmAdmin
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
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tcAccount = new System.Windows.Forms.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgBill = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnViewBill = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dtgServices = new System.Windows.Forms.DataGridView();
            this.btnAddServices = new System.Windows.Forms.Button();
            this.btnDeleteServices = new System.Windows.Forms.Button();
            this.btnEditServices = new System.Windows.Forms.Button();
            this.btnViewServices = new System.Windows.Forms.Button();
            this.btnSearchServices = new System.Windows.Forms.Button();
            this.txtServicesSearchName = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtServicesID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.txtServicesName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.cbServiceCategories = new System.Windows.Forms.ComboBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.numServicePrice = new System.Windows.Forms.NumericUpDown();
            this.tabPage2.SuspendLayout();
            this.tcAccount.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBill)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgServices)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numServicePrice)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(780, 410);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Phòng";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(780, 410);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Danh mục";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel7);
            this.tabPage2.Controls.Add(this.panel6);
            this.tabPage2.Controls.Add(this.panel5);
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(780, 410);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Dịch vụ";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // tcAccount
            // 
            this.tcAccount.Controls.Add(this.tabPage1);
            this.tcAccount.Controls.Add(this.tabPage2);
            this.tcAccount.Controls.Add(this.tabPage3);
            this.tcAccount.Controls.Add(this.tabPage4);
            this.tcAccount.Controls.Add(this.tabPage5);
            this.tcAccount.Location = new System.Drawing.Point(0, 0);
            this.tcAccount.Name = "tcAccount";
            this.tcAccount.SelectedIndex = 0;
            this.tcAccount.Size = new System.Drawing.Size(788, 438);
            this.tcAccount.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtgBill);
            this.panel1.Location = new System.Drawing.Point(6, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(768, 347);
            this.panel1.TabIndex = 0;
            // 
            // dtgBill
            // 
            this.dtgBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBill.Location = new System.Drawing.Point(3, 3);
            this.dtgBill.Name = "dtgBill";
            this.dtgBill.RowTemplate.Height = 25;
            this.dtgBill.Size = new System.Drawing.Size(762, 341);
            this.dtgBill.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnViewBill);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dtToDate);
            this.panel2.Controls.Add(this.dtFromDate);
            this.panel2.Location = new System.Drawing.Point(74, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(601, 29);
            this.panel2.TabIndex = 1;
            // 
            // dtFromDate
            // 
            this.dtFromDate.Location = new System.Drawing.Point(50, 4);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(200, 23);
            this.dtFromDate.TabIndex = 1;
            // 
            // dtToDate
            // 
            this.dtToDate.Location = new System.Drawing.Point(284, 3);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(200, 23);
            this.dtToDate.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "From";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(256, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "to";
            // 
            // btnViewBill
            // 
            this.btnViewBill.Location = new System.Drawing.Point(511, 3);
            this.btnViewBill.Name = "btnViewBill";
            this.btnViewBill.Size = new System.Drawing.Size(75, 23);
            this.btnViewBill.TabIndex = 5;
            this.btnViewBill.Text = "Thống kê";
            this.btnViewBill.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.panel2);
            this.tabPage5.Controls.Add(this.panel1);
            this.tabPage5.Location = new System.Drawing.Point(4, 24);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(780, 410);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Tài khoản";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(780, 410);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Doanh thu";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.dateTimePicker1);
            this.panel3.Controls.Add(this.dateTimePicker2);
            this.panel3.Location = new System.Drawing.Point(84, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(601, 29);
            this.panel3.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(511, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Thống kê";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(256, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "to";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(3, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "From";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(284, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(50, 4);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 63);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(768, 341);
            this.dataGridView1.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnViewServices);
            this.panel4.Controls.Add(this.btnEditServices);
            this.panel4.Controls.Add(this.btnDeleteServices);
            this.panel4.Controls.Add(this.btnAddServices);
            this.panel4.Location = new System.Drawing.Point(8, 8);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(369, 52);
            this.panel4.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dtgServices);
            this.panel5.Location = new System.Drawing.Point(8, 66);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(438, 338);
            this.panel5.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtServicesSearchName);
            this.panel6.Controls.Add(this.btnSearchServices);
            this.panel6.Location = new System.Drawing.Point(383, 8);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(391, 52);
            this.panel6.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel11);
            this.panel7.Controls.Add(this.panel10);
            this.panel7.Controls.Add(this.panel9);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Location = new System.Drawing.Point(449, 66);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(325, 338);
            this.panel7.TabIndex = 2;
            // 
            // dtgServices
            // 
            this.dtgServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgServices.Location = new System.Drawing.Point(3, 3);
            this.dtgServices.Name = "dtgServices";
            this.dtgServices.RowTemplate.Height = 25;
            this.dtgServices.Size = new System.Drawing.Size(432, 332);
            this.dtgServices.TabIndex = 3;
            this.dtgServices.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgServices_CellContentClick);
            // 
            // btnAddServices
            // 
            this.btnAddServices.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btnAddServices.Location = new System.Drawing.Point(3, 3);
            this.btnAddServices.Name = "btnAddServices";
            this.btnAddServices.Size = new System.Drawing.Size(78, 46);
            this.btnAddServices.TabIndex = 4;
            this.btnAddServices.Text = "Thêm";
            this.btnAddServices.UseVisualStyleBackColor = true;
            // 
            // btnDeleteServices
            // 
            this.btnDeleteServices.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btnDeleteServices.Location = new System.Drawing.Point(171, 3);
            this.btnDeleteServices.Name = "btnDeleteServices";
            this.btnDeleteServices.Size = new System.Drawing.Size(78, 46);
            this.btnDeleteServices.TabIndex = 5;
            this.btnDeleteServices.Text = "Xóa";
            this.btnDeleteServices.UseVisualStyleBackColor = true;
            // 
            // btnEditServices
            // 
            this.btnEditServices.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btnEditServices.Location = new System.Drawing.Point(87, 3);
            this.btnEditServices.Name = "btnEditServices";
            this.btnEditServices.Size = new System.Drawing.Size(78, 46);
            this.btnEditServices.TabIndex = 6;
            this.btnEditServices.Text = "Sửa";
            this.btnEditServices.UseVisualStyleBackColor = true;
            // 
            // btnViewServices
            // 
            this.btnViewServices.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btnViewServices.Location = new System.Drawing.Point(255, 3);
            this.btnViewServices.Name = "btnViewServices";
            this.btnViewServices.Size = new System.Drawing.Size(78, 46);
            this.btnViewServices.TabIndex = 7;
            this.btnViewServices.Text = "Xem";
            this.btnViewServices.UseVisualStyleBackColor = true;
            // 
            // btnSearchServices
            // 
            this.btnSearchServices.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btnSearchServices.Location = new System.Drawing.Point(310, 3);
            this.btnSearchServices.Name = "btnSearchServices";
            this.btnSearchServices.Size = new System.Drawing.Size(78, 46);
            this.btnSearchServices.TabIndex = 8;
            this.btnSearchServices.Text = "Tìm";
            this.btnSearchServices.UseVisualStyleBackColor = true;
            // 
            // txtServicesSearchName
            // 
            this.txtServicesSearchName.Location = new System.Drawing.Point(3, 16);
            this.txtServicesSearchName.Name = "txtServicesSearchName";
            this.txtServicesSearchName.Size = new System.Drawing.Size(301, 23);
            this.txtServicesSearchName.TabIndex = 9;
            this.txtServicesSearchName.TextChanged += new System.EventHandler(this.txtServicesName_TextChanged);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.txtServicesID);
            this.panel8.Controls.Add(this.label5);
            this.panel8.Location = new System.Drawing.Point(3, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(319, 50);
            this.panel8.TabIndex = 6;
            // 
            // txtServicesID
            // 
            this.txtServicesID.Location = new System.Drawing.Point(39, 14);
            this.txtServicesID.Name = "txtServicesID";
            this.txtServicesID.ReadOnly = true;
            this.txtServicesID.Size = new System.Drawing.Size(277, 23);
            this.txtServicesID.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(3, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "ID:";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.txtServicesName);
            this.panel9.Controls.Add(this.label6);
            this.panel9.Location = new System.Drawing.Point(3, 59);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(319, 50);
            this.panel9.TabIndex = 7;
            // 
            // txtServicesName
            // 
            this.txtServicesName.Location = new System.Drawing.Point(39, 14);
            this.txtServicesName.Name = "txtServicesName";
            this.txtServicesName.Size = new System.Drawing.Size(277, 23);
            this.txtServicesName.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(3, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tên:";
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.cbServiceCategories);
            this.panel10.Controls.Add(this.label7);
            this.panel10.Location = new System.Drawing.Point(3, 115);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(319, 50);
            this.panel10.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(3, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 21);
            this.label7.TabIndex = 0;
            this.label7.Text = "Danh mục:";
            // 
            // cbServiceCategories
            // 
            this.cbServiceCategories.FormattingEnabled = true;
            this.cbServiceCategories.Location = new System.Drawing.Point(95, 16);
            this.cbServiceCategories.Name = "cbServiceCategories";
            this.cbServiceCategories.Size = new System.Drawing.Size(221, 23);
            this.cbServiceCategories.TabIndex = 1;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.numServicePrice);
            this.panel11.Controls.Add(this.label8);
            this.panel11.Location = new System.Drawing.Point(3, 171);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(319, 50);
            this.panel11.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(3, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 21);
            this.label8.TabIndex = 0;
            this.label8.Text = "Giá:";
            // 
            // numServicePrice
            // 
            this.numServicePrice.Location = new System.Drawing.Point(95, 17);
            this.numServicePrice.Name = "numServicePrice";
            this.numServicePrice.Size = new System.Drawing.Size(120, 23);
            this.numServicePrice.TabIndex = 1;
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tcAccount);
            this.Name = "frmAdmin";
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.frmAdmin_Load);
            this.tabPage2.ResumeLayout(false);
            this.tcAccount.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgBill)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgServices)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numServicePrice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tcAccount;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnViewBill;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dtgBill;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dtgServices;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnViewServices;
        private System.Windows.Forms.Button btnEditServices;
        private System.Windows.Forms.Button btnDeleteServices;
        private System.Windows.Forms.Button btnAddServices;
        private System.Windows.Forms.Button btnSearchServices;
        private System.Windows.Forms.TextBox txtServicesSearchName;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox txtServicesID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.TextBox txtServicesName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.NumericUpDown numServicePrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.ComboBox cbServiceCategories;
        private System.Windows.Forms.Label label7;
    }
}