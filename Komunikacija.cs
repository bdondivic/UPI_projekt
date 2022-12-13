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
                    if (igra.naziv.ToUpper().StartsWith(txtPretraga.Text.ToUpper()))
                    {
                        lbIgre.Items.Add(igra.naziv);
                    }
                }
                else
                {
                    if (igra.naziv.ToUpper().StartsWith(txtPretraga.Text.ToUpper()) && (igra.id_zanr - 1 == cbZanr.SelectedIndex))
                    {
                        lbIgre.Items.Add(igra.naziv);
                    }
                }
            }
        }

        public void UcitajZanrove(ComboBox cbZanr)
        {
            con.Open();
            string naredba2 = $"SELECT * FROM tb_Zanr";
            cmd = new OleDbCommand(naredba2, con);
            OleDbDataReader odg = cmd.ExecuteReader();
            while (odg.Read())
            {
                cbZanr.Items.Add(odg.GetString(1));
            }
            con.Close();
        }

        public void UcitajOpis(RichTextBox rtbOpis, ComboBox cbZanr, string gameName)
        {
            rtbOpis.Clear();
            con.Open();
            string naredba = $"SELECT * from tb_Igra WHERE Naziv='{gameName.Replace("'","''")}'";
            cmd = new OleDbCommand(naredba, con);
            OleDbDataReader odg = cmd.ExecuteReader();
            odg.Read();

            rtbOpis.AppendText($"Naziv: {odg.GetString(1)}\n");
            rtbOpis.AppendText($"Platforma: {odg.GetString(2)}\n");
            rtbOpis.AppendText($"Godina: {odg.GetInt32(3)}\n");
            rtbOpis.AppendText($"Žanr: {cbZanr.Items[odg.GetInt32(4) - 1]}\n");
            rtbOpis.AppendText($"Izdavač: {odg.GetString(5)}\n");
            rtbOpis.AppendText($"NA sales: {odg.GetInt32(6) * 1000}\n");
            rtbOpis.AppendText($"EU sales: {odg.GetInt32(7) * 1000}\n");
            rtbOpis.AppendText($"JP sales: {odg.GetInt32(8) * 1000}\n");
            rtbOpis.AppendText($"Other sales: {odg.GetInt32(9) * 1000}\n");
            rtbOpis.AppendText($"Global sales: {odg.GetInt32(10) * 1000}\n");

            con.Close();
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
