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
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataAdapter da;

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
        public bool Provjera()
        {
            if (ime.Length < 3 || ime.Length > 12)
            {
                MessageBox.Show("Ime mora sadržavati između 3 i 12 znakova!");
                return false;
            }
            if (prezime.Length < 3 || prezime.Length > 12)
            {
                MessageBox.Show("Prezime mora sadržavati između 3 i 12 znakova!");
                return false;
            }
            if (uName.Length < 5 || uName.Length > 12)
            {
                MessageBox.Show("Korisničko ime mora sadržavati između 5 i 12 znakova!");
                return false;
            }
            if (pass.Length < 6 || pass.Length > 20)
            {
                MessageBox.Show("Lozinka mora sadržavati između 5 i 20 znakova!");
                return false;
            }
            if (pass != passConf)
            {
                MessageBox.Show("Lozinka se moraju podudarati!");
                return false;
            }
            return true;
        }

        public bool uNameZauzet()
        {
            try
            {
                con.Open();
                string naredba = $"SELECT * FROM tb_Korisnik WHERE KorisnIme='{uName}'";
                cmd = new OleDbCommand(naredba, con);
                OleDbDataReader odg = cmd.ExecuteReader();
                if (odg.Read() == true)
                {
                    MessageBox.Show("Korisničko ime nije dostupno jer ga koristi drugi korinik!");
                    con.Close();
                    return true;
                }
                con.Close();

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
                return true;
            }
            return false;
        }

        public void noviKorisnik(Register reg)
        {
            try
            {
                con.Open();
                string naredba = $"INSERT INTO tb_Korisnik (Ime, Prezime, KorisnIme, Lozinka, JeAdmin) VALUES ('{ime}', '{prezime}', '{uName}', '{pass}', {0})";
                cmd = new OleDbCommand(naredba, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Registracija je bila uspješna!");
                reg.Hide();
                var Login = new Login();
                Login.Closed += (s, args) => reg.Close();
                Login.Show();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }
    }
}
