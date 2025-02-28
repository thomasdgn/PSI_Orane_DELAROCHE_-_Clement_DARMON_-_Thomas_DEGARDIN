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
        private Button btnConnexe;
        private Button btnCycles;
        private Label lblResultat;
        private Graphe graphe;

        public Visualisation(List<Noeud> noeuds, List<Lien> liens, Graphe graphe)
        {
            this.noeuds = noeuds;
            this.liens = liens;
            this.graphe = graphe;

            this.Text = "Visualisation du Graphe";
            this.Size = new Size(800, 600);
            this.Paint += new PaintEventHandler(DessinerGraphe);

            btnConnexe = new Button();
            btnConnexe.Text = "Connexe ?";
            btnConnexe.Location = new Point(75, 500);
            btnConnexe.Click += new EventHandler(BtnConnexe_Click);
            this.Controls.Add(btnConnexe);

            btnCycles = new Button();
            btnCycles.Text = "Cycles ?";
            btnCycles.Location = new Point(650, 500);
            btnCycles.Click += new EventHandler(BtnCycles_Click);
            this.Controls.Add(btnCycles);

            lblResultat = new Label();
            lblResultat.Size = new Size(300, 30);
            lblResultat.Location = new Point(325, 600);
            this.Controls.Add(lblResultat);
        }


        private void BtnConnexe_Click(object sender, EventArgs e)
        {
            bool estConnexe = graphe.EstConnexe();
            lblResultat.Text = estConnexe ? "Le graphe est connexe." : "Le graphe n'est pas connexe.";
        }

        private void BtnCycles_Click(object sender, EventArgs e)
        {
            bool contientCycle = graphe.ContientCycle();
            lblResultat.Text = contientCycle ? "Le graphe contient des cycles." : "Le graphe ne contient pas de cycles.";
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
