using System;
using System.Windows.Forms;

namespace PSI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Création du graphe et chargement des données depuis le fichier texte
            Graphe graphe = new Graphe();
            string cheminFichier = "soc-karate.txt";
            graphe.ChargerLesDonneesDuFichier(cheminFichier);

            // Réorganisation des nœuds en cercle pour un écart similaire entre chaque point
            graphe.OrganiserEnCercle();

            // Affichage du graphe
            graphe.Afficher();
        }
    }
}