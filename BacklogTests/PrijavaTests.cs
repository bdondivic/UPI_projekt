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
    public class PrijavaTests
    {
        [TestMethod()]
        public void KrivaLozinkaTest()
        {
            string user = "test123";
            string pass = "kriva_lozinka";

            Prijava p = new Prijava(user, pass);

            string expected = "Neispravna lozinka!";
            string actual = p.Provjera();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void KriviUsernameTest()
        {
            string user = "test1234";
            string pass = "test123";

            Prijava p = new Prijava(user, pass);

            string expected = "Ne postoji korisnik s tim korisničkim imenom!";
            string actual = p.Provjera();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PraznaPrijavaTest()
        {
            string user = "";
            string pass = "";

            Prijava p = new Prijava(user, pass);

            string expected = "Ne postoji korisnik s tim korisničkim imenom!";
            string actual = p.Provjera();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void UspjesnaPrijavaTest()
        {
            string user = "test123";
            string pass = "test123";
            
            Prijava p = new Prijava(user, pass);

            string expected = "Prijava OK!";
            string actual = p.Provjera();

            Assert.AreEqual(expected, actual);
        }
    }
}