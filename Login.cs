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
        public Prijava pr { get; private set; }
        public Login()
        {
            InitializeComponent();
        }

        private void Prijava()
        {
            string uName = txtUsername.Text;
            string pass = txtPassword.Text;

            pr = new Prijava(uName, pass);

            string isprPod = pr.Provjera();

            if (isprPod == "Prijava OK!")
                pr.otvoriAplikaciju(this);
            else
                MessageBox.Show(isprPod);
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
            Prijava();
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Prijava(); 
            }
        }
    }
}
