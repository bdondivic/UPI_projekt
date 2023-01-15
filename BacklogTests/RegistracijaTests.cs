using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog.Tests
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

            string expected = "Registracija je bila uspješna!";
            string actual = reg.Provjera();

            Assert.AreEqual(expected, actual);
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

            string expected = "Ime mora sadržavati između 3 i 12 znakova!";
            string actual = reg.Provjera();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PraznoPrezimeGreska()
        {
            string ime = "ime";
            string prezime = "";
            string user = "username";
            string pass = "password";
            string pass2 = "password";

            Registracija reg = new Registracija(ime, prezime, user, pass, pass2);

            string expected = "Prezime mora sadržavati između 3 i 12 znakova!";
            string actual = reg.Provjera();

            Assert.AreEqual(expected, actual);
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

            string expected = "Korisničko ime mora sadržavati između 5 i 12 znakova!";
            string actual = reg.Provjera();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RazliciteLozinkeTest()
        {
            string ime = "ime";
            string prezime = "prezime";
            string user = "username";
            string pass = "password";
            string pass2 = "passsword";

            Registracija reg = new Registracija(ime, prezime, user, pass, pass2);

            string expected = "Lozinke se moraju podudarati!";
            string actual = reg.Provjera();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void uNameZauzetTest()
        {
            string ime = "ime";
            string prezime = "prezime";
            string user = "test123";
            string pass = "password";
            string pass2 = "password";

            Registracija reg = new Registracija(ime, prezime, user, pass, pass2);

            string expected = "Korisničko ime nije dostupno jer ga koristi drugi korinik!";
            string actual = reg.uNameZauzet();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void uNameNijeZauzetTest()
        {
            string ime = "ime";
            string prezime = "prezime";
            string user = "username2";
            string pass = "password";
            string pass2 = "password";

            Registracija reg = new Registracija(ime, prezime, user, pass, pass2);

            string expected = "Username OK!";
            string actual = reg.uNameZauzet();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void noviKorisnikTest()
        {
            string ime = "ime";
            string prezime = "prezime";
            string user = "username";
            string pass = "password";
            string pass2 = "passsword";

            Registracija reg = new Registracija(ime, prezime, user, pass, pass2);

            bool OK = reg.noviKorisnik();
            Assert.IsTrue(OK);
        }
    }
}