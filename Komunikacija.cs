using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using Backlog;

namespace Backlog
{
    public class Igra
    {
        int id;
        string naziv;
        string platforma;
        int godina;
        int id_zanr;
        string izdavac;
        int NA_sales;
        int EU_sales;
        int JP_sales;
        int other_sales;
        int global_sales;
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
    public class Komunikacija
    {   
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataAdapter da;

        public Komunikacija()
        {
            this.con = new OleDbConnection("Provider=Microsoft.Jet.OlEDB.4.0;Data Source=db_Backlog.mdb");
            this.cmd = new OleDbCommand();
            this.da = new OleDbDataAdapter();
        }

        public List<Igra> LoadIgre(ListBox lb)
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
                string platforma= reader.GetString(2); 
                int godina =reader.GetInt32(3);
                int id_zanr = reader.GetInt32(4);
                string izdavac= reader.GetString(5);
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

            //string naredba2 = $"SELECT * FROM tb_Zanr";
            //cmd = new OleDbCommand(naredba2, con);
            //OleDbDataReader odg = cmd.ExecuteReader();
            //while (odg.Read())
            //{
            //    cbZanr.Items.Add(odg.GetString(1));
            //}
            //con.Close();
        }
    }
    
}
