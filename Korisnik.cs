using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Backlog
{
    public class Korisnik
    {
        public OleDbConnection con { get; private set; }
        public OleDbCommand cmd { get; private set; }

        public int ID { get; private set; }
        public string uName { get; private set; }
        public string pass { get; private set; }
        public string ime { get; private set; }
        public string prezime { get; private set; }

        public Korisnik(string name, string sur, string uname, string pass, int ID)
        {
            this.ime = name;
            this.prezime = sur;
            this.ID = ID;
            this.uName = uname;
            this.pass = pass;

            this.con = new OleDbConnection("Provider=Microsoft.Jet.OlEDB.4.0;Data Source=db_Backlog.mdb");
            this.cmd = new OleDbCommand();
        }

        //PRAĆENJE DATUMA POSLJEDNJE PRIJAVE KORISNIKA
        public void posljPrijava()
        {
            try
            {
                con.Open();
                string naredba = $"UPDATE tb_Korisnik SET PosljPrij='{DateTime.Now.ToShortDateString()}' " +
                    $"WHERE KorisnIme='{uName}'";
                cmd = new OleDbCommand(naredba, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
                return;
            }
        }

        //PRIKAZ OSNOVNIH KORISNIČKIH PODATAKA
        public void podaciKor(Label ime, Label prezime, Label korIme)
        {
            try
            {
                ime.Text = "Ime: " + this.ime;
                prezime.Text = "Prezime: " + this.prezime;
                korIme.Text = "Korisničko ime: " + uName;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
                return;
            }
        }

        //PRIKAZ STATISTIČKIH KORISNIČKIH PODATAKA
        public void korStatistika(List<Label> labele)
        {
            int brBacklog = 0;
            int brIgram = 0;
            int brIgrao = 0;
            int ukupno = 0;
            try
            {

                con.Open();
                string naredba = $"SELECT * from tb_Korisnik_Igra WHERE Korisnik_ID={ID}";
                cmd = new OleDbCommand(naredba, con);
                OleDbDataReader odg = cmd.ExecuteReader();
                while (odg.Read())
                {
                    int listaID = odg.GetInt32(6);
                    if (listaID == 1)
                    {
                        brBacklog++;
                    }
                    else if (listaID == 2)
                    {
                        brIgram++;
                    }
                    else if (listaID == 3)
                    {
                        brIgrao++;
                        ukupno += odg.GetInt32(2);
                    }
                }
                decimal postotak;
                try
                {
                    postotak = (decimal)brIgrao / ((decimal)brBacklog + (decimal)brIgram + (decimal)brIgrao);

                }
                catch
                {
                    postotak = 0;
                }
                con.Close();
                labele[0].Text = "Backlog: " + brBacklog.ToString();
                labele[1].Text = "Igram: " + brIgram.ToString();
                labele[2].Text = "Igrao: " + brIgrao.ToString();
                labele[3].Text = "Postotak odigranih: " + ((int)(postotak * 100)).ToString() + "%";
                labele[4].Text = "Ukupno vrijeme igranja: " + ukupno.ToString() + "h";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
                return;
            }
        }

        //PROMJENA KORISNIČKE LOZINKE
        public bool promijeniPass(string newPass)
        {
            try
            {
                con.Open();
                string naredba = $"UPDATE tb_Korisnik SET Lozinka='{newPass}' WHERE ID_Korisnik={ID}";
                cmd = new OleDbCommand(naredba, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Loznika je uspješno izmijenjena!");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
                return false;
            }
        }

        //BRISANJE PROFILA IZ BP
        public bool izbrisiRacun()
        {
            try
            {
                con.Open();
                string naredba = $"DELETE FROM tb_Korisnik_Igra WHERE Korisnik_ID={ID}";
                cmd = new OleDbCommand(naredba, con);
                cmd.ExecuteNonQuery();
                naredba = $"DELETE FROM tb_Korisnik WHERE ID_Korisnik={ID}";
                cmd = new OleDbCommand(naredba, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Račun je uspješno izbrisan!");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
                return false;
            }
        }

        //DOHVAĆANJE ID-A IGRRE U BP
        private int dohvatiIdIgre(string nazivIgre)
        {
            try
            {
                con.Open();
                string naredba = $"SELECT ID_Igra from tb_Igra WHERE Naziv='{nazivIgre.Replace("'", "''")}'";
                cmd = new OleDbCommand(naredba, con);
                OleDbDataReader odg = cmd.ExecuteReader();
                odg.Read();
                int igraID = odg.GetInt32(0);
                con.Close();
                return igraID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
        }

        //BRISANJE ZAPISA O IGRI IZ KORISNIKOVE LISTE U BP
        public void obrisiZapis(int igraID)
        {
            try
            {
                con.Open();
                string naredba = $"DELETE FROM tb_Korisnik_Igra WHERE Korisnik_ID={ID} AND Igra_ID={igraID}";
                cmd = new OleDbCommand(naredba, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }

        }

        //INICIJALNO DOHVAĆANJE ZAPISA U LISTAMA KORISNIKA IZ BP
        public void dohvatiBacklog(ListBox backlog)  //METODE SU SLIČNE LoadIgre u Komunikcaija.cs, ALI SE NE STVARAJU LISTE JER SE 
                                                     //NE VRŠI PRETRAGA/FILTRACIJA, DOVOLJNO JE DA SE DODAJU U LISTBOXOVE
        {
            try
            {
                con.Open();
                OleDbDataReader reader = null;
                string naredba = $"SELECT * FROM tb_Igra " +
                    $"WHERE ID_Igra IN " +
                    $"(SELECT Igra_ID from tb_Korisnik_Igra WHERE Korisnik_ID=" +
                    $"(SELECT ID_Korisnik from tb_Korisnik WHERE KorisnIme='{uName}')" +
                    $"AND Lista_ID=" +
                    $"(SELECT ID_Lista from tb_Lista WHERE Naziv='backlog'));";
                cmd = new OleDbCommand(naredba, con);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string naziv = reader.GetString(1);
                    backlog.Items.Add(naziv);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void dohvatiIgram(ListBox igram)
        {
            try
            {
                con.Open();
                OleDbDataReader reader = null;
                string naredba = $"SELECT * FROM tb_Igra " +
                    $"WHERE ID_Igra IN " +
                    $"(SELECT Igra_ID from tb_Korisnik_Igra WHERE Korisnik_ID=" +
                    $"(SELECT ID_Korisnik from tb_Korisnik WHERE KorisnIme='{uName}')" +
                    $"AND Lista_ID=" +
                    $"(SELECT ID_Lista from tb_Lista WHERE Naziv='igram'));";
                cmd = new OleDbCommand(naredba, con);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string naziv = reader.GetString(1);
                    igram.Items.Add(naziv);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void dohvatiIgrao(ListBox igrao)
        {
            try
            {
                con.Open();
                OleDbDataReader reader = null;
                string naredba = $"SELECT * FROM tb_Igra " +
                    $"WHERE ID_Igra IN " +
                    $"(SELECT Igra_ID from tb_Korisnik_Igra WHERE Korisnik_ID=" +
                    $"(SELECT ID_Korisnik from tb_Korisnik WHERE KorisnIme='{uName}')" +
                    $"AND Lista_ID=" +
                    $"(SELECT ID_Lista from tb_Lista WHERE Naziv='igrao'));";
                cmd = new OleDbCommand(naredba, con);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string naziv = reader.GetString(1);
                    igrao.Items.Add(naziv);

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }
        }

        //PROVJERA POSTOJI LI VEĆ MEĐU KORISNIKOVIM LISTAMA ZAPIS S IGROM U BP
        public bool postojiZapis(string nazivIgre)
        {
            try
            {
                con.Open();
                string naredba = $"SELECT * FROM Tb_Korisnik_Igra WHERE Korisnik_ID=" +
                    $"(SELECT ID_Korisnik from tb_Korisnik WHERE KorisnIme='{uName}')" +
                    $"AND Igra_ID=(SELECT ID_igra from tb_Igra WHERE Naziv='{nazivIgre}')";
                cmd = new OleDbCommand(naredba, con);
                OleDbDataReader odg = cmd.ExecuteReader();
                if (odg.Read() == true)
                {
                    con.Close();
                    MessageBox.Show("Zapis sa obabranom igrom već postoji!");
                    return true;
                }
                con.Close();
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return true;
            }

        }

        //DOHVAĆANJE OPISA IGRE IZ KORISNIKOVE LISTE U BP
        public void dohvatiOpis(string nazivIgre, string lista, RichTextBox opis)
        {
            int igraID = dohvatiIdIgre(nazivIgre);
            try
            {
                con.Open();
                OleDbDataReader reader = null;
                string naredba = $"SELECT * from tb_Korisnik_Igra WHERE Korisnik_ID={ID} and Igra_ID={igraID};";
                cmd = new OleDbCommand(naredba, con);
                reader = cmd.ExecuteReader();
                reader.Read();

                if (lista == "BACKLOG")
                {
                    int idPrioritet = reader.GetInt32(5);
                    string naredba1 = $"SELECT Naziv from tb_Prioritet WHERE ID_Prioritet={idPrioritet};";
                    OleDbCommand cmd1 = new OleDbCommand(naredba1, con);
                    reader = cmd1.ExecuteReader();
                    reader.Read();
                    string prioritet = reader.GetString(0);
                    con.Close();

                    opis.Clear();
                    opis.Text = $"Prioritet: {prioritet}";
                }
                else if (lista == "IGRAM")
                {
                    string pocetak = reader.GetDateTime(3).ToShortDateString();
                    opis.Clear();
                    opis.Text = $"Datum početka igranja: {pocetak}";
                    con.Close();
                }
                else if (lista == "IGRAO")
                {
                    string pocetak = reader.GetDateTime(3).ToShortDateString();
                    string kraj = reader.GetDateTime(4).ToShortDateString();
                    int ukupno = reader.GetInt32(2);
                    con.Close();

                    opis.Clear();
                    opis.Text = $"Ukupno vrijeme igranja: {ukupno}\n" +
                        $"Datum početka igranja: {pocetak}\n" +
                        $"Datum prelaska: {kraj}";
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
                return;
            }
        }

        //DODAVANJE ZAPISA/ IGARA U LISTE KORISNIKA U BP
        public void DodajBacklog(int lista, int prioritet, string nazivIgre, ListBox backlog)
        {
            try
            {
                int igraID = dohvatiIdIgre(nazivIgre);
                con.Open();
                string naredba = $"INSERT INTO tb_Korisnik_Igra " +
                    $"(Korisnik_ID, Igra_ID, Prioritet_ID, Lista_ID)" +
                    $"VALUES ({ID},{igraID},{prioritet},{lista});";
                cmd = new OleDbCommand(naredba, con);
                cmd.ExecuteNonQuery();
                con.Close();
                backlog.Items.Add(nazivIgre);
                MessageBox.Show("Igra je uspješno dodana!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
                return;
            }
        }

        public void DodajIgram(int lista, DateTime pocetak, string nazivIgre, ListBox igram)
        {
            try
            {
                int igraID = dohvatiIdIgre(nazivIgre);
                con.Open();
                string naredba = $"INSERT INTO tb_Korisnik_Igra " +
                    $"(Korisnik_ID, Igra_ID, Datum_poc, Prioritet_ID, Lista_ID)" +
                    $"VALUES ({ID},{igraID},'{pocetak.ToShortDateString()}',NULL,{lista});";
                cmd = new OleDbCommand(naredba, con);
                cmd.ExecuteNonQuery();
                con.Close();
                igram.Items.Add(nazivIgre);
                MessageBox.Show("Igra je uspješno dodana!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
                return;
            }
        }

        public void DodajIgrao(int lista, DateTime pocetak, DateTime kraj, int ukupno, string nazivIgre, ListBox igrao)
        {
            try
            {
                int igraID = dohvatiIdIgre(nazivIgre);
                con.Open();
                string naredba = $"INSERT INTO tb_Korisnik_Igra " +
                    $"(Korisnik_ID, Igra_ID, Vr_igranja, Datum_poc, Datum_kraj, Prioritet_ID, Lista_ID)" +
                    $"VALUES ({ID},{igraID},{ukupno},'{pocetak.ToShortDateString()}','{kraj.ToShortDateString()}',NULL,{lista});";
                cmd = new OleDbCommand(naredba, con);
                cmd.ExecuteNonQuery();
                con.Close();
                igrao.Items.Add(nazivIgre);
                MessageBox.Show("Igra je uspješno dodana!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
                return;
            }
        }

        //UKLANJANJE ZAPISA IZ TRENUTNOG PRIKAZA I BP
        public void UkloniBacklog(string nazivIgre, ListBox backlog, RichTextBox opisBacklog)
        {
            int igraID = dohvatiIdIgre(nazivIgre);
            obrisiZapis(igraID);
            backlog.Items.Remove(backlog.SelectedItem);
            opisBacklog.Clear();
            MessageBox.Show("Igra je uspješno uklonjena iz liste!");
        }

        public void UkloniIgram(string nazivIgre, ListBox igram, RichTextBox opisIgram)
        {
            int igraID = dohvatiIdIgre(nazivIgre);
            obrisiZapis(igraID);
            igram.Items.Remove(igram.SelectedItem);
            opisIgram.Clear();
            MessageBox.Show("Igra je uspješno uklonjena iz liste!");
        }

        public void UkloniIgrao(string nazivIgre, ListBox igrao, RichTextBox opisIgrao)
        {
            int igraID = dohvatiIdIgre(nazivIgre);
            obrisiZapis(igraID);
            igrao.Items.Remove(igrao.SelectedItem);
            opisIgrao.Clear();
            MessageBox.Show("Igra je uspješno uklonjena iz liste!");
        }

        //PRIJENOS ZAPISA IZ JEDNE LISTE U DRUGU 
        public void backlogIgram(DateTime pocetak, string nazivIgre, ListBox backlog, ListBox igram)
        {
            int igraID = dohvatiIdIgre(nazivIgre);
            try
            {
                con.Open();
                string naredba = $"UPDATE tb_Korisnik_Igra SET Datum_poc='{pocetak.ToShortDateString()}', " +
                    $"Prioritet_ID=NULL, Lista_ID=2 " +
                    $"WHERE Korisnik_ID={ID} AND Igra_ID={igraID};";
                cmd = new OleDbCommand(naredba, con);
                cmd.ExecuteNonQuery();
                con.Close();
                backlog.Items.Remove(backlog.SelectedItem);
                igram.Items.Add(nazivIgre);
                MessageBox.Show("Igra je uspješno prenesena!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
                return;
            }
        }

        public void igramIgrao(DateTime kraj, int ukupno, string nazivIgre, ListBox igram, ListBox igrao)
        {
            int igraID = dohvatiIdIgre(nazivIgre);
            try
            {
                con.Open();
                string naredba = $"SELECT Datum_poc FROM tb_Korisnik_Igra " +
                    $"WHERE Korisnik_ID={ID} AND Igra_ID={igraID}";
                cmd = new OleDbCommand(naredba, con);
                OleDbDataReader reader = cmd.ExecuteReader();
                reader.Read();
                DateTime pocetak = reader.GetDateTime(0);
                TimeSpan razlika = kraj - pocetak;
                if (razlika.TotalHours + 24 < ukupno)
                {
                    MessageBox.Show("Ukupno vrijeme ne može biti veće od razlike kraja i početka igranja!");
                    con.Close();
                    return;
                }
                string naredba1 = $"UPDATE tb_Korisnik_Igra SET Datum_kraj='{kraj.ToShortDateString()}', " +
                    $"Vr_igranja={ukupno}, Lista_ID=3 " +
                    $"WHERE Korisnik_ID={ID} AND Igra_ID={igraID}";
                OleDbCommand cmd1 = new OleDbCommand(naredba1, con);
                cmd1.ExecuteNonQuery();
                con.Close();
                igram.Items.Remove(igram.SelectedItem);
                igrao.Items.Add(nazivIgre);
                MessageBox.Show("Igra je uspješno prenesena!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
                return;
            }
        }

        public void igraoIgram(DateTime pocetak, string nazivIgre, ListBox igrao, ListBox igram)
        {
            int igraID = dohvatiIdIgre(nazivIgre);
            try
            {
                con.Open();
                string naredba = $"UPDATE tb_Korisnik_Igra SET Datum_poc='{pocetak.ToShortDateString()}', " +
                    $"Vr_igranja=0, Datum_kraj=NULL, Lista_ID=2 " +
                    $"WHERE Korisnik_ID={ID} AND Igra_ID={igraID}";
                cmd = new OleDbCommand(naredba, con);
                cmd.ExecuteNonQuery();
                con.Close();
                igrao.Items.Remove(igrao.SelectedItem);
                igram.Items.Add(nazivIgre);
                MessageBox.Show("Igra je uspješno prenesena!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
                return;
            }
        }
    }
}
