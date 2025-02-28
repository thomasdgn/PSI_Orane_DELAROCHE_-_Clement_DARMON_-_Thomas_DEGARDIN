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
        private List<Noeud> noeuds;
        private List<Lien> liens;
        private Dictionary<int, List<int>> listeAdjacence;
        private int[,] matriceAdjacence;

        public Graphe()
        {
            noeuds = new List<Noeud>();
            liens = new List<Lien>();
            listeAdjacence = new Dictionary<int, List<int>>();
        }



        public void AjouterNoeud(int id)
        {
            if (listeAdjacence.ContainsKey(id) == false)
            {
                Noeud noeud = new Noeud(id, new Point(0, 0)); // Position temporaire
                noeuds.Add(noeud);
                listeAdjacence[id] = new List<int>();
            }
        }


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


        public void Afficher()
        {
            Application.Run(new Visualisation(noeuds, liens));
        }
    }
}