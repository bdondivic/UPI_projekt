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
    public class PretragaTests
    {
        [TestMethod()]
        public void UcitajZanroveTest()
        {
            List<string> zanrovi = new List<string> { "Action", "Adventure", "Fighting", "Misc", "Platform", "Puzzle", "Racing", "Role-Playing", "Shooter", "Simulation", "Sports", "Strategy" };
            PretragaIgara p = new PretragaIgara();
            List<string> zanroviTest = p.UcitajZanrove();

            CollectionAssert.AreEqual(zanrovi, zanroviTest);
        }
    }
}