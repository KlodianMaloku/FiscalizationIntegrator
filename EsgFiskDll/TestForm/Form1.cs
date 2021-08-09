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
                    MessageBox.Show(RegisterCashDeskCaller.registerCashDesk(26));

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
    }
}
