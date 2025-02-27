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
    public partial class Form1 : Form
    {
        private Graphe graphe;

        public Form1()
        {
            InitializeComponent();

            // Vérifie que panelGraph est bien ajouté dans le designer
            if (panelGraph == null)
            {
                MessageBox.Show("Erreur : panelGraph est introuvable. Vérifiez qu'il est bien ajouté dans le formulaire.");
                return;
            }

            // Initialisation du graphe dans le panel
            graphe = new Graphe(panelGraph);

            // Charger les données depuis le fichier
            graphe.ConstruireDepuisFichier("soc-karate (2).txt");

            // Mettre à jour l'affichage
            graphe.MettreAJour();

        }
    }
}
