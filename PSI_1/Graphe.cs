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
        private Dictionary<int, Noeud> noeuds;
        private Panel panel;
        private bool isConsoleMode;

        #region Propriété lecture/constructeur

        public Graphe(Panel panel)
        {

            noeuds = new Dictionary<int, Noeud>();
            this.panel = panel;
            isConsoleMode = false;
            panel.Paint += new PaintEventHandler(DessinerGraphe);

        }

        public Graphe()
        {
            noeuds = new Dictionary<int, Noeud>();
            isConsoleMode = true;
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

        public void AjouterLien(int idSource, int idDestination, int poids = 1)
        {
            var source = AjouterNoeud(idSource);
            var destination = AjouterNoeud(idDestination);

            var lien = new Lien(source, destination, poids);
            source.liens.Add(lien);

        }

        public void MettreAJour()
        {
            if (!isConsoleMode) // Mise à jour graphique uniquement si c'est Windows Forms
            {
                panel.Invalidate();
            }
        }


        private void DessinerGraphe(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            Dictionary<int, Point> positions = new Dictionary<int, Point>();
            Random rand = new Random();

            foreach (var noeud in noeuds.Values)
            {
                positions[noeud.id] = new Point(rand.Next(50, panel.Width - 50), rand.Next(50, panel.Height - 50));
            }

            foreach (var noeud in noeuds.Values)
            {
                foreach (var lien in noeud.liens)
                {
                    Point p1 = positions[lien.source.id];
                    Point p2 = positions[lien.destination.id];
                    g.DrawLine(Pens.Gray, p1, p2);
                }
            }

            foreach (var noeud in noeuds.Values)
            {
                Point pos = positions[noeud.id];
                g.FillEllipse(Brushes.LightBlue, pos.X - 10, pos.Y - 10, 20, 20);
                g.DrawEllipse(Pens.Black, pos.X - 10, pos.Y - 10, 20, 20);
                g.DrawString(noeud.id.ToString(), SystemFonts.DefaultFont, Brushes.Black, pos.X - 5, pos.Y - 5);
            }

        }

    }
}