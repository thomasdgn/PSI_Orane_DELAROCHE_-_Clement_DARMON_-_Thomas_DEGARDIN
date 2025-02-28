using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSI
{
    public partial class Visualisation : Form
    {
        private List<Noeud> noeuds;
        private List<Lien> liens;

        public Visualisation(List<Noeud> noeuds, List<Lien> liens)
        {
            this.noeuds = noeuds;
            this.liens = liens;
            this.Text = "Visualisation du Graphe";
            this.Size = new Size(800, 600);
            this.Paint += new PaintEventHandler(DessinerGraphe);
        }

        private void DessinerGraphe(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 2);
            Font font = new Font("Arial", 12);
            Brush brush = new SolidBrush(Color.Blue);

            foreach (var lien in liens)
            {
                g.DrawLine(pen, lien.Depart.Position, lien.Arrivee.Position);
            }

            foreach (var noeud in noeuds)
            {
                g.FillEllipse(brush, noeud.Position.X - 10, noeud.Position.Y - 10, 20, 20);
                g.DrawString(noeud.Id.ToString(), font, Brushes.White, noeud.Position.X - 5, noeud.Position.Y - 5);
            }
        }


        private void Visualisation_Load(object sender, EventArgs e)
        {
            // Cette méthode s'exécute lorsque la fenêtre se charge
            Console.WriteLine("Fenêtre de visualisation chargée.");
        }
    }
}
