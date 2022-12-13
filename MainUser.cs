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

        Pretraga pretraga = new Pretraga();

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            lbIgre.Items.Clear();
            pretraga.Trazi(lbIgre, listIgre, cbZanr, txtPretraga);
        }

        List<Igra> listIgre=new List<Igra>(); 
        private void MainUser_Load(object sender, EventArgs e)
        {
            listIgre = pretraga.LoadIgre(lbIgre);
            pretraga.UcitajZanrove(cbZanr);
            CueProvider.SetCue(txtPretraga, "Pretraži listu igara");    
        }

        private void lbIgre_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gameName = lbIgre.SelectedItem.ToString();
            pretraga.UcitajOpis(rtbOpis, cbZanr, gameName);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rtbOpis_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbZanr_SelectedIndexChanged(object sender, EventArgs e)
        {
            pretraga.Trazi(lbIgre, listIgre, cbZanr, txtPretraga);
        }
    }
}
