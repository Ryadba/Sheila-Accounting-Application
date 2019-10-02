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

namespace FormMain
{
    public partial class RelinkForm : Form
    {
        OleDbConnection Cn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Data\Target\Sheila\SheilaData.mdb");
        
        
        

        public RelinkForm()
        {
            InitializeComponent();
            textBox99.Text = Cn.DataSource;
        }
       

        private void button_Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Open MDB/ACCDB File";
            fDialog.Filter = "MDB Files|*.mdb|ACCDB Files|*.accdb";
            fDialog.InitialDirectory = @"C:\";
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
               
                textBox99.Text = fDialog.FileName;
                
            }
            fDialog.AddExtension = true;
            fDialog.CheckFileExists = true;
            fDialog.CheckPathExists = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                

        }
        

    }
}
