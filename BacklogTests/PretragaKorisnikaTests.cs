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
    public class PretragaKorisnikaTests
    {
        PretragaKorisnika p = new PretragaKorisnika();

        [TestMethod()]
        public void TraziTest()
        {
            List<Korisnik> korisnici = new List<Korisnik>();
            List<Korisnik> expected = new List<Korisnik>();
            string text = "user1";

            for (int i = 0; i < 20; i++)
            {
                Korisnik k = new Korisnik("user", "user", $"user{i}", "pass", i);
                korisnici.Add(k);
                if (i == 1 || i / 10 == 1)
                    expected.Add(k);
            }

            List<Korisnik> actual = p.Trazi(korisnici, text);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ucitajKorisnikeTest()
        {
            int expected = 5; 

            List<Korisnik> korisnici = p.ucitajKorisnike();
            int actual = korisnici.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ucitajInfTest()
        {
            List<object> expected = new List<object>();
            string uname = "imaric13";

            expected.Add("Ivan");
            expected.Add("Marić");
            expected.Add("imaric13");
            expected.Add("Split1911");
            expected.Add("09/11/2022");
            expected.Add("15/01/2023");
            expected.Add("0");
            expected.Add("2");
            expected.Add("3");

            List<object> actual = p.ucitajInf(uname);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}