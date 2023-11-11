using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;

namespace WindowsFormsDesktopApp
{
    public partial class MainWindow : Form
    {
        private static string connectionString = "Server = 10.14.206.27; Port = 5432; User Id = LAA; Password = 1234; database = k24a_463";
        private  NpgsqlConnection connection = new NpgsqlConnection(connectionString);
      

public MainWindow()
        {
            InitializeComponent();
          try
            {
                connection.Open();
             }
          catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                справочникиToolStripMenuItem.Enabled  = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void товарыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoodsWindow gw = new GoodsWindow(connection);
            gw.ShowDialog();
        }
    }
}
