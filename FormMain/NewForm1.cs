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
    public partial class NewForm1 : Form
    {
        OleDbConnection Cn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Data\Target\Sheila\SheilaData.mdb");
        OleDbDataAdapter Da;
        DataTable Dt = new DataTable();
        OleDbCommand Cmd;

        public NewForm1()
        {
            InitializeComponent();
            FillDatagridView();

        }
        void FillDatagridView()
        {
            Dt.Clear();
            Da = new OleDbDataAdapter("Select * From MyCo", Cn);
            Da.Fill(Dt);
            dataGridView2.DataSource = Dt;

        }
        
     

        private void button1_Click(object sender, EventArgs e)
        {
           
                Cmd = new OleDbCommand("Insert Into MyCo Values(" + Convert.ToInt32(txtMyCoID.Text) + ", '" + txtMyCoTitle.Text + "', '" + MyCoAdd1.Text + "', '" + MyCoAdd2.Text + "', '" + MyCoAdd3.Text + "', '" + MyCoCountry.Text + "', '" + MyCoPC.Text + "', '" + MyCoTel.Text + "', '" + MyCoFax.Text + "', '" + MyCoEmail.Text + "')", Cn);
                Cn.Open();
                Cmd.ExecuteNonQuery();
                Cn.Close();
                FillDatagridView();
                MessageBox.Show("Added Successfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
        }
     

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            txtMyCoID.Text = this.dataGridView2.CurrentRow.Cells[0].Value.ToString();
            txtMyCoTitle.Text = this.dataGridView2.CurrentRow.Cells[1].Value.ToString();
            MyCoAdd1.Text = this.dataGridView2.CurrentRow.Cells[2].Value.ToString();
            MyCoAdd2.Text = this.dataGridView2.CurrentRow.Cells[3].Value.ToString();
            MyCoAdd3.Text = this.dataGridView2.CurrentRow.Cells[4].Value.ToString();
            MyCoCountry.Text = this.dataGridView2.CurrentRow.Cells[5].Value.ToString();
            MyCoPC.Text = this.dataGridView2.CurrentRow.Cells[6].Value.ToString();
            MyCoTel.Text = this.dataGridView2.CurrentRow.Cells[7].Value.ToString();
            MyCoFax.Text = this.dataGridView2.CurrentRow.Cells[8].Value.ToString();
            MyCoEmail.Text = this.dataGridView2.CurrentRow.Cells[9].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
            Cmd = new OleDbCommand("Update MyCo Set MyCoTitle='" + txtMyCoTitle.Text + "', MyCoAdd1='" + MyCoAdd1.Text + "', MyCoAdd2='" + MyCoAdd2.Text + "', MyCoAdd3='" + MyCoAdd3.Text + "', MyCoCountry='" + MyCoCountry.Text + "', MyCoPC='" + MyCoPC.Text + "', MyCoTel='" + MyCoTel.Text + "', MyCoFax='" + MyCoFax.Text + "', MyCoEmail='" + MyCoEmail.Text + "' WHERE MyCoID=" + Convert.ToInt32(txtMyCoID.Text) + "", Cn);
            Cn.Open();
            Cmd.ExecuteNonQuery();
            Cn.Close();
            FillDatagridView();
            MessageBox.Show("Edited Successfully", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
            catch
            {
                MessageBox.Show("Please (DoubleClick) the company to Edit from list !", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                Cmd = new OleDbCommand("Delete From MyCo WHERE MyCoID= " + Convert.ToInt32(txtMyCoID.Text) + " ", Cn);
                Cn.Open();
                Cmd.ExecuteNonQuery();
                Cn.Close();
                FillDatagridView();
                MessageBox.Show("Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Please (DoubleClick) the company to delete from list !", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
           
        }
         
    }
}
