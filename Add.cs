using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Add : Form
    {
        string lista;
        string nazivIgre;
        Korisnik kor;
        List<ListBox> sveListe;
        public Add()
        {
            InitializeComponent();
        }

        public Add(string nazivIgre, ref Korisnik kor, List<ListBox> liste)
        {
            InitializeComponent();
            this.nazivIgre = nazivIgre;
            this.kor = kor;
            this.sveListe = liste;
        }

        private void Add_Load(object sender, EventArgs e)
        {
            //SVE KONTOLE SU U POČETKU NEAKTIVE
            txtUkupno.Enabled = false;
            cbPrioritet.Enabled = false;
            dtPocetak.Enabled = false;
            dtKraj.Enabled = false;
            btnPotvrdi.Enabled = false;
            lista = null;
        }

        private void cbLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ODREĐUJE KOJE ĆE KONTROLE BITI AKTIVNE OVISNO O ODABIRU LISTE U KOJU SE IGRA ŽELI DODATI
            lista = cbLista.SelectedItem.ToString();
            if (lista == "BACKLOG")
            {
                txtUkupno.Enabled = false;
                cbPrioritet.Enabled = true;
                dtPocetak.Enabled = false;
                dtKraj.Enabled = false;
                btnPotvrdi.Enabled = true;
            }
            else if(lista == "IGRAM")
            {
                txtUkupno.Enabled = false;
                cbPrioritet.Enabled = false;
                dtPocetak.Enabled = true;
                dtKraj.Enabled = false;
                btnPotvrdi.Enabled = true;
            }
            else if(lista == "IGRAO")
            {
                txtUkupno.Enabled = true;
                cbPrioritet.Enabled = false;
                dtPocetak.Enabled = true;
                dtKraj.Enabled = true;
                btnPotvrdi.Enabled = true;
            }
            else
            {
                lista = null;
                txtUkupno.Enabled = false;
                cbPrioritet.Enabled = false;
                dtPocetak.Enabled = false;
                dtKraj.Enabled = false;
                btnPotvrdi.Enabled = false;
            }
        }

        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            int l = cbLista.SelectedIndex + 1;
            int p = cbPrioritet.SelectedIndex + 1;
            if (lista == "BACKLOG")
            {
                if (cbPrioritet.SelectedIndex == -1)
                {
                    MessageBox.Show("Niste odabrali prioritet!");
                    return;
                }
                kor.DodajBacklog(l, p, nazivIgre, sveListe[0]);
                this.Close();
            }
            else if(lista == "IGRAM")
            {
                DateTime pocetak = dtPocetak.Value.Date;
                kor.DodajIgram(l, pocetak, nazivIgre, sveListe[1]);
                this.Close();
            }
            else if(lista == "IGRAO")
            {
                DateTime pocetak = dtPocetak.Value.Date;
                DateTime kraj = dtKraj.Value.Date;
                int ukupno;
                try
                {
                    ukupno = int.Parse(txtUkupno.Text);
                }
                catch 
                {
                    MessageBox.Show("Ukupno vrijeme igranja mora biti cijeli broj");
                    return;
                }
                if (ukupno <= 0)
                {
                    MessageBox.Show("Ukupno vrijeme mora biti veće od 0");
                    return;
                }
                TimeSpan razlika = kraj - pocetak;
                if (razlika.TotalHours + 24 < ukupno)
                {
                    MessageBox.Show("Ukupno vrijeme ne može biti veće od razlike kraja i početka igranja!");
                    return;
                }
                kor.DodajIgrao(l, pocetak, kraj, ukupno, nazivIgre, sveListe[2]);
                this.Close();
            }
        }
    }
}
