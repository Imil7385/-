using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace tp_moto_
{
    public partial class Autorisation : Form
    {
        public int id_parsing;
        OleDbConnection conn;
        string connectionString = @"Provider = Microsoft.JET.OLEDB.4.0; Data Source = |DataDirectory|\\MotoDB.mdb";
        OleDbCommand MyCommand = new OleDbCommand();
        OleDbDataAdapter DataAdapter = new OleDbDataAdapter();
        DataTable DT = new DataTable();
        DataSet DS = new DataSet();
        public Autorisation()
        {
            InitializeComponent();
            conn = new OleDbConnection(connectionString);
            string text = "SELECT Users.Login, Users.Password, Users.User_id FROM Users";
            MyCommand.Connection = conn;
            MyCommand.CommandText = text;
            DataAdapter.SelectCommand = MyCommand;
            conn.Open();
            DataAdapter.TableMappings.Add("TABLE", "Users");
            DataAdapter.Fill(DS);
            DT = DS.Tables[0];
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                comboBox1.Items.Add(DT.Rows[i][0].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool connect_key = false;
            for(int i = 0; i < DT.Rows.Count; i++)
            {
                if (comboBox1.Text==DT.Rows[i][0].ToString() && textBox1.Text == DT.Rows[i][1].ToString())
                {
                    id_parsing = Convert.ToInt32(DT.Rows[i][2]);
                    connect_key = true;
                    break;
                }
                else
                {
                    connect_key = false;
                }
            }
            if (connect_key == true)
            {
                
                Form Main_Menu = new Main_Menu(id_parsing);
                Main_Menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
            
        }

        private void Autorisation_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }
    }
}
