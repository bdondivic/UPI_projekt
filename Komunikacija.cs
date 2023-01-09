using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using Backlog;
using Test;

namespace Backlog
{
    public class Igra
    {
        public int id { get; private set; }
        public string naziv { get; private set; }
        public string platforma { get; private set; }
        public int godina { get; private set; }
        public int id_zanr { get; private set; }
        public string izdavac { get; private set; }
        public int NA_sales { get; private set; }
        public int EU_sales { get; private set; }
        public int JP_sales { get; private set; }
        public int other_sales { get; private set; }
        public int global_sales { get; private set; }
        public Igra(int id, string naziv, string plat, int god, int id_zanr, string izdavac, int NA, int EU, int JP, int oth_sales, int sales)
        {
            this.id = id;
            this.naziv = naziv;
            this.platforma = plat;
            this.godina = god;
            this.id_zanr = id_zanr;
            this.izdavac = izdavac;
            this.NA_sales = NA;
            this.EU_sales = EU;
            this.JP_sales = JP;
            this.other_sales = oth_sales;
            this.global_sales = sales;
        }
    }
    public class PretragaIgara
    {   
        public OleDbConnection con { get; private set; }
        public OleDbCommand cmd { get; private set; }

        public PretragaIgara()
        {
            this.con = new OleDbConnection("Provider=Microsoft.Jet.OlEDB.4.0;Data Source=db_Backlog.mdb");
            this.cmd = new OleDbCommand();
        }

        //PRETRAGA IGARA PREMA LISTI TEMELJEM UNOSA I ODABRANOG ŽANRA
        public void Trazi(ListBox lbIgre, List<Igra> listIgre, ComboBox cbZanr, TextBox txtPretraga)
        {
            lbIgre.Items.Clear();
            foreach (Igra igra in listIgre)
            {
                if (cbZanr.SelectedIndex == -1 || cbZanr.SelectedIndex == 0)
                {
                    if (igra.naziv.ToUpper().StartsWith(txtPretraga.Text.ToUpper()))
                    {
                        lbIgre.Items.Add(igra.naziv);
                    }
                }
                else
                {
                    if (igra.naziv.ToUpper().StartsWith(txtPretraga.Text.ToUpper()) && (igra.id_zanr == cbZanr.SelectedIndex))
                    {
                        lbIgre.Items.Add(igra.naziv);
                    }
                }
            }
        }

        //INICIJALNO UČITAVANJE ŽANROVA
        public List<string> UcitajZanrove()
        {
            try
            {
                con.Open();
                string naredba2 = $"SELECT * FROM tb_Zanr";
                cmd = new OleDbCommand(naredba2, con);
                OleDbDataReader odg = cmd.ExecuteReader();
                List<string> zanrovi = new List<string>();
                while (odg.Read())
                {
                    zanrovi.Add(odg.GetString(1));
                }
                con.Close();
                return zanrovi;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
                return null;
            }
            
        }

        //UČITAVANJE OPISA ZA ODABRANU IGRU IZ BP
        public void UcitajOpis(RichTextBox rtbOpis, ComboBox cbZanr, string gameName)
        {
            try
            {
                rtbOpis.Clear();
                con.Open();
                string naredba = $"SELECT * from tb_Igra WHERE Naziv='{gameName.Replace("'", "''")}'";
                cmd = new OleDbCommand(naredba, con);
                OleDbDataReader odg = cmd.ExecuteReader();
                odg.Read();

                rtbOpis.AppendText($"Naziv: {odg.GetString(1)}\n");
                rtbOpis.AppendText($"Platforma: {odg.GetString(2)}\n");
                rtbOpis.AppendText($"Godina: {odg.GetInt32(3)}\n");
                rtbOpis.AppendText($"Žanr: {cbZanr.Items[odg.GetInt32(4)]}\n");
                rtbOpis.AppendText($"Izdavač: {odg.GetString(5)}\n");
                rtbOpis.AppendText($"NA sales: {odg.GetInt32(6) * 1000}\n");
                rtbOpis.AppendText($"EU sales: {odg.GetInt32(7) * 1000}\n");
                rtbOpis.AppendText($"JP sales: {odg.GetInt32(8) * 1000}\n");
                rtbOpis.AppendText($"Other sales: {odg.GetInt32(9) * 1000}\n");
                rtbOpis.AppendText($"Global sales: {odg.GetInt32(10) * 1000}\n");

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
                return;
            }
            
        }

