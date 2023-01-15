using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Backlog.Tests
{
    [TestClass()]
    public class KorisnikTests
    {

        [TestMethod()]
        public void korStatistikaTest()
        {
            Korisnik k = new Korisnik("test123", "test123", "test123", "test123", 24);

            List<string> expected = new List<string>();
            expected.Add("Backlog: 0");
            expected.Add("Igram: 0");
            expected.Add("Igrao: 0");
            expected.Add("Postotak odigranih: 0%");
            expected.Add("Ukupno vrijeme igranja: 0h");

            List<string> actual = k.korStatistika();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void promijeniPassTest()
        {
            Korisnik k = new Korisnik("test1", "test1", "test1", "test1", 34);

            string newPass = "test2";

            string expected = "Loznika je uspješno izmijenjena!";
            string actual = k.promijeniPass(newPass);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void izbrisiRacunTest()
        {
            Korisnik k = new Korisnik("test", "test", "test", "test", 60);

            string expected = "Račun je uspješno izbrisan!";
            string actual = k.izbrisiRacun();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void obrisiZapisTest()
        {
            Korisnik k = new Korisnik("test", "test", "test", "test", 60);

            bool OK = k.obrisiZapis(60);

            Assert.IsTrue(OK);
        }

        [TestMethod()]
        public void postojiZapisTest()
        {
            Korisnik k = new Korisnik("Ivan", "Marić", "imaric13", "Split1911", 1);

            string expected = "Zapis sa obabranom igrom već postoji!";

            string actual = k.postojiZapis("Wii Sports");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void postojiZapisGreska()
        {
            Korisnik k = new Korisnik("test", "test", "test", "test", 60);

            string expected = "Došlo je do greške";

            string actual = k.postojiZapis("Assassin's Creed");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void nePostojiZapisTest()
        {
            Korisnik k = new Korisnik("test", "test", "test", "test", 60);

            string expected = "Zapis sa obabranom igrom već postoji!";

            string actual = k.postojiZapis("Assass Creed");

            Assert.AreNotEqual(expected, actual);
        }
    }
}