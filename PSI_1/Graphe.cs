using PSI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;


namespace PSI
{
    public class Graphe
    {
        /// <summary>
        /// Liste des nœuds du graphe.
        /// </summary>
        private List<Noeud> noeuds;

        /// <summary>
        /// Liste des liens entre les nœuds.
        /// </summary>
        private List<Lien> liens;

        /// <summary>
        /// Dictionnaire représentant la liste d'adjacence du graphe.
        /// </summary>
        private Dictionary<int, List<int>> listeAdjacence;

        /// <summary>
        /// Matrice d'adjacence représentant les connexions entre nœuds.
        /// </summary>
        private int[,] matriceAdjacence;

        /// <summary>
        /// Constructeur Graphe.
        /// </summary>
        public Graphe()
        {
            noeuds = new List<Noeud>();
            liens = new List<Lien>();
            listeAdjacence = new Dictionary<int, List<int>>();
        }


        /// <summary>
        /// Propriétés pour accéder aux attributs du graphe.
        /// </summary>
        public List<Noeud> Noeuds { get { return noeuds; } }
        public List<Lien> Liens { get { return liens; } }
        public Dictionary<int, List<int>> ListeAdjacence { get { return listeAdjacence; } }
        public int[,] MatriceAdjacence { get { return matriceAdjacence; } }


        /// <summary>
        /// Ajoute un nœud au graphe.
        /// </summary>
        public void AjouterNoeud(int id)
        {
            if (listeAdjacence.ContainsKey(id) == false)
            {
                Noeud noeud = new Noeud(id, new Point(0, 0)); // Position temporaire
                noeuds.Add(noeud);
                listeAdjacence[id] = new List<int>();
            }
        }


        /// <summary>
        /// Ajoute un lien entre deux nœuds du graphe.
        /// </summary>
        public void AjouterLien(int id1, int id2)
        {
            Noeud noeud1 = noeuds.Find(n => n.Id == id1);
            Noeud noeud2 = noeuds.Find(n => n.Id == id2);

            if (noeud1 != null && noeud2 != null)
            {
                liens.Add(new Lien(noeud1, noeud2));
                listeAdjacence[id1].Add(id2);
                listeAdjacence[id2].Add(id1);
            }
        }


        /// <summary>
        /// Organise les nœuds en cercle pour une meilleure visualisation.
        /// </summary>
        public void OrganiserEnCercle()
        {
            int rayon = 250;
            int centreX = 400, centreY = 300;
            int nombreNoeuds = noeuds.Count;
            double angleIncrement = (2 * Math.PI) / nombreNoeuds;

            for (int i = 0; i < nombreNoeuds; i++)
            {
                int x = centreX + (int)(rayon * Math.Cos(i * angleIncrement));
                int y = centreY + (int)(rayon * Math.Sin(i * angleIncrement));
                noeuds[i] = new Noeud(noeuds[i].Id, new Point(x, y));
            }

            for (int i = 0; i < liens.Count; i++)
            {
                Noeud noeud1 = noeuds.Find(n => n.Id == liens[i].Depart.Id);
                Noeud noeud2 = noeuds.Find(n => n.Id == liens[i].Arrivee.Id);
                liens[i] = new Lien(noeud1, noeud2);
            }
        }


        /// <summary>
        /// Construit la matrice d'adjacence du graphe.
        /// </summary>
        public void ConstructionMatriceAdjacence()
        {
            int taille = noeuds.Count;
            matriceAdjacence = new int[taille, taille];

            foreach (var lien in liens)
            {
                int index1 = noeuds.FindIndex(n => n.Id == lien.Depart.Id);
                int index2 = noeuds.FindIndex(n => n.Id == lien.Arrivee.Id);

                matriceAdjacence[index1, index2] = 1;
                matriceAdjacence[index2, index1] = 1;
            }
        }


