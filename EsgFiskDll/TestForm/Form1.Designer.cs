
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
            this.cmdDergoEsl = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdRegisterCashDesk
            // 
            this.cmdRegisterCashDesk.Location = new System.Drawing.Point(27, 40);
            this.cmdRegisterCashDesk.Margin = new System.Windows.Forms.Padding(1);
            this.cmdRegisterCashDesk.Name = "cmdRegisterCashDesk";
            this.cmdRegisterCashDesk.Size = new System.Drawing.Size(140, 27);
            this.cmdRegisterCashDesk.TabIndex = 0;
            this.cmdRegisterCashDesk.Text = "Register CashDesk";
            this.cmdRegisterCashDesk.UseVisualStyleBackColor = true;
            this.cmdRegisterCashDesk.Click += new System.EventHandler(this.cmdTestSqlConn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sql Connection";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtSqlConnection
            // 
            this.txtSqlConnection.Location = new System.Drawing.Point(115, 3);
            this.txtSqlConnection.Margin = new System.Windows.Forms.Padding(1);
            this.txtSqlConnection.Name = "txtSqlConnection";
            this.txtSqlConnection.Size = new System.Drawing.Size(891, 23);
            this.txtSqlConnection.TabIndex = 2;
            this.txtSqlConnection.Text = "Server=localhost\\sql_2022; Database = quick_pos; User Id = sa; Password = atlanti" +
    "sgalaktika;";
            this.txtSqlConnection.TextChanged += new System.EventHandler(this.txtSqlConnection_TextChanged);
            // 
            // cmdRegisterCashDeposit
            // 
            this.cmdRegisterCashDeposit.Location = new System.Drawing.Point(27, 80);
            this.cmdRegisterCashDeposit.Margin = new System.Windows.Forms.Padding(1);
            this.cmdRegisterCashDeposit.Name = "cmdRegisterCashDeposit";
            this.cmdRegisterCashDeposit.Size = new System.Drawing.Size(139, 28);
            this.cmdRegisterCashDeposit.TabIndex = 3;
            this.cmdRegisterCashDeposit.Text = "Register CashDeposit";
            this.cmdRegisterCashDeposit.UseVisualStyleBackColor = true;
            this.cmdRegisterCashDeposit.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdGenerateIICType
            // 
            this.cmdGenerateIICType.Location = new System.Drawing.Point(27, 124);
            this.cmdGenerateIICType.Margin = new System.Windows.Forms.Padding(1);
            this.cmdGenerateIICType.Name = "cmdGenerateIICType";
            this.cmdGenerateIICType.Size = new System.Drawing.Size(139, 28);
            this.cmdGenerateIICType.TabIndex = 4;
            this.cmdGenerateIICType.Text = "Generate IICType";
            this.cmdGenerateIICType.UseVisualStyleBackColor = true;
            this.cmdGenerateIICType.Click += new System.EventHandler(this.cmdGenerateIICType_Click);
            // 
            // cmdCalculateIICQR
            // 
            this.cmdCalculateIICQR.Location = new System.Drawing.Point(27, 166);
            this.cmdCalculateIICQR.Margin = new System.Windows.Forms.Padding(1);
            this.cmdCalculateIICQR.Name = "cmdCalculateIICQR";
            this.cmdCalculateIICQR.Size = new System.Drawing.Size(139, 28);
            this.cmdCalculateIICQR.TabIndex = 5;
            this.cmdCalculateIICQR.Text = "Calculate IICQR";
            this.cmdCalculateIICQR.UseVisualStyleBackColor = true;
            this.cmdCalculateIICQR.Click += new System.EventHandler(this.cmdCalculateIICQR_Click);
            // 
            // cmdGetTaxPayer
            // 
            this.cmdGetTaxPayer.Location = new System.Drawing.Point(27, 206);
            this.cmdGetTaxPayer.Margin = new System.Windows.Forms.Padding(1);
            this.cmdGetTaxPayer.Name = "cmdGetTaxPayer";
            this.cmdGetTaxPayer.Size = new System.Drawing.Size(139, 28);
            this.cmdGetTaxPayer.TabIndex = 6;
            this.cmdGetTaxPayer.Text = "Get TaxPayer";
            this.cmdGetTaxPayer.UseVisualStyleBackColor = true;
            this.cmdGetTaxPayer.Click += new System.EventHandler(this.cmdGetTaxPayer_Click);
            // 
            // cmdRegisterInvoice
            // 
            this.cmdRegisterInvoice.Location = new System.Drawing.Point(379, 39);
            this.cmdRegisterInvoice.Margin = new System.Windows.Forms.Padding(1);
            this.cmdRegisterInvoice.Name = "cmdRegisterInvoice";
            this.cmdRegisterInvoice.Size = new System.Drawing.Size(139, 28);
            this.cmdRegisterInvoice.TabIndex = 7;
            this.cmdRegisterInvoice.Text = "Register Invoice";
            this.cmdRegisterInvoice.UseVisualStyleBackColor = true;
            this.cmdRegisterInvoice.Click += new System.EventHandler(this.cmdRegisterInvoice_Click);
            // 
            // cmdDergoEsl
            // 
            this.cmdDergoEsl.Location = new System.Drawing.Point(381, 78);
            this.cmdDergoEsl.Name = "cmdDergoEsl";
            this.cmdDergoEsl.Size = new System.Drawing.Size(136, 29);
            this.cmdDergoEsl.TabIndex = 8;
            this.cmdDergoEsl.Text = "Dergo Esl";
            this.cmdDergoEsl.UseVisualStyleBackColor = true;
            this.cmdDergoEsl.Click += new System.EventHandler(this.cmdDergoEsl_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(370, 197);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 282);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdDergoEsl);
            this.Controls.Add(this.cmdRegisterInvoice);
            this.Controls.Add(this.cmdGetTaxPayer);
            this.Controls.Add(this.cmdCalculateIICQR);
            this.Controls.Add(this.cmdGenerateIICType);
            this.Controls.Add(this.cmdRegisterCashDeposit);
            this.Controls.Add(this.txtSqlConnection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdRegisterCashDesk);
            this.Margin = new System.Windows.Forms.Padding(1);
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
        private System.Windows.Forms.Button cmdDergoEsl;
        private System.Windows.Forms.Button button1;
    }
}

