using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Backlog
{
    public partial class MainUser : Form
    {
        public MainUser()
        {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OlEDB.4.0;Data Source=db_Backlog.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();





        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            lbIgre.Items.Clear();

            foreach (string str in listIgre)
            {
                if (str.StartsWith(txtPretraga.Text, StringComparison.CurrentCultureIgnoreCase))
                {
                    lbIgre.Items.Add(str);
                }
            }
        }

        List<string> listIgre=new List<string>(); 
        private void MainUser_Load(object sender, EventArgs e)
        {
            con.Open();
            OleDbDataReader reader = null;
            OleDbCommand comm = new OleDbCommand($"SELECT * FROM tb_Igra", con);
            reader = comm.ExecuteReader();
            lbIgre.Text = "";
            while (reader.Read())
            {
                lbIgre.Items.Add(reader.GetString(1));
                listIgre.Add(reader.GetString(1));
            }

            string naredba2 = $"SELECT * FROM tb_Zanr";
            cmd = new OleDbCommand(naredba2, con);
            OleDbDataReader odg = cmd.ExecuteReader();
            while(odg.Read())
            {
                cbZanr.Items.Add(odg.GetString(1));
            }
            con.Close();
        }

        private void lbIgre_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rtbOpis_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
