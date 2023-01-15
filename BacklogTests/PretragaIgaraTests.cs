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
    public class PretragaIgaraTests
    {
        PretragaIgara p = new PretragaIgara();

        [TestMethod()]
        public void UcitajZanroveTest()
        {
            List<string> zanrovi = new List<string> { "Action", "Adventure", "Fighting", "Misc", "Platform", "Puzzle", "Racing", "Role-Playing", "Shooter", "Simulation", "Sports", "Strategy" };

            List<string> zanroviTest = p.UcitajZanrove();

            CollectionAssert.AreEqual(zanrovi, zanroviTest);
        }

        [TestMethod()]
        public void LoadIgreTest()
        {
            List<Igra> lista = p.LoadIgre();
            int actual = lista.Count();
            int expected = 11493;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void UcitajOpisTest()
        {
            List<object> expected = new List<object>();
            string naziv = "Tetris";

            expected.Add("Tetris");
            expected.Add("GB");
            expected.Add(1989);
            expected.Add(6);
            expected.Add("Nintendo");
            expected.Add(232000);
            expected.Add(226000);
            expected.Add(422000);
            expected.Add(58000);
            expected.Add(3026000);

            List<object> actual = p.UcitajOpis(naziv);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TraziTestZanr()
        {
            List<Igra> igre = new List<Igra>();
            List<Igra> expected = new List<Igra>();
            int index = 2;
            string text = "igra1";

            for (int i = 0; i < 20; i++)
            {
                Igra igra = new Igra(i, $"igra{i}", i%5);
                igre.Add(igra);
                if ((i == 1 || i / 10 == 1) && i % 5 == 2)
                    expected.Add(igra);
            }

            List<Igra> actual = p.Trazi(igre, index, text);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TraziTestBezZanra()
        {
            List<Igra> igre = new List<Igra>();
            List<Igra> expected = new List<Igra>();
            int index = -1;
            string text = "igra1";

            for (int i = 0; i < 20; i++)
            {
                Igra igra = new Igra(i, $"igra{i}", i % 5);
                igre.Add(igra);
                if (i == 1 || i / 10 == 1)
                    expected.Add(igra);
            }

            List<Igra> actual = p.Trazi(igre, index, text);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}