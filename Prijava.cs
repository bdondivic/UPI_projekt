using Backlog;
using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Backlog
{
    public class Prijava
    {
        public OleDbConnection con { get; private set; }
        public OleDbCommand cmd { get; private set; }

        public string uName { get; private set; }
        public string pass { get; private set; }

        public int ID { get; private set; }

        public Prijava(string uName, string pass)
        {
            this.uName = uName;
            this.pass = pass;

            this.con = new OleDbConnection("Provider=Microsoft.Jet.OlEDB.4.0;Data Source=db_Backlog.mdb");
            this.cmd = new OleDbCommand();
        }

        //PROVJERA POSTOJANJA KORISNIKA I ISPRAVNOSTI LOZINKE
        public string Provjera()
        {
            try
            {
                con.Open();
                string naredba1 = $"SELECT * FROM tb_Korisnik WHERE KorisnIme='{uName}'";
                cmd = new OleDbCommand(naredba1, con);
                OleDbDataReader odg1 = cmd.ExecuteReader();
                if (odg1.Read() == false)
                {
                    con.Close();
                    return "Ne postoji korisnik s tim korisničkim imenom!";
                }
                string naredba2 = $"SELECT * FROM tb_Korisnik WHERE KorisnIme='{uName}' AND Lozinka='{pass}' ";
                cmd = new OleDbCommand(naredba2, con);
                OleDbDataReader odg2 = cmd.ExecuteReader();
                if (odg2.Read() == false)
                {
                    con.Close();
                    return "Neispravna lozinka!";
                }
                con.Close();
            }
            catch (Exception exp)
            {
                return exp.ToString();
            }
            return "Prijava OK!";
        }

        //OTVARANJE GLAVNE FORME (KORISNIK/ADMIN?)
        public string otvoriAplikaciju(Login log)
        {
            try
            {
                con.Open();
                string naredba = $"SELECT * FROM tb_Korisnik WHERE KorisnIme='{uName}' AND Lozinka='{pass}' ";
                cmd = new OleDbCommand(naredba, con);
                OleDbDataReader odg = cmd.ExecuteReader();
                odg.Read();
                ID = odg.GetInt32(0);
                string name = odg.GetString(1);
                string sur = odg.GetString(2);
                bool jeAdmin = bool.Parse(odg[5].ToString());
                if (jeAdmin)
                {
                    log.Hide();
                    var MainAdmin = new MainAdmin();
                    MainAdmin.Closed += (s, args) => log.Close();
                    MainAdmin.Show();
                    return "admin";
                }
                else
                {
                    log.Hide();
                    var MainUser = new MainUser(name, sur, uName, pass, ID);  /////////////NOVO
                    MainUser.Closed += (s, args) => log.Close();
                    MainUser.Show();
                    return "user";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return "Error";
            }


        }
    }


}
