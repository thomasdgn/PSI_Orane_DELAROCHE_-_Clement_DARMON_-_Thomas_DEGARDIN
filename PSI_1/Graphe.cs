using PSI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace PSI
{
    public class Graphe
    {
        private Dictionary<int, Noeud> noeuds;

        #region Propriété lecture/constructeur

        public Graphe()
        {
            noeuds = new Dictionary<int, Noeud>();
        }
        public Dictionary<int, Noeud> Noeuds => noeuds;


        #endregion
        public Noeud AjouterNoeud(int id)
        {
            if (!noeuds.ContainsKey(id))
            {
                noeuds[id] = new Noeud(id);
            }
            return noeuds[id];
        }

        public void AjouterLien(int idSource, int idDestination, int poids)
        {
            var source = AjouterNoeud(idSource);
            var destination = AjouterNoeud(idDestination);

            var lien = new Lien(source, destination, poids);
            source.liens.Add(lien);
        }

        public void AfficherGraphe()
        {
            foreach (var noeud in noeuds.Values)
            {
                Console.WriteLine(noeud);

                foreach (var lien in noeud.liens)
                {
                    Console.WriteLine(" ");
                }
            }
        }
        public void ConstruireDepuisFichier(string fichier)
        {
            string[] lignes = File.ReadAllLines(fichier);
            foreach (var ligne in lignes)
            {
                var parties = ligne.Split(';');
                AjouterLien(int.Parse(parties[0]), int.Parse(parties[1]), int.Parse(parties[2]));
            }
        }
    }
}