using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using PSI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace PSI
{
    [TestClass]
    public class UnitTest1
    {

        #region Test Unitaire de la classe Graphe



        /// <summary>
        /// Test de la méthode ObtenirOrdre de la classe Graphe
        /// </summary>
        /// 
        [TestMethod]
        public void TestMethod_ObtenirOrdre()
        {
            Graphe graphe = new Graphe();
            graphe.AjouterNoeud(1);
            graphe.AjouterNoeud(2);
            Assert.AreEqual(2, graphe.ObtenirOrdre());
        }

        /// <summary>
        /// Test de la méthode ObtenirTaille de la classe Graphe
        /// </summary>
        /// 
        [TestMethod]
        public void TestMethod_ObtenirTaille()
        {
            Graphe graphe = new Graphe();
            graphe.AjouterNoeud(1);
            graphe.AjouterNoeud(2);
            graphe.AjouterNoeud(3);

            graphe.AjouterLien(1, 2);
            graphe.AjouterLien(1, 3);

            Assert.AreEqual(2, graphe.ObtenirTaille());
        }

        /// <summary>
        /// Test de la méthode AjouterNoeud de la classe Graphe
        /// </summary>
        /// 
        [TestMethod]
        public void TestMethod_AjouterNoeud()
        {
            Graphe graphe = new Graphe(); 

            int a = 1;
            graphe.AjouterNoeud(a);

            Assert.AreEqual(1, graphe.ObtenirOrdre());
        }

        /// <summary>
        /// Test de la méthode AjouterLien de la classe Graphe
        /// </summary>
        /// 
        [TestMethod]
        public void TestMethod_AjouterLien()
        {   
            Graphe graphe = new Graphe();
            graphe.AjouterNoeud(1);
            graphe.AjouterNoeud(2);
            graphe.AjouterLien(1, 2);
            Assert.AreEqual(1, graphe.ObtenirTaille());
        }

        #endregion
    }
}
