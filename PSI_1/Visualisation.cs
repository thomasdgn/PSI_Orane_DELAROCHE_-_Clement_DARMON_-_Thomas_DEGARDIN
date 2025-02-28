using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PSI
{
    public partial class Form1 : Form
    {
        private Graphe graphe;

        public Form1()
        {
            InitializeComponent();

            // Vérifie que panelGraph est bien ajouté
            if (panelGraph == null)
            {
                MessageBox.Show("Erreur : panelGraph est introuvable !");
                return;
            }

            // Initialisation du graphe avec le Panel
            graphe = new Graphe(panelGraph);

            // Charger les données depuis le fichier
            try
            {
                ChargerDepuisFichier("soc-karate (2).txt");
                panelGraph.Paint += new PaintEventHandler((sender, e) => graphe.MettreAJour());
                panelGraph.Invalidate(); // Forcer le rafraîchissement
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement du fichier : " + ex.Message);
            }
        }


        private void ChargerDepuisFichier(string fichier)
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
                    graphe.AjouterLien(idSource, idDestination);
                }
            }
        }
    }
}

