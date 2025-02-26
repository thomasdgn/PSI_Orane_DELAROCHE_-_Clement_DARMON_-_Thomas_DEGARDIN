using PSI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI
{
    public class Graphe
    {
        private List<Noeud> noeuds;
        private List<Lien> liens;

        #region Propriété lecture/constructeur

        public Graphe(List<Noeud> noeuds, List<Lien> liens)
        {
            this.noeuds = noeuds;
            this.liens = liens;

        }
        public List<Lien> Liens
        {
            get
            {
                return this.liens;
            }
        }

        public List<Noeud> Noeuds
        {
            get
            {
                return this.noeuds;
            }
        }
        #endregion
    }
}
