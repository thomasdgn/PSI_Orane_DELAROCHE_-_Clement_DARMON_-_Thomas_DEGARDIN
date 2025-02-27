using PSI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Msagl.GraphViewerGdi;
using Microsoft.Msagl.Drawing;


namespace PSI
{
    public class Graphe
    {
        private Dictionary<int, Noeud> noeuds;
        private Graph graph;
        private GViewer viewer;
        private bool isConsoleMode;

        #region Propriété lecture/constructeur

        public Graphe(Panel panel)
        {
            noeuds = new Dictionary<int, Noeud>();
            graph = new Graph("Graphe des adhérents");
            viewer = new GViewer();
            isConsoleMode = false;

            viewer.Graph = graph;
            viewer.Dock = DockStyle.Fill;
            panel.Controls.Add(viewer);
        }

        public Graphe()
        {
            noeuds = new Dictionary<int, Noeud>();
            graph = new Graph("Graphe des adhérents");
            isConsoleMode = true;
        }
        public Dictionary<int, Noeud> Noeuds => noeuds;


        #endregion
        public Noeud AjouterNoeud(int id)
        {
            if (!noeuds.ContainsKey(id))
            {
                noeuds[id] = new Noeud(id);
                if (!isConsoleMode) // N'ajoute un nœud graphique que si ce n'est pas le mode console
                    graph.AddNode(id.ToString()).Attr.FillColor = Microsoft.Msagl.Drawing.Color.LightBlue;
            }
            return noeuds[id];
        }

        public void AjouterLien(int idSource, int idDestination, int poids = 1)
        {
            var source = AjouterNoeud(idSource);
            var destination = AjouterNoeud(idDestination);

            var lien = new Lien(source, destination, poids);
            source.liens.Add(lien);

            if (!isConsoleMode) // N'ajoute une arête graphique que si ce n'est pas le mode console
                graph.AddEdge(idSource.ToString(), idDestination.ToString()).Attr.Color = Microsoft.Msagl.Drawing.Color.Gray;
        }

        public void AfficherGraphe()
        {
            foreach (var noeud in noeuds.Values)
            {
                Console.WriteLine(noeud);

                foreach (var lien in noeud.liens)
                {
                    Console.WriteLine("  → " + lien.destination.id);
                }
            }
        }
        public void ConstruireDepuisFichier(string fichier)
        {
            string[] lignes = File.ReadAllLines(fichier);
            Regex regex = new Regex(@"\((\d+),\s*(\d+)\)");

            foreach (var ligne in lignes)
            {
                Match match = regex.Match(ligne);
                if (match.Success)
                {
                    int idSource = int.Parse(match.Groups[1].Value);
                    int idDestination = int.Parse(match.Groups[2].Value);

                    AjouterLien(idSource, idDestination);
                }
            }
        }

        public void MettreAJour()
        {
            if (!isConsoleMode) // Mise à jour graphique uniquement si c'est Windows Forms
            {
                viewer.Graph = graph;
                viewer.Invalidate();
            }
        }
    }
}