using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Test;

namespace Backlog
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Register = new Register();
            Register.Closed += (s, args) => this.Close();
            Register.Show();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string uName = txtUsername.Text;
            string pass = txtPassword.Text;

            Prijava pr = new Prijava(uName, pass);

            bool isprPod = pr.Provjera();

            if (isprPod)
            {
                pr.otvoriAplikaciju(this);
            }
        }
    }
}
