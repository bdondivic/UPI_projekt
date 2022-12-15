using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using Backlog;

namespace Test
{
    public class Prijava
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataAdapter da;

        public string uName { get; private set; }
        public string pass { get; private set; }

        public Prijava(string uName, string pass)
        {
            this.uName = uName;
            this.pass = pass;

            this.con = new OleDbConnection("Provider=Microsoft.Jet.OlEDB.4.0;Data Source=db_Backlog.mdb");
            this.cmd = new OleDbCommand();
            this.da = new OleDbDataAdapter();
        }

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

        public void otvoriAplikaciju(Login log)
        {
            try
            {
                con.Open();
                string naredba = $"SELECT * FROM tb_Korisnik WHERE KorisnIme='{uName}' AND Lozinka='{pass}' ";
                cmd = new OleDbCommand(naredba, con);
                OleDbDataReader odg = cmd.ExecuteReader();
                odg.Read();
                bool jeAdmin = bool.Parse(odg[5].ToString());
                if (jeAdmin)
                {
                    log.Hide();
                    var MainAdmin = new MainAdmin();
                    MainAdmin.Closed += (s, args) => log.Close();
                    MainAdmin.Show();
                }
                else
                {
                    log.Hide();
                    var MainUser = new MainUser();
                    MainUser.Closed += (s, args) => log.Close();
                    MainUser.Show();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            
        }
    }

    
}
