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
        public int id;
        public string naziv;
        public string platforma;
        public int godina;
        public int id_zanr;
        public string izdavac;
        public int NA_sales;
        public int EU_sales;
        public int JP_sales;
        public int other_sales;
        public int global_sales;
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
    public class Pretraga
    {   
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataAdapter da;

        public Pretraga()
        {
            this.con = new OleDbConnection("Provider=Microsoft.Jet.OlEDB.4.0;Data Source=db_Backlog.mdb");
            this.cmd = new OleDbCommand();
            this.da = new OleDbDataAdapter();
        }

        public void Trazi(ListBox lbIgre, List<Igra> listIgre, ComboBox cbZanr, TextBox txtPretraga)
        {
            lbIgre.Items.Clear();
            foreach (Igra igra in listIgre)
            {
                if (cbZanr.SelectedIndex == -1)
                {
                    if (igra.naziv.StartsWith(txtPretraga.Text ))
                    {
                        lbIgre.Items.Add(igra.naziv);
                    }
                }
                else
                {
                    if (igra.naziv.StartsWith(txtPretraga.Text ) && (igra.id_zanr - 1 == cbZanr.SelectedIndex))
                    {
                        lbIgre.Items.Add(igra.naziv);
                    }
                }
            }
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

        }
    }
    
}
