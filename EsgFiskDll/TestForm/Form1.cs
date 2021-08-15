using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmdTestSqlConn_Click(object sender, EventArgs e)
        {
            //var conn = new SqlConnection(this.txtSqlConnection.Text);
            using (SqlConnection conn = new SqlConnection(this.txtSqlConnection.Text))
            {
                conn.Open();
                try
                {
                    EsgFiskDll.EsgFisc RegisterCashDeskCaller = new EsgFiskDll.EsgFisc(conn,1);
                    MessageBox.Show(RegisterCashDeskCaller.registerCashDesk(2));

                }
                catch(SqlException ex)
                {
                    MessageBox.Show("Lidhja me db Deshtoi: " + ex.Message.ToString() , "Esg Fisk Module tester");
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(this.txtSqlConnection.Text))
            {
                conn.Open();
                try
                {
                    EsgFiskDll.EsgFisc RegisterCashDeskCaller = new EsgFiskDll.EsgFisc(conn, 1);
                    MessageBox.Show(RegisterCashDeskCaller.registerCashDeposit(1));

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lidhja me db Deshtoi: " + ex.Message.ToString(), "Esg Fisk Module tester");
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        private void cmdGenerateIICType_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(this.txtSqlConnection.Text))
            {
                conn.Open();
                try
                {
                    EsgFiskDll.EsgFisc generateIIC = new EsgFiskDll.EsgFisc(conn, 1);
                    MessageBox.Show(generateIIC.GenerateIICType(3346198));

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lidhja me db Deshtoi: " + ex.Message.ToString(), "Esg Fisk Module tester");
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        private void cmdCalculateIICQR_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(this.txtSqlConnection.Text))
            {
                conn.Open();
                try
                {
                    EsgFiskDll.EsgFisc generateIICQR = new EsgFiskDll.EsgFisc(conn, 1);
                    MessageBox.Show(generateIICQR.CalculateQRCode(3346198));

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lidhja me db Deshtoi: " + ex.Message.ToString(), "Esg Fisk Module tester");
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        private void cmdGetTaxPayer_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(this.txtSqlConnection.Text))
            {
                conn.Open();
                try
                {
                    EsgFiskDll.EsgFisc getTaxpayer = new EsgFiskDll.EsgFisc(conn, 1);
                    MessageBox.Show(getTaxpayer.getTaxPayer("K92014001J"));

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lidhja me db Deshtoi: " + ex.Message.ToString(), "Esg Fisk Module tester");
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        private void cmdRegisterInvoice_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(this.txtSqlConnection.Text))
            {
                conn.Open();
                try
                {
                    EsgFiskDll.EsgFisc doREgisterIvoice = new EsgFiskDll.EsgFisc(conn, 1);
                    MessageBox.Show(doREgisterIvoice.registerEInvoice(3346198));
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lidhja me db Deshtoi: " + ex.Message.ToString(), "Esg Fisk Module tester");
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
    }
}
