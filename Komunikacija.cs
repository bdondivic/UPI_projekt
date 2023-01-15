using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Backlog
{
    public class Igra
    {
        public int id { get; private set; }
        public string naziv { get; private set; }
        public int id_zanr { get; private set; }
        public Igra(int id, string naziv, int id_zanr)
        {
            this.id = id;
            this.naziv = naziv;
            this.id_zanr = id_zanr;

        }
    }
    public class PretragaIgara
    {
        public OleDbConnection con { get; private set; }
        public OleDbCommand cmd { get; private set; }

        public PretragaIgara() //Microsoft.Jet.OlEDB.4.0
        {
            this.con = new OleDbConnection("Provider=Microsoft.Jet.OlEDB.4.0;Data Source=db_Backlog.mdb");
            this.cmd = new OleDbCommand();
        }

        //PRETRAGA IGARA PREMA LISTI TEMELJEM UNOSA I ODABRANOG ŽANRA
        public List<Igra> Trazi(List<Igra> listIgre, int cbIndex, string text)
        {
            List<Igra> lista = new List<Igra>();
            //lbIgre.Items.Clear();
            foreach (Igra igra in listIgre)
            {
                if (cbIndex == -1 || cbIndex == 0)
                {
                    if (igra.naziv.ToUpper().StartsWith(text.ToUpper()))
                    {
                        //lbIgre.Items.Add(igra.naziv);
                        lista.Add(igra);
                    }
                }
                else
                {
                    if (igra.naziv.ToUpper().StartsWith(text.ToUpper()) && (igra.id_zanr == cbIndex))
                    {
                        //lbIgre.Items.Add(igra.naziv);
                        lista.Add(igra);
                    }
                }
            }
            return lista;
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
        public List<object> UcitajOpis(string gameName)
        {
            List<object> lista = new List<object>();
            try
            {
                //rtbOpis.Clear();
                con.Open();
             
                string naredba = $"SELECT * from tb_Igra WHERE Naziv='{gameName.Replace("'", "''")}'";
                cmd = new OleDbCommand(naredba, con);
                OleDbDataReader odg = cmd.ExecuteReader();
                odg.Read();

                lista.Add(odg.GetString(1));
                lista.Add(odg.GetString(2));
                lista.Add(odg.GetInt32(3));
                lista.Add(odg.GetInt32(4));
                lista.Add(odg.GetString(5));
                lista.Add(odg.GetInt32(6) * 1000);
                lista.Add(odg.GetInt32(7) * 1000);
                lista.Add(odg.GetInt32(8) * 1000);
                lista.Add(odg.GetInt32(9) * 1000);
                lista.Add(odg.GetInt32(10) * 1000);

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

        //INICIJALNO UČITAVANJE IGARA IZ BP U LISTU
        public List<Igra> LoadIgre()
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
                    int id_zanr = reader.GetInt32(4);

                    Igra igra = new Igra(id, naziv, id_zanr);

                    lista.Add(igra);

                    //lb.Items.Add(naziv);
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
        public List<Korisnik> Trazi(List<Korisnik> korisnici, string text)
        {
            List<Korisnik> lista = new List<Korisnik>();
            //lbkorisnici.Items.Clear();
            foreach (Korisnik k in korisnici)
            {
                if (k.uName.ToUpper().StartsWith(text.ToUpper()))
                {
                    lista.Add(k);
                }
            }
            return lista;
        }

        //INICIJALNO UČITAVANJE KORISNIKA U LISTU IZ BP
        public List<Korisnik> ucitajKorisnike()
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
                    //korisnici.Items.Add(uName);
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
        public List<object> ucitajInf(string uName)
        {
            List<object> lista = new List<object>();
            try
            {
                //rtbInf.Clear();
                int brBacklog = 0;
                int brIgram = 0;
                int brIgrao = 0;
                con.Open();
                string naredba = $"SELECT * from tb_Korisnik WHERE KorisnIme='{uName.Replace("'", "''")}'";
                cmd = new OleDbCommand(naredba, con);
                OleDbDataReader odg = cmd.ExecuteReader();
                odg.Read();

                //rtbInf.AppendText("Ime: " + odg.GetString(1) + "\n");
                //rtbInf.AppendText("Prezime: " + odg.GetString(2) + "\n");
                //rtbInf.AppendText("Korisničko ime: " + odg.GetString(3) + "\n");
                //rtbInf.AppendText("Lozinka: " + odg.GetString(4) + "\n");
                //rtbInf.AppendText("Datum registracije: " + odg.GetDateTime(6).ToShortDateString() + "\n");
                //rtbInf.AppendText("Posljednja prijava: " + odg.GetDateTime(7).ToShortDateString() + "\n");

                lista.Add(odg.GetString(1));
                lista.Add(odg.GetString(2));
                lista.Add(odg.GetString(3));
                lista.Add(odg.GetString(4));
                lista.Add(odg.GetDateTime(6).ToShortDateString());
                lista.Add(odg.GetDateTime(7).ToShortDateString());

                string naredba1 = $"SELECT Lista_ID from tb_Korisnik_Igra WHERE Korisnik_ID=" +
                    $"(SELECT ID_Korisnik from tb_Korisnik WHERE KorisnIme='{uName}')";
                cmd = new OleDbCommand(naredba1, con);
                odg = cmd.ExecuteReader();
                while (odg.Read())
                {
                    int listaID = odg.GetInt32(0);
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
                    }
                }
                //rtbInf.AppendText("Backlog: " + brBacklog.ToString() + "\n");
                //rtbInf.AppendText("Igram: " + brIgram.ToString() + "\n");
                //rtbInf.AppendText("Igrao: " + brIgrao.ToString() + "\n");

                lista.Add(brBacklog.ToString());
                lista.Add(brIgram.ToString());
                lista.Add(brIgrao.ToString());

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

}
