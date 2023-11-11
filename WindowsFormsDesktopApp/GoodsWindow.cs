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
    public partial class GoodsWindow : Form
    {
        NpgsqlConnection conn;
        public GoodsWindow(NpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            RefillDataGrid();
        }
        private void RefillDataGrid()
        {
            dataGridView1.Rows.Clear();

            NpgsqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select * from \"product\"";
            NpgsqlDataReader reader =  cmd.ExecuteReader();
            while (reader.Read())
            {
                string id = reader.GetInt32(0).ToString();
                string descrioption = reader.GetString(1);   
                string descrioption1 = reader.GetString(2);   
                string descrioption2 = reader.GetString(4);   
                string descrioption3 = reader.GetInt32(5).ToString();

                string x = descrioption + Environment.NewLine + descrioption1 + Environment.NewLine + descrioption2 + Environment.NewLine +  descrioption3;

                Bitmap bitmap = new Bitmap(reader.GetString(3));

                string Quantity = reader.GetInt32(6).ToString();

                dataGridView1.Rows.Add(new object[]
                {
                    id,
                    bitmap,
                    x,
                    Quantity
                });

            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
