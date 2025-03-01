using PSI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI
{
    /// <summary>
    /// Représente un lien entre deux nœuds dans un graphe.
    /// </summary>
    public class Lien
    {
        /// <summary>
        /// Nœud de départ du lien.
        /// </summary>
        private Noeud depart;

        /// <summary>
        /// Nœud d'arrivée du lien.
        /// </summary>
        private Noeud arrivee;

        /// <summary>
        /// Obtient le nœud de départ du lien.
        /// </summary>
        public Noeud Depart { get { return depart; } }

        /// <summary>
        /// Obtient le nœud d'arrivée du lien.
        /// </summary>
        public Noeud Arrivee { get { return arrivee; } }

        /// <summary>
        /// Initialise une nouvelle instance de la classe Lien entre deux nœuds.
        /// </summary>
        /// <param name="depart">Le nœud de départ du lien.</param>
        /// <param name="arrivee">Le nœud d'arrivée du lien.</param>
        public Lien(Noeud depart, Noeud arrivee)
        {
            this.depart = depart;
            this.arrivee = arrivee;
        }
    }
}