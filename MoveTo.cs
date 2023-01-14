using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Backlog
{
    public partial class MoveTo : Form
    {
        public string fromTo { get; private set; }
        public string nazivIgre { get; private set; }
        public Korisnik korisnik { get; private set; }
        public List<ListBox> sveListe { get; private set; }
        public MoveTo()
        {
            InitializeComponent();
        }
        public MoveTo(string fromTo, string nazivIgre, ref Korisnik kor, List<ListBox> liste)
        {
            InitializeComponent();
            this.fromTo = fromTo;
            this.nazivIgre = nazivIgre;
            this.korisnik = kor;
            this.sveListe = liste;
        }

        private void Move_Load(object sender, EventArgs e)
        {
            if (fromTo == "backlogIgram")
            {
                dtPocetak.Enabled = true;
                dtKraj.Enabled = false;
                txtUkupno.Enabled = false;
            }
            else if (fromTo == "igramIgrao")
            {
                dtPocetak.Enabled = false;
                dtKraj.Enabled = true;
                txtUkupno.Enabled = true;
            }
            else if (fromTo == "igraoIgram")
            {
                dtPocetak.Enabled = true;
                dtKraj.Enabled = false;
                txtUkupno.Enabled = false;
            }
            else
            {
                dtPocetak.Enabled = false;
                dtKraj.Enabled = false;
                txtUkupno.Enabled = false;
                btnPotvrdi.Enabled = false;
            }
        }

        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            if (fromTo == "backlogIgram")
            {
                DateTime pocetak = dtPocetak.Value;
                korisnik.backlogIgram(pocetak, nazivIgre, sveListe[0], sveListe[1]);
                this.Close();
            }
            else if (fromTo == "igramIgrao")
            {
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
                DateTime kraj = dtKraj.Value;
                korisnik.igramIgrao(kraj, ukupno, nazivIgre, sveListe[1], sveListe[2]);
                this.Close();
            }
            else if (fromTo == "igraoIgram")
            {
                DateTime pocetak = dtPocetak.Value;
                korisnik.igraoIgram(pocetak, nazivIgre, sveListe[2], sveListe[1]);
                this.Close();
            }
        }
    }
}
