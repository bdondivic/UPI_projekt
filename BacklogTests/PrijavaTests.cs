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

            bool OK = p.Provjera();
            Assert.IsFalse(OK);
        }

        [TestMethod()]
        public void KriviUsernameTest()
        {
            string user = "test1234";
            string pass = "test123";

            Prijava p = new Prijava(user, pass);

            bool OK = p.Provjera();
            Assert.IsFalse(OK);
        }

        [TestMethod()]
        public void PraznaPrijavaTest()
        {
            string user = "";
            string pass = "test123";

            Prijava p = new Prijava(user, pass);

            bool OK = p.Provjera();
            Assert.IsFalse(OK);
        }

        [TestMethod()]
        public void UspjesnaPrijavaTest()
        {
            string user = "test123";
            string pass = "test123";
            
            Prijava p = new Prijava(user, pass);

            bool OK = p.Provjera();
            Assert.IsTrue(OK);
        }
    }
}