
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
            this.cmdTestSqlConn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSqlConnection = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmdTestSqlConn
            // 
            this.cmdTestSqlConn.Location = new System.Drawing.Point(49, 84);
            this.cmdTestSqlConn.Name = "cmdTestSqlConn";
            this.cmdTestSqlConn.Size = new System.Drawing.Size(260, 58);
            this.cmdTestSqlConn.TabIndex = 0;
            this.cmdTestSqlConn.Text = "Test Conn";
            this.cmdTestSqlConn.UseVisualStyleBackColor = true;
            this.cmdTestSqlConn.Click += new System.EventHandler(this.cmdTestSqlConn_Click);
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
            this.txtSqlConnection.Text = "Server=localhost; Database = QUICK_LAST; User Id = sa; Password = klodi;";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 602);
            this.Controls.Add(this.txtSqlConnection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdTestSqlConn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdTestSqlConn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSqlConnection;
    }
}

