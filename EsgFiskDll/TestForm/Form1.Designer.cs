
namespace TestForm
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
            this.cmdRegisterCashDesk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSqlConnection = new System.Windows.Forms.TextBox();
            this.cmdRegisterCashDeposit = new System.Windows.Forms.Button();
            this.cmdGenerateIICType = new System.Windows.Forms.Button();
            this.cmdCalculateIICQR = new System.Windows.Forms.Button();
            this.cmdGetTaxPayer = new System.Windows.Forms.Button();
            this.cmdRegisterInvoice = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdRegisterCashDesk
            // 
            this.cmdRegisterCashDesk.Location = new System.Drawing.Point(49, 84);
            this.cmdRegisterCashDesk.Name = "cmdRegisterCashDesk";
            this.cmdRegisterCashDesk.Size = new System.Drawing.Size(260, 58);
            this.cmdRegisterCashDesk.TabIndex = 0;
            this.cmdRegisterCashDesk.Text = "Register CashDesk";
            this.cmdRegisterCashDesk.UseVisualStyleBackColor = true;
            this.cmdRegisterCashDesk.Click += new System.EventHandler(this.cmdTestSqlConn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sql Connection";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtSqlConnection
            // 
            this.txtSqlConnection.Location = new System.Drawing.Point(213, 6);
            this.txtSqlConnection.Name = "txtSqlConnection";
            this.txtSqlConnection.Size = new System.Drawing.Size(766, 39);
            this.txtSqlConnection.TabIndex = 2;
            this.txtSqlConnection.Text = "Server=localhost; Database = MEGATEK; User Id = sa; Password = klodi;";
            // 
            // cmdRegisterCashDeposit
            // 
            this.cmdRegisterCashDeposit.Location = new System.Drawing.Point(49, 172);
            this.cmdRegisterCashDeposit.Name = "cmdRegisterCashDeposit";
            this.cmdRegisterCashDeposit.Size = new System.Drawing.Size(259, 60);
            this.cmdRegisterCashDeposit.TabIndex = 3;
            this.cmdRegisterCashDeposit.Text = "Register CashDeposit";
            this.cmdRegisterCashDeposit.UseVisualStyleBackColor = true;
            this.cmdRegisterCashDeposit.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdGenerateIICType
            // 
            this.cmdGenerateIICType.Location = new System.Drawing.Point(49, 265);
            this.cmdGenerateIICType.Name = "cmdGenerateIICType";
            this.cmdGenerateIICType.Size = new System.Drawing.Size(259, 60);
            this.cmdGenerateIICType.TabIndex = 4;
            this.cmdGenerateIICType.Text = "Generate IICType";
            this.cmdGenerateIICType.UseVisualStyleBackColor = true;
            this.cmdGenerateIICType.Click += new System.EventHandler(this.cmdGenerateIICType_Click);
            // 
            // cmdCalculateIICQR
            // 
            this.cmdCalculateIICQR.Location = new System.Drawing.Point(50, 353);
            this.cmdCalculateIICQR.Name = "cmdCalculateIICQR";
            this.cmdCalculateIICQR.Size = new System.Drawing.Size(259, 60);
            this.cmdCalculateIICQR.TabIndex = 5;
            this.cmdCalculateIICQR.Text = "Calculate IICQR";
            this.cmdCalculateIICQR.UseVisualStyleBackColor = true;
            this.cmdCalculateIICQR.Click += new System.EventHandler(this.cmdCalculateIICQR_Click);
            // 
            // cmdGetTaxPayer
            // 
            this.cmdGetTaxPayer.Location = new System.Drawing.Point(49, 440);
            this.cmdGetTaxPayer.Name = "cmdGetTaxPayer";
            this.cmdGetTaxPayer.Size = new System.Drawing.Size(259, 60);
            this.cmdGetTaxPayer.TabIndex = 6;
            this.cmdGetTaxPayer.Text = "Get TaxPayer";
            this.cmdGetTaxPayer.UseVisualStyleBackColor = true;
            this.cmdGetTaxPayer.Click += new System.EventHandler(this.cmdGetTaxPayer_Click);
            // 
            // cmdRegisterInvoice
            // 
            this.cmdRegisterInvoice.Location = new System.Drawing.Point(705, 83);
            this.cmdRegisterInvoice.Name = "cmdRegisterInvoice";
            this.cmdRegisterInvoice.Size = new System.Drawing.Size(259, 60);
            this.cmdRegisterInvoice.TabIndex = 7;
            this.cmdRegisterInvoice.Text = "Register Invoice";
            this.cmdRegisterInvoice.UseVisualStyleBackColor = true;
            this.cmdRegisterInvoice.Click += new System.EventHandler(this.cmdRegisterInvoice_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 602);
            this.Controls.Add(this.cmdRegisterInvoice);
            this.Controls.Add(this.cmdGetTaxPayer);
            this.Controls.Add(this.cmdCalculateIICQR);
            this.Controls.Add(this.cmdGenerateIICType);
            this.Controls.Add(this.cmdRegisterCashDeposit);
            this.Controls.Add(this.txtSqlConnection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdRegisterCashDesk);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdRegisterCashDesk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSqlConnection;
        private System.Windows.Forms.Button cmdRegisterCashDeposit;
        private System.Windows.Forms.Button cmdGenerateIICType;
        private System.Windows.Forms.Button cmdCalculateIICQR;
        private System.Windows.Forms.Button cmdGetTaxPayer;
        private System.Windows.Forms.Button cmdRegisterInvoice;
    }
}

