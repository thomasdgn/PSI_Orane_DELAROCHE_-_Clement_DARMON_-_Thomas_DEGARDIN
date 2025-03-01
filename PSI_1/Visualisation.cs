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
    /// <summary>
    /// Fenêtre de visualisation du graphe avec affichage graphique et boutons d'interaction.
    /// </summary>
    public partial class Visualisation : Form
    {
        /// <summary>
        /// Liste des nœuds du graphe.
        /// </summary>
        private List<Noeud> noeuds;

        /// <summary>
        /// Liste des liens entre les nœuds du graphe.
        /// </summary>
        private List<Lien> liens;

        /// <summary>
        /// Bouton permettant de vérifier si le graphe est connexe.
        /// </summary>
        private Button btnConnexe;

        /// <summary>
        /// Bouton permettant de vérifier si le graphe contient des cycles.
        /// </summary>
        private Button btnCycles;

        /// <summary>
        /// Label affichant les résultats des tests sur le graphe.
        /// </summary>
        private Label lblResultat;

        /// <summary>
        /// Instance du graphe utilisé dans la visualisation.
        /// </summary>
        private Graphe graphe;

        /// <summary>
        /// Initialise une nouvelle instance de la fenêtre de visualisation.
        /// </summary>
        /// <param name="noeuds">Liste des nœuds du graphe.</param>
        /// <param name="liens">Liste des liens du graphe.</param>
        /// <param name="graphe">Instance du graphe pour les opérations.</param>
        public Visualisation(List<Noeud> noeuds, List<Lien> liens, Graphe graphe)
        {
            this.noeuds = noeuds;
            this.liens = liens;
            this.graphe = graphe;

            this.Text = "Visualisation du Graphe";
            this.Size = new Size(800, 600);
            this.Paint += new PaintEventHandler(DessinerGraphe);

            // Bouton de test de connectivité
            btnConnexe = new Button();
            btnConnexe.Text = "Connexe ?";
            btnConnexe.Location = new Point(75, 500);
            btnConnexe.Click += new EventHandler(BtnConnexe_Click);
            this.Controls.Add(btnConnexe);

            // Bouton de test de présence de cycles
            btnCycles = new Button();
            btnCycles.Text = "Cycles ?";
            btnCycles.Location = new Point(650, 500);
            btnCycles.Click += new EventHandler(BtnCycles_Click);
            this.Controls.Add(btnCycles);

            // Label d'affichage des résultats
            lblResultat = new Label();
            lblResultat.Size = new Size(300, 30);
            lblResultat.Location = new Point(325, 600);
            this.Controls.Add(lblResultat);
        }

        /// <summary>
        /// Gère l'événement de clic sur le bouton "Connexe ?".
        /// </summary>
        private void BtnConnexe_Click(object sender, EventArgs e)
        {
            bool estConnexe = graphe.EstConnexe();
            lblResultat.Text = estConnexe ? "Le graphe est connexe." : "Le graphe n'est pas connexe.";
        }

        /// <summary>
        /// Gère l'événement de clic sur le bouton "Cycles ?".
        /// </summary>
        private void BtnCycles_Click(object sender, EventArgs e)
        {
            bool contientCycle = graphe.ContientCycle();
            lblResultat.Text = contientCycle ? "Le graphe contient des cycles." : "Le graphe ne contient pas de cycles.";
        }

        /// <summary>
        /// Dessine le graphe à l'écran.
        /// </summary>
        private void DessinerGraphe(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 2);
            Font font = new Font("Arial", 12);
            Brush brush = new SolidBrush(Color.Blue);

            // Dessiner les liens
            foreach (var lien in liens)
            {
                g.DrawLine(pen, lien.Depart.Position, lien.Arrivee.Position);
            }

            // Dessiner les nœuds
            foreach (var noeud in noeuds)
            {
                g.FillEllipse(brush, noeud.Position.X - 10, noeud.Position.Y - 10, 20, 20);
                g.DrawString(noeud.Id.ToString(), font, Brushes.White, noeud.Position.X - 5, noeud.Position.Y - 5);
            }
        }

        /// <summary>
        /// Gère l'événement de chargement de la fenêtre.
        /// </summary>
        private void Visualisation_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Fenêtre de visualisation chargée.");
        }
    }
}