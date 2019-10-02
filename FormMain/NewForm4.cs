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
    public partial class NewForm4 : Form
    {
        OleDbConnection Cn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Data\Target\Sheila\SheilaData.mdb");
        OleDbDataAdapter Da;
        DataTable Dt = new DataTable();
        OleDbCommand Cmd;

        public NewForm4()
        {
            InitializeComponent();
            FillDatagridView();
        }
        void FillDatagridView()
        {
            Dt.Clear();
            Da = new OleDbDataAdapter("Select * From ExpTyp", Cn);
            Da.Fill(Dt);
            dataGridView3.DataSource = Dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cmd = new OleDbCommand("Insert Into ExpTyp Values(" + Convert.ToInt32(ExpTypID.Text) + ", '" + ExpTypNm.Text + "')", Cn);
                Cn.Open();
                Cmd.ExecuteNonQuery();
                Cn.Close();
                FillDatagridView();
                MessageBox.Show("Added Successfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView3_DoubleClick(object sender, EventArgs e)
        {
            ExpTypID.Text = this.dataGridView3.CurrentRow.Cells[0].Value.ToString();
            ExpTypNm.Text = this.dataGridView3.CurrentRow.Cells[1].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Cmd = new OleDbCommand("Update ExpTyp Set ExpTypNm='" + ExpTypNm.Text + "' WHERE ExpTypID=" + Convert.ToInt32(ExpTypID.Text) + "", Cn);
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

                Cmd = new OleDbCommand("Delete From ExpTyp WHERE ExpTypID= " + Convert.ToInt32(ExpTypID.Text) + " ", Cn);
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
    }
}
