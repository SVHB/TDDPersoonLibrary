using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDPersoonLibrary;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;

namespace TDDPersoonLibraryTest
{
    [TestClass]
    public class PersoonTest
    {
        private List<string> voornamen;
        
        [TestInitialize]
        public void Initialize()
        {
            voornamen = new List<string>();
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void EenPersoonZonderVoornaamIsNietCorrect()
        {
            new Persoon(null);
        }

        [TestMethod]
        public void EenPersoonMetEenVoornaamIsCorrect()
        {
            voornamen.Add("Jan");

            Assert.AreEqual(1, new Persoon(voornamen).ToString().Split(' ').Length);
        }

        [TestMethod]
        public void EenPersoonMetTweeVerschillendeVoornamenIsCorrect()
        {
            voornamen.Add("Jan");
            voornamen.Add("Piet");

            Assert.AreEqual(2, new Persoon(voornamen).ToString().Split(' ').Length);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void EenPersoonMetTweeDezelfdeVoornamenIsNietCorrect()
        {
            voornamen.Add("Jan");
            voornamen.Add("Jan");

            new Persoon(voornamen);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void ElkeVoornaamMoetMinstensEenTekenBevatten()
        {
            voornamen.Add("");

            new Persoon(voornamen);
        }

        [TestMethod]
        public void EenVoornaamBestaandeUitEenTekenIsCorrect()
        {
            voornamen.Add("A");

            new Persoon(voornamen);
        }

        [TestMethod]
        public void DeToStringLevertNamenOpGescheidenDoorEenSpatie()
        {
            voornamen.Add("Jan");
            voornamen.Add("Piet");

            Assert.AreEqual("Jan Piet", new Persoon(voornamen).ToString());
        }
    }
}
