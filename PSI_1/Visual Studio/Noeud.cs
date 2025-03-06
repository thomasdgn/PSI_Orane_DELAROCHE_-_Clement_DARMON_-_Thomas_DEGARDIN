using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI
{
    /// <summary>
    /// Représente un nœud dans un graphe.
    /// </summary>
    public class Noeud
    {
        /// <summary>
        /// Identifiant unique du nœud.
        /// </summary>
        private int id;

        /// <summary>
        /// Position du nœud pour l'affichage graphique.
        /// </summary>
        private Point position;

        /// <summary>
        /// Obtient l'identifiant du nœud.
        /// </summary>
        public int Id { get { return id; } }

        /// <summary>
        /// Obtient la position du nœud.
        /// </summary>
        public Point Position { get { return position; } }

        /// <summary>
        /// Initialise une nouvelle instance de la classe Noeud.
        /// </summary>
        /// <param name="id">L'identifiant unique du nœud.</param>
        /// <param name="position">La position du nœud dans l'espace graphique.</param>
        public Noeud(int id, Point position)
        {
            this.id = id;
            this.position = position;
        }
    }
}
