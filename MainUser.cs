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

            Pretraga pretraga = new Pretraga();
            pretraga.Trazi(lbIgre, listIgre, cbZanr, txtPretraga);
        }

        List<Igra> listIgre=new List<Igra>(); 
        private void MainUser_Load(object sender, EventArgs e)
        {
            con.Open();
            Pretraga kom = new Pretraga();
            listIgre = kom.LoadIgre(lbIgre);

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
            string gameName = lbIgre.SelectedItem.ToString();

            con.Open();
            string naredba = $"SELECT * from tb_Igra WHERE Naziv='{gameName}'";
            cmd = new OleDbCommand(naredba, con);
            OleDbDataReader odg = cmd.ExecuteReader();
            odg.Read();
            rtbOpis.Clear();

            rtbOpis.AppendText($"Naziv: {odg.GetString(1)}\n");
            rtbOpis.AppendText($"Platforma: {odg.GetString(2)}\n");
            rtbOpis.AppendText($"Godina: {odg.GetInt32(3)}\n");
            rtbOpis.AppendText($"Žanr: {cbZanr.Items[odg.GetInt32(4)-1]}\n");
            rtbOpis.AppendText($"Izdavač: {odg.GetString(5)}\n");
            rtbOpis.AppendText($"NA sales: {odg.GetInt32(6) * 1000}\n");
            rtbOpis.AppendText($"EU sales: {odg.GetInt32(7) * 1000}\n");
            rtbOpis.AppendText($"JP sales: {odg.GetInt32(8) * 1000}\n");
            rtbOpis.AppendText($"Other sales: {odg.GetInt32(9) * 1000}\n");
            rtbOpis.AppendText($"Global sales: {odg.GetInt32(10) * 1000}\n");

            con.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rtbOpis_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbZanr_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pretraga pretraga = new Pretraga();
            pretraga.Trazi(lbIgre, listIgre, cbZanr, txtPretraga);
        }
    }
}
