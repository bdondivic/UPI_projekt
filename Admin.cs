using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Backlog
{
    public class Admin
    {
        public OleDbConnection con { get; private set; }
        public OleDbCommand cmd { get; private set; }

        public Admin()
        {
            this.con = new OleDbConnection("Provider=Microsoft.Jet.OlEDB.4.0;Data Source=db_Backlog.mdb");
            this.cmd = new OleDbCommand();
        }

        //BRISANJE KORISNIČKOG PROFILA IZ BP
        public void izbrisiRacun(ListBox korisnici, RichTextBox opis, List<Korisnik> lista, string uName)
        {
            try
            {
                con.Open();
                string naredba = $"DELETE FROM tb_Korisnik_Igra WHERE Korisnik_ID=" +
                    $"(SELECT ID_Korisnik FROM tb_Korisnik WHERE KorisnIme='{uName}')";
                cmd = new OleDbCommand(naredba, con);
                cmd.ExecuteNonQuery();
                naredba = $"DELETE FROM tb_Korisnik WHERE ID_Korisnik=" +
                    $"(SELECT ID_Korisnik FROM tb_Korisnik WHERE KorisnIme='{uName}')";
                cmd = new OleDbCommand(naredba, con);
                cmd.ExecuteNonQuery();
                con.Close();
                korisnici.Items.Remove(korisnici.SelectedItem);
                opis.Clear();
                lista.RemoveAll(k => k.uName == uName);
                MessageBox.Show("Račun je uspješno izbrisan!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
                return;
            }
        }

        //PPREUZIMANJE PODATAKA O KORISNIKOVIM LISTAMA U CSV DATOTEKE
        public bool preuzmiPodKor(string uName)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string path1 = Path.Combine(fbd.SelectedPath, "backlog_" + uName + ".csv");
                string path2 = Path.Combine(fbd.SelectedPath, "igram_" + uName + ".csv");
                string path3 = Path.Combine(fbd.SelectedPath, "igrao_" + uName + ".csv");

                try
                {
                    var backlog = new List<(string, string)>();
                    var igram = new List<(string, string)>();
                    var igrao = new List<(string, string, string, string)>();
                    con.Open();
                    string naredba = $"SELECT l.Naziv, i.Naziv, ki.Vr_Igranja, ki.Datum_poc, ki.Datum_kraj, ki.Prioritet_ID " +
                        $"FROM ((tb_Korisnik_Igra ki INNER JOIN tb_Igra i on ki.Igra_ID=i.ID_Igra) " +
                        $"INNER JOIN tb_Lista l ON ki.Lista_ID=l.ID_Lista) " +
                        $"WHERE ki.Korisnik_ID=" +
                        $"(SELECT ID_Korisnik from tb_Korisnik WHERE KorisnIme='{uName}');";
                    cmd = new OleDbCommand(naredba, con);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string lista = reader.GetString(0);
                        string naziv = reader.GetString(1);
                        if (lista == "backlog")
                        {
                            int prioritetID = reader.GetInt32(5);
                            string naredba1 = $"SELECT Naziv from tb_Prioritet WHERE ID_Prioritet={prioritetID}";
                            OleDbCommand cmd1 = new OleDbCommand(naredba1, con);
                            OleDbDataReader odg = cmd1.ExecuteReader();
                            odg.Read();
                            string prioritet = odg.GetString(0);
                            backlog.Add((naziv, prioritet));
                        }
                        else if (lista == "igram")
                        {
                            string datumPoc = reader.GetDateTime(3).ToShortDateString();
                            igram.Add((naziv, datumPoc));
                        }
                        else
                        {
                            string ukupno = reader.GetInt32(2).ToString();
                            string datumPoc = reader.GetDateTime(3).ToShortDateString();
                            string datumKraj = reader.GetDateTime(4).ToShortDateString();
                            igrao.Add((naziv, ukupno, datumPoc, datumKraj));
                        }
                    }
                    con.Close();
                    using (StreamWriter sw = File.CreateText(path1))
                    {
                        sw.WriteLine("Naziv, Prioritet");
                        if (backlog.Count != 0)
                        {
                            foreach ((string, string) r in backlog)
                            {
                                sw.WriteLine(r.Item1 + "," + r.Item2);
                            }
                        }
                    }
                    using (StreamWriter sw = File.CreateText(path2))
                    {
                        sw.WriteLine("Naziv, Datum_poc");
                        if (igram.Count != 0)
                        {
                            foreach ((string, string) r in igram)
                            {
                                sw.WriteLine(r.Item1 + "," + r.Item2);
                            }
                        }
                    }
                    using (StreamWriter sw = File.CreateText(path3))
                    {
                        sw.WriteLine("Naziv, Vr_Igranja, Datum_poc, Datum_kraj");
                        if (igrao.Count != 0)
                        {
                            foreach ((string, string, string, string) r in igrao)
                            {
                                sw.WriteLine(r.Item1 + "," + r.Item2 + "," + r.Item3 + "," + r.Item4);
                            }
                        }
                    }
                    MessageBox.Show("Liste korisnika " + uName + " uspješno su preuzete na putanji:\n" + fbd.SelectedPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    con.Close();
                    return false;
                }
            }
            return false;
        }

        //PREUZIMANJE OSNOVNIH KORISNIČKIH PODATAKA ZA SVE KORISNIKE U CSV DATOTEKU
        public void preuzmiPodSvi()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string path = Path.Combine(fbd.SelectedPath, "korisnici.csv");
                try
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.Write(Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble()));
                        sw.WriteLine("Ime,Prezime,KorisnIme,Lozinka,DatumReg,PosljPrij");
                        con.Open();
                        string naredba = "SELECT * FROM tb_Korisnik WHERE JeAdmin=0";
                        cmd = new OleDbCommand(naredba, con);
                        OleDbDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            string ime = reader.GetString(1);
                            string prezime = reader.GetString(2);
                            string uName = reader.GetString(3);
                            string pass = reader.GetString(4);
                            string datumReg = reader.GetDateTime(6).ToShortDateString();
                            string posljPrij = reader.GetDateTime(7).ToShortDateString();
                            sw.WriteLine(ime + "," + prezime + "," + uName + "," + pass + "," + datumReg + "," + posljPrij);
                        }
                        con.Close();
                        MessageBox.Show($"Podaci korisnika uspješno su preuzeti na putanji:\n" + fbd.SelectedPath);
                    }
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
}
