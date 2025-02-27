using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var graphe = new Graphe();
            graphe.ConstruireDepuisFichier("soc-karate (2).txt");

            Console.WriteLine("Affichage du graphe :");
            graphe.AfficherGraphe();

        }
    }
}