using System;
using System.Windows.Forms;

namespace PSI
{
    /// <summary>
    /// Point d'entrée principal de l'application.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée de l'application Windows Forms.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Active les styles visuels pour une meilleure apparence de l'interface graphique
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Création du graphe et chargement des données depuis le fichier texte
            Graphe graphe = new Graphe();
            string cheminFichier = "soc-karate.txt"; // Chemin du fichier contenant les données du graphe
            graphe.ChargerLesDonneesDuFichier(cheminFichier);

            // Réorganisation des nœuds en cercle pour assurer un affichage équilibré
            graphe.OrganiserEnCercle();

            // Affichage du graphe dans une fenêtre graphique
            graphe.Afficher();
        }
    }
}
