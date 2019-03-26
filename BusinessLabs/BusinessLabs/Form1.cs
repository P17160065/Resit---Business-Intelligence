using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessLabs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonGetDates_Click(object sender, EventArgs e)
        {
            //create list
            List<string> Dates = new List<string>();
            //clear listbox to ensure old date is out
            listBoxDates.Items.Clear();
            //create database string
            string connectionString = Properties.Settings.Default.Data_set_1_1_ConnectionString;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                OleDbDataReader reader = null;
                OleDbCommand getDates = new OleDbCommand("SELECT [Order Date], [Ship Date] from Sheet1", connection);

                reader = getDates.ExecuteReader();
                while (reader.Read())
                {
                    Dates.Add(reader[0].ToString());
                    Dates.Add(reader[1].ToString());
                }
            }
            List<string> DatesFormatted = new List<string>();

            foreach (string date in Dates)
            {
                var dates = date.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                DatesFormatted.Add(dates[0]);
            }

            listBoxDates.DataSource = Dates;

        }
            private void Form1_Load(object sender, EventArgs e)
            {

            }
    }
}
