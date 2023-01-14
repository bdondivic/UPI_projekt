using System;
using System.Windows.Forms;

namespace Backlog
{
    public partial class Register : Form
    {
        public Registracija reg { get; private set; }
        public Register()
        {

            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            string ime = txtName.Text.Trim();
            string prezime = txtSurname.Text.Trim();
            string uName = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();
            string passConf = txtConfirmPass.Text.Trim();
            reg = new Registracija(ime, prezime, uName, pass, passConf);


            string isprPod = reg.Provjera();

            if (isprPod == "Registracija je bila uspješna!")
            {
                if (reg.uNameZauzet() != "Username OK!")
                {
                    MessageBox.Show(reg.uNameZauzet());
                    return;
                }
                if (reg.noviKorisnik())
                {
                    MessageBox.Show(isprPod);
                    this.Hide();
                    var Login = new Login();
                    Login.Closed += (s, args) => this.Close();
                    Login.Show();
                }
            }
            else
                MessageBox.Show(isprPod);
        }

        private void cb_showPass_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_showPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtConfirmPass.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
                txtConfirmPass.PasswordChar = '*';
            }
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Login = new Login();
            Login.Closed += (s, args) => this.Close();
            Login.Show();

        }
    }
}
