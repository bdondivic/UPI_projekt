using Backlog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public class Korisnik
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataAdapter da;

        public int ID { get; private set; }
        public string uName { get; private set; }
        public string pass { get; private set; }

        public ListBox backlog;
        public ListBox igram;
        public ListBox igrao;

        public Korisnik(string uname, string pass, int ID, List<ListBox> liste)
        {
            this.ID = ID;
            this.uName = uname;
            this.pass = pass;
            this.backlog = liste[0];
            this.igram = liste[1];
            this.igrao = liste[2];

            this.con = new OleDbConnection("Provider=Microsoft.Jet.OlEDB.4.0;Data Source=db_Backlog.mdb");
            this.cmd = new OleDbCommand();
            this.da = new OleDbDataAdapter();
        }

        public int dohvatiIdIgre(string nazivIgre)
        {
            try
            {
                con.Open();
                string naredba = $"SELECT * from tb_Igra WHERE Naziv='{nazivIgre.Replace("'", "''")}'";
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

        public void obrisiZapis(int igraID)
        {
            try
            {
                con.Open();
                OleDbCommand comm = new OleDbCommand($"DELETE FROM tb_Korisnik_Igra WHERE Korisnik_ID={ID} AND Igra_ID={igraID}", con);
                comm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }

        }

        public void dohvatiBacklog()  //METODE SU SLIČNE LoadIgre u Komunikcaija.cs, ALI SE NE STVARAJU LISTE JER SE 
                                                       //NE VRŠI PRETRAGA/FILTRACIJA, DOVOLJNO JE DA SE DODAJU U LISTBOXOVE
        {
            try
            {
                con.Open();
                OleDbDataReader reader = null;
                OleDbCommand comm = new OleDbCommand($"SELECT * FROM tb_Igra " +
                    $"WHERE ID_Igra IN " +
                    $"(SELECT Igra_ID from tb_Korisnik_Igra WHERE Korisnik_ID=" +
                    $"(SELECT ID_Korisnik from tb_Korisnik WHERE KorisnIme='{uName}')" +
                    $"AND Lista_ID=" +
                    $"(SELECT ID_Lista from tb_Lista WHERE Naziv='backlog'));", con);
                reader = comm.ExecuteReader();

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

        public void dohvatiIgram()
        {
            try
            {
                con.Open();
                OleDbDataReader reader = null;
                OleDbCommand comm = new OleDbCommand($"SELECT * FROM tb_Igra " +
                    $"WHERE ID_Igra IN " +
                    $"(SELECT Igra_ID from tb_Korisnik_Igra WHERE Korisnik_ID=" +
                    $"(SELECT ID_Korisnik from tb_Korisnik WHERE KorisnIme='{uName}')" +
                    $"AND Lista_ID=" +
                    $"(SELECT ID_Lista from tb_Lista WHERE Naziv='igram'));", con);
                reader = comm.ExecuteReader();

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

        public void dohvatiIgrao()
        {
            try
            {
                con.Open();
                OleDbDataReader reader = null;
                OleDbCommand comm = new OleDbCommand($"SELECT * FROM tb_Igra " +
                    $"WHERE ID_Igra IN " +
                    $"(SELECT Igra_ID from tb_Korisnik_Igra WHERE Korisnik_ID=" +
                    $"(SELECT ID_Korisnik from tb_Korisnik WHERE KorisnIme='{uName}')" +
                    $"AND Lista_ID=" +
                    $"(SELECT ID_Lista from tb_Lista WHERE Naziv='igrao'));", con);
                reader = comm.ExecuteReader();

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
            }
        }

        public void DodajBacklog(int lista, int prioritet, string nazivIgre)
        {
            try
            {
                //DOHVAĆANJE ID-a igre NA TEMELJU PROSLIJEĐENOG NAZIVA
                int igraID = dohvatiIdIgre(nazivIgre);

                //UMETANJE ZAPISA U BP
                con.Open();
                OleDbCommand comm = new OleDbCommand($"INSERT INTO tb_Korisnik_Igra " +
                    $"(Korisnik_ID, Igra_ID, Prioritet_ID, Lista_ID)" +
                    $"VALUES ({ID},{igraID},{prioritet},{lista});", con);
                comm.ExecuteNonQuery();
                con.Close();

                //UMETANJE U LISTBOX
                backlog.Items.Add(nazivIgre);

                MessageBox.Show("Igra je uspješno dodana!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        public void DodajIgram(int lista, DateTime pocetak, string nazivIgre)
        {
            try
            {
                //DOHVAĆANJE ID-a igre NA TEMELJU PROSLIJEĐENOG NAZIVA
                int igraID = dohvatiIdIgre(nazivIgre);

                //UMETANJE ZAPISA U BP
                con.Open();
                OleDbCommand comm = new OleDbCommand($"INSERT INTO tb_Korisnik_Igra " +
                    $"(Korisnik_ID, Igra_ID, Datum_poc, Prioritet_ID, Lista_ID)" +
                    $"VALUES ({ID},{igraID},'{pocetak.ToString()}',NULL,{lista});", con);
                comm.ExecuteNonQuery();
                con.Close();

                //UMETANJE U LISTBOX
                igram.Items.Add(nazivIgre);

                MessageBox.Show("Igra je uspješno dodana!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        public void DodajIgrao(int lista, DateTime pocetak, DateTime kraj, int ukupno, string nazivIgre)
        {
            try
            {
                //DOHVAĆANJE ID-a igre NA TEMELJU PROSLIJEĐENOG NAZIVA
                int igraID = dohvatiIdIgre(nazivIgre);

                //UMETANJE ZAPISA U BP
                con.Open();
                OleDbCommand comm = new OleDbCommand($"INSERT INTO tb_Korisnik_Igra " +
                    $"(Korisnik_ID, Igra_ID, Vr_igranja, Datum_poc, Datum_kraj, Prioritet_ID, Lista_ID)" +
                    $"VALUES ({ID},{igraID},{ukupno},'{pocetak.ToString()}','{kraj.ToString()}',NULL,{lista});", con);
                comm.ExecuteNonQuery();
                con.Close();

                //UMETANJE U LISTBOX
                igrao.Items.Add(nazivIgre);

                MessageBox.Show("Igra je uspješno dodana!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        public void UkloniBacklog(string nazivIgre)
        {
            //DOHVAĆANJE ID-a igre NA TEMELJU PROSLIJEĐENOG NAZIVA
            int igraID = dohvatiIdIgre(nazivIgre);

            //BRISANJE ZAPISA IZ BP
            obrisiZapis(igraID);

            //UKLANJANJE IZ LISTBOXA
            backlog.Items.Remove(backlog.SelectedItem);

            MessageBox.Show("Igra je uspješno uklonjena iz liste!");


        }

        public void UkloniIgram(string nazivIgre)
        {
            //DOHVAĆANJE ID-a igre NA TEMELJU PROSLIJEĐENOG NAZIVA
            int igraID = dohvatiIdIgre(nazivIgre);

            //BRISANJE ZAPISA IZ BP
            obrisiZapis(igraID);

            //UKLANJANJE IZ LISTBOXA
            igram.Items.Remove(igram.SelectedItem);

            MessageBox.Show("Igra je uspješno uklonjena iz liste!");
        }

        public void UkloniIgrao(string nazivIgre)
        {
            //DOHVAĆANJE ID-a igre NA TEMELJU PROSLIJEĐENOG NAZIVA
            int igraID = dohvatiIdIgre(nazivIgre);

            //BRISANJE ZAPISA IZ BP
            obrisiZapis(igraID);

            //UKLANJANJE IZ LISTBOXA
            igrao.Items.Remove(igrao.SelectedItem);

            MessageBox.Show("Igra je uspješno uklonjena iz liste!");
        }
    }
}
