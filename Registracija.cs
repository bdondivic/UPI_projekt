using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Drawing;
using Backlog;
using System.Xml.Linq;

namespace Test
{
    public class Registracija
    {
        public OleDbConnection con { get; private set; }
        public OleDbCommand cmd { get; private set; }
        public OleDbDataAdapter da { get; private set; }

        public string ime { get; private set; }
        public string prezime { get; private set; }
        public string uName { get; private set; }
        public string pass { get; private set; }
        public string passConf { get; private set; }
        public Registracija(string ime, string prezime, string uName, string pass, string passConf)
        {
            this.con = new OleDbConnection("Provider=Microsoft.Jet.OlEDB.4.0;Data Source=db_Backlog.mdb");
            this.cmd = new OleDbCommand();
            this.da = new OleDbDataAdapter();

            this.ime = ime;
            this.prezime = prezime;
            this.uName = uName;
            this.pass = pass;
            this.passConf = passConf;
        }
        public string Provjera()
        {
            if (ime.Contains(";") || ime.Contains("'") || ime.Contains(","))
                return "Ime ne smije sadržavati znakove , ; '";
            if (ime.Length < 3 || ime.Length > 12)
                return "Ime mora sadržavati između 3 i 12 znakova!";
            if (prezime.Contains(";") || prezime.Contains("'") || prezime.Contains(","))
                return "Prezime ne smije sadržavati znakove , ; '";
            if (prezime.Length < 3 || prezime.Length > 12)
                return "Prezime mora sadržavati između 3 i 12 znakova!";
            if (uName.Contains(";") || uName.Contains("'") || uName.Contains(","))
                return "Korisničko ime ne smije sadržavati znakove , ; '";
            if (uName.Length < 5 || uName.Length > 12)
                return "Korisničko ime mora sadržavati između 5 i 12 znakova!";
            if (pass.Contains(";") || pass.Contains("'") || pass.Contains(","))
                return "Lozinka ne smije sadržavati znakove , ; '";
            if (pass.Length < 6 || pass.Length > 20)
                return "Lozinka mora sadržavati između 6 i 20 znakova!";
            if (pass != passConf)
                return "Lozinke se moraju podudarati!";
            return "Registracija je bila uspješna!";
        }

        public string uNameZauzet()
        {
            try
            {
                con.Open();
                string naredba = $"SELECT * FROM tb_Korisnik WHERE KorisnIme='{uName}'";
                cmd = new OleDbCommand(naredba, con);
                OleDbDataReader odg = cmd.ExecuteReader();
                if (odg.Read() == true)
                {
                    con.Close();
                    return "Korisničko ime nije dostupno jer ga koristi drugi korinik!";
                }
                con.Close();

            }   
            catch (Exception exp)
            {
                return exp.ToString();
            }
            return "Username OK!";
        }

        public bool noviKorisnik()
        {
            try
            {
                con.Open();
                string naredba = $"INSERT INTO tb_Korisnik (Ime, Prezime, KorisnIme, Lozinka, JeAdmin, DatumReg, PosljPrij) " +
                    $"VALUES ('{ime}', '{prezime}', '{uName}', '{pass}', {0}, '{DateTime.Now.ToShortDateString()}', '{DateTime.MinValue.ToShortDateString()}')";
                cmd = new OleDbCommand(naredba, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
                return false;
            }
        }
    }
}