        //INICIJALNO UČITAVANJE IGARA IZ BP U LISTU
        public List<Igra> LoadIgre(ListBox lb)
        {
            try
            {
                con.Open();
                OleDbDataReader reader = null;
                OleDbCommand comm = new OleDbCommand($"SELECT * FROM tb_Igra", con);
                reader = comm.ExecuteReader();
                List<Igra> lista = new List<Igra>();

                while (reader.Read())
                {

                    int id = reader.GetInt32(0);
                    string naziv = reader.GetString(1);
                    string platforma = reader.GetString(2);
                    int godina = reader.GetInt32(3);
                    int id_zanr = reader.GetInt32(4);
                    string izdavac = reader.GetString(5);
                    int NA_sales = reader.GetInt32(6);
                    int EU_sales = reader.GetInt32(7);
                    int JP_sales = reader.GetInt32(8);
                    int other_sales = reader.GetInt32(9);
                    int global_sales = reader.GetInt32(10);

                    Igra igra = new Igra(id, naziv, platforma, godina, id_zanr, izdavac, NA_sales, EU_sales, JP_sales, other_sales, global_sales);

                    lista.Add(igra);

                    lb.Items.Add(naziv);
                }

                con.Close();
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
                return null;
            }
            
        }
    }

    public class PretragaKorisnika
    {
        public OleDbConnection con { get; private set; }
        public OleDbCommand cmd { get; private set; }

        public PretragaKorisnika()
        {
            this.con = new OleDbConnection("Provider=Microsoft.Jet.OlEDB.4.0;Data Source=db_Backlog.mdb");
            this.cmd = new OleDbCommand();
        }

        //PRETRAGA KORISNIKA PO LISTI TEMELJEM UNOSA
        public void Trazi(ListBox lbkorisnici, List<Korisnik> korisnici, TextBox txtPretraga)
        {
            lbkorisnici.Items.Clear();
            foreach (Korisnik k in korisnici)
            {
                if (k.uName.ToUpper().StartsWith(txtPretraga.Text.ToUpper()))
                {
                    lbkorisnici.Items.Add(k.uName);
                }
            }
        }

        //INICIJALNO UČITAVANJE KORISNIKA U LISTU IZ BP
        public List<Korisnik> ucitajKorisnike(ListBox korisnici)
        {
            try
            {
                List<Korisnik> listaKorisnici = new List<Korisnik>();
                con.Open();
                string naredba = $"SELECT * from tb_Korisnik WHERE JeAdmin=0";
                cmd = new OleDbCommand(naredba, con);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int ID = reader.GetInt32(0);
                    string ime = reader.GetString(1);
                    string prezime = reader.GetString(2);
                    string uName = reader.GetString(3);
                    string pass = reader.GetString(4);
                    Korisnik k = new Korisnik(ime, prezime, uName, pass, ID);
                    listaKorisnici.Add(k);
                    korisnici.Items.Add(uName);
                }
                con.Close();
                return listaKorisnici;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
                return null;
            }
        }

        //UČITAVANJE INFORMACIJA O KORISNIKU IZ BP
        public void ucitajInf(RichTextBox rtbInf, string uName)
        {
            try
            {
                rtbInf.Clear();
                int brBacklog = 0;
                int brIgram = 0;
                int brIgrao = 0;
                con.Open();
                string naredba = $"SELECT * from tb_Korisnik WHERE KorisnIme='{uName.Replace("'", "''")}'";
                cmd = new OleDbCommand(naredba, con);
                OleDbDataReader odg = cmd.ExecuteReader();
                odg.Read();
                rtbInf.AppendText("Ime: " + odg.GetString(1) + "\n");
                rtbInf.AppendText("Prezime: " + odg.GetString(2) + "\n");
                rtbInf.AppendText("Korisničko ime: " + odg.GetString(3) + "\n");
                rtbInf.AppendText("Lozinka: " + odg.GetString(4) +  "\n");
                rtbInf.AppendText("Datum registracije: " + odg.GetDateTime(6).ToShortDateString() + "\n");
                rtbInf.AppendText("Posljednja prijava: " + odg.GetDateTime(7).ToShortDateString() + "\n");
                string naredba1 = $"SELECT Lista_ID from tb_Korisnik_Igra WHERE Korisnik_ID=" +
                    $"(SELECT ID_Korisnik from tb_Korisnik WHERE KorisnIme='{uName}')";
                cmd = new OleDbCommand(naredba1, con);
                odg = cmd.ExecuteReader();
                while (odg.Read())
                {
                    int listaID = odg.GetInt32(0);
                    if (listaID==1)
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
                    }
                }
                rtbInf.AppendText("Backlog: " + brBacklog.ToString() + "\n");
                rtbInf.AppendText("Igram: " + brIgram.ToString() + "\n");
                rtbInf.AppendText("Igrao: " + brIgrao.ToString() + "\n");
                con.Close();
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
