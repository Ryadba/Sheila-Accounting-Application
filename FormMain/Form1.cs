using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace FormMain
{
    public partial class FormMain : Form
    {
        OleDbConnection Cn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Data\Target\Sheila\SheilaData.mdb");
        OleDbDataAdapter Da;
        DataTable Dt = new DataTable();
        
        public FormMain()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Dt.Rows.Clear();
            Dt.Columns.Clear();
            Da = new OleDbDataAdapter("Select * From MyCo", Cn);
            Da.Fill(Dt);
            dataGridView1.DataSource = Dt;

        }

        private void button5_Click(object sender, EventArgs e)
        {

            Dt.Rows.Clear();
            Dt.Columns.Clear();
            Da = new OleDbDataAdapter("Select * From ExpTyp", Cn);
            Da.Fill(Dt);
            dataGridView1.DataSource = Dt;
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Dt.Rows.Clear();
            Dt.Columns.Clear();
            Da = new OleDbDataAdapter("Select * From Cli", Cn);
            Da.Fill(Dt);
            dataGridView1.DataSource = Dt;
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Dt.Rows.Clear();
            Dt.Columns.Clear();
            Da = new OleDbDataAdapter("Select * From Ben", Cn);
            Da.Fill(Dt);
            dataGridView1.DataSource = Dt;
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Dt.Rows.Clear();
            Dt.Columns.Clear();
            Da = new OleDbDataAdapter("Select * From Acct", Cn);
            Da.Fill(Dt);
            dataGridView1.DataSource = Dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            NewForm1 f1 = new NewForm1();
            f1.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            NewForm2 f1 = new NewForm2();
            f1.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            NewForm3 f1 = new NewForm3();
            f1.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            NewForm4 f1 = new NewForm4();
            f1.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            NewForm5 f1 = new NewForm5();
            f1.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            NewForm6 f1 = new NewForm6();
            f1.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            NewForm7 f1 = new NewForm7();
            f1.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The reports are to be decided when we agree on how the data is structured.", "1-TBA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The reports are to be decided when we agree on how the data is structured.", "2-TBA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The reports are to be decided when we agree on how the data is structured.", "3-TBA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void Relink_Click(object sender, EventArgs e)
        {
            RelinkForm Re = new RelinkForm();
            Re.Show();
 
        }
       
    }
}
