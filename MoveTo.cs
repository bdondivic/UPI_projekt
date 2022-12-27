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
    public partial class MoveTo : Form
    {
        public string fromTo;
        public string nazivIgre;
        public Korisnik korisnik;
        public MoveTo()
        {
            InitializeComponent();
        }
        public MoveTo(string fromTo, string nazivIgre, ref Korisnik kor)
        {
            InitializeComponent();
            this.fromTo = fromTo;
            this.nazivIgre = nazivIgre;
            this.korisnik = kor;
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
                korisnik.backlogIgram(pocetak, nazivIgre);
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
                korisnik.igramIgrao(kraj, ukupno, nazivIgre);
                this.Close();
            }
            else if (fromTo == "igraoIgram")
            {
                DateTime pocetak = dtPocetak.Value;
                korisnik.igraoIgram(pocetak, nazivIgre);
                this.Close();
            }
        }
    }
}