        /// <summary>
        /// Charge les données d'un fichier texte et remplit le graphe.
        /// </summary>
        public void ChargerLesDonneesDuFichier(string chemin)
        {
            foreach (string line in File.ReadLines(chemin))
            {
                if (line.Contains("("))
                {
                    string contenuParentheses = line.Substring(line.IndexOf("(") + 1, line.IndexOf(")") - line.IndexOf("(") - 1);
                    string[] parts = contenuParentheses.Split(',');

                    if (parts.Length == 2 && int.TryParse(parts[0].Trim(), out int id1) && int.TryParse(parts[1].Trim(), out int id2))
                    {
                        AjouterNoeud(id1);
                        AjouterNoeud(id2);
                        AjouterLien(id1, id2);
                    }
                }
            }
        }


        /// <summary>
        /// Effectue un parcours en largeur à partir d'un sommet donné.
        /// </summary>
        public void ParcoursLargeur(int sommetDepart)
        {
            if (listeAdjacence.ContainsKey(sommetDepart) == false) return;

            Queue<int> file = new Queue<int>();
            HashSet<int> visites = new HashSet<int>();

            file.Enqueue(sommetDepart);
            visites.Add(sommetDepart);

            while (file.Count > 0)
            {
                int sommet = file.Dequeue();
                Console.Write(sommet + " ");

                foreach (int voisin in listeAdjacence[sommet])
                {
                    if (visites.Contains(voisin) == false)
                    {
                        visites.Add(voisin);
                        file.Enqueue(voisin);
                    }
                }
            }
            Console.WriteLine();
        }


        /// <summary>
        /// Effectue un parcours en profondeur à partir d'un sommet donné.
        /// </summary>
        public void ParcoursProfondeur(int sommetDepart)
        {
            if (listeAdjacence.ContainsKey(sommetDepart) == false) return;

            Stack<int> pile = new Stack<int>();
            HashSet<int> visites = new HashSet<int>();

            pile.Push(sommetDepart);

            while (pile.Count > 0)
            {
                int sommet = pile.Pop();

                if (visites.Contains(sommet) == false)
                {
                    Console.Write(sommet + " ");
                    visites.Add(sommet);

                    foreach (int voisin in listeAdjacence[sommet])
                    {
                        if (visites.Contains(voisin) == false)
                        {
                            pile.Push(voisin);
                        }
                    }
                }
            }
            Console.WriteLine();
        }



        /// <summary>
        /// Vérifie si le graphe est connexe.
        /// </summary>
        public bool EstConnexe()
        {
            if (noeuds.Count == 0) return false;

            HashSet<int> visites = new HashSet<int>();
            Queue<int> file = new Queue<int>();

            int premierSommet = noeuds[0].Id;
            file.Enqueue(premierSommet);
            visites.Add(premierSommet);

            while (file.Count > 0)
            {
                int sommet = file.Dequeue();
                if (!listeAdjacence.ContainsKey(sommet)) continue;

                foreach (int voisin in listeAdjacence[sommet])
                {
                    if (!visites.Contains(voisin))
                    {
                        visites.Add(voisin);
                        file.Enqueue(voisin);
                    }
                }
            }

            return visites.Count == noeuds.Count;
        }



        /// <summary>
        /// Vérifie si le graphe contient un cycle.
        /// </summary>
        public bool ContientCycle()
        {
            HashSet<int> visites = new HashSet<int>();

            bool DFS(int sommet, int parent)
            {
                visites.Add(sommet);

                foreach (int voisin in listeAdjacence[sommet])
                {
                    if (!visites.Contains(voisin))
                    {
                        if (DFS(voisin, sommet)) return true;
                    }
                    else if (voisin != parent)
                    {
                        return true;
                    }
                }
                return false;
            }

            foreach (var noeud in noeuds)
            {
                if (!visites.Contains(noeud.Id))
                {
                    if (DFS(noeud.Id, -1)) return true;
                }
            }
            return false;
        }


        public int ObtenirOrdre() => noeuds.Count;
        public int ObtenirTaille() => liens.Count;



        /// <summary>
        /// Affiche le Windows Forms.
        /// </summary>
        public void Afficher()
        {
            Graphe graphe = new Graphe();
            Application.Run(new Visualisation(noeuds, liens, graphe));
        }
    }
}