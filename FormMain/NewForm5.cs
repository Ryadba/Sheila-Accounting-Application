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
    public partial class NewForm5 : Form
    {
        OleDbConnection Cn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Data\Target\Sheila\SheilaData.mdb");
        OleDbDataAdapter Da;
        DataTable Dt = new DataTable();
        OleDbCommand Cmd;

        public NewForm5()
        {
            InitializeComponent();
            FillDatagridView();
        }
        void FillDatagridView()
        {
            Dt.Clear();
            Da = new OleDbDataAdapter("Select * From Cli", Cn);
            Da.Fill(Dt);
            dataGridView4.DataSource = Dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Cmd = new OleDbCommand("Insert Into Cli Values(" + Convert.ToInt32(CliID.Text) + ", '" + CliNm.Text + "')", Cn);
            Cn.Open();
            Cmd.ExecuteNonQuery();
            Cn.Close();
            FillDatagridView();
            MessageBox.Show("Added Successfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Cmd = new OleDbCommand("Update Cli Set CliNm='" + CliNm.Text + "' WHERE CliID=" + Convert.ToInt32(CliID.Text) + "", Cn);
                Cn.Open();
                Cmd.ExecuteNonQuery();
                Cn.Close();
                FillDatagridView();
                MessageBox.Show("Edited Successfully", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Please (DoubleClick) the row to Edit from list !", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                Cmd = new OleDbCommand("Delete From Cli WHERE CliID= " + Convert.ToInt32(CliID.Text) + " ", Cn);
                Cn.Open();
                Cmd.ExecuteNonQuery();
                Cn.Close();
                FillDatagridView();
                MessageBox.Show("Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Please (DoubleClick) the row to delete from list !", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dataGridView4_DoubleClick(object sender, EventArgs e)
        {
            CliID.Text = this.dataGridView4.CurrentRow.Cells[0].Value.ToString();
            CliNm.Text = this.dataGridView4.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
