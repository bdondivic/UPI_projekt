using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Tests
{
    [TestClass()]
    public class RegistracijaTests
    {
        [TestMethod()]
        public void RegistracijaOK()
        {
            string ime = "ime";
            string prezime = "prezime";
            string user = "username";
            string pass = "password";
            string pass2 = "password";

            Registracija reg = new Registracija(ime, prezime, user, pass, pass2);

            bool OK = reg.Provjera();

            Assert.IsTrue(OK);
        }

        [TestMethod()]
        public void PraznoImeGreska()
        {
            string ime = "";
            string prezime = "prezime";
            string user = "username";
            string pass = "password";
            string pass2 = "password";

            Registracija reg = new Registracija(ime, prezime, user, pass, pass2);

            bool OK = reg.Provjera();

            Assert.IsFalse(OK);
        }

        [TestMethod()]
        public void UsernameGreska()
        {
            string ime = "ime";
            string prezime = "prezime";
            string user = "a";
            string pass = "password";
            string pass2 = "password";

            Registracija reg = new Registracija(ime, prezime, user, pass, pass2);

            bool OK = reg.Provjera();

            Assert.IsFalse(OK);
        }

        [TestMethod()]
        public void KrivaLozinka()
        {
            string ime = "ime";
            string prezime = "prezime";
            string user = "username";
            string pass = "password";
            string pass2 = "passsword";

            Registracija reg = new Registracija(ime, prezime, user, pass, pass2);

            bool OK = reg.Provjera();

            Assert.IsFalse(OK);
        }

        [TestMethod()]
        public void uNameZauzetTest()
        {
            string ime1 = "ime";
            string prezime1 = "prezime";
            string user1 = "test123";
            string pass1 = "password";
            string passConf1 = "password";

            Registracija reg1 = new Registracija(ime1, prezime1, user1, pass1, passConf1);

            bool OK = reg1.uNameZauzet();
            Assert.IsTrue(OK);
        }

        [TestMethod()]
        public void uNameNijeZauzetTest()
        {
            string ime2 = "ime";
            string prezime2 = "prezime";
            string user2 = "username2";
            string pass2 = "password";
            string passConf2 = "password";

            Registracija reg2 = new Registracija(ime2, prezime2, user2, pass2, passConf2);

            bool OK = reg2.uNameZauzet();
            Assert.IsFalse(OK);
        }
    }
}