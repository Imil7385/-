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
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tp_moto_
{
    public partial class Main_Menu : Form
    {
        OleDbConnection conn;
        string connectionString = @"Provider = Microsoft.JET.OLEDB.4.0; Data Source = |DataDirectory|\\MotoDB.mdb";
        OleDbCommand MyCommand = new OleDbCommand();
        OleDbDataAdapter DataAdapter = new OleDbDataAdapter();
        DataTable DT = new DataTable();
        DataSet DS = new DataSet();
        public int id;
        public Main_Menu(int id_parsing)
        {
            id = id_parsing-1;
            conn = new OleDbConnection(connectionString);
            string text = "SELECT Users.User_id, Users.Worker_position, Users.name, Users.Sure_name, Users.Last_name FROM Users";
            MyCommand.Connection = conn;
            MyCommand.CommandText = text;
            DataAdapter.SelectCommand = MyCommand;
            conn.Open();
            DataAdapter.TableMappings.Add("TABLE", "Users");
            DataAdapter.Fill(DS);
            DT = DS.Tables[0];
            InitializeComponent();
            textBox1.Text = DT.Rows[id][1].ToString();
            textBox2.Text = DT.Rows[id][2].ToString();
            textBox3.Text = DT.Rows[id][3].ToString();
            textBox4.Text = DT.Rows[id][4].ToString();

        }

        private void Main_Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
