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
    public partial class NewForm7 : Form
    {
        OleDbConnection Cn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Data\Target\Sheila\SheilaData.mdb");
        OleDbDataAdapter Da;
        DataTable Dt = new DataTable();
        OleDbCommand Cmd;

        public NewForm7()
        {
            InitializeComponent();
            FillDatagridView();
        }
        void FillDatagridView()
        {
            Dt.Clear();
            Da = new OleDbDataAdapter("Select * From Acct", Cn);
            Da.Fill(Dt);
            dataGridView6.DataSource = Dt;
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void dataGridView6_DoubleClick(object sender, EventArgs e)
        {
            AcctID.Text = this.dataGridView6.CurrentRow.Cells[0].Value.ToString();
            AcctNm.Text = this.dataGridView6.CurrentRow.Cells[1].Value.ToString();
            AcctRef.Text = this.dataGridView6.CurrentRow.Cells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cmd = new OleDbCommand("Insert Into Acct Values(" + Convert.ToInt32(AcctID.Text) + ", '" + AcctNm.Text + "', '" + AcctRef.Text + "')", Cn);
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
                Cmd = new OleDbCommand("Update Acct Set AcctNm='" + AcctNm.Text + "', AcctRef='" + AcctRef.Text + "' WHERE AcctID=" + Convert.ToInt32(AcctID.Text) + "", Cn);
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

                Cmd = new OleDbCommand("Delete From Acct WHERE AcctID= " + Convert.ToInt32(AcctID.Text) + " ", Cn);
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
