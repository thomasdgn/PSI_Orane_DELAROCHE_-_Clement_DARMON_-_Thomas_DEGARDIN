using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI
{
    public class Noeud
    {
        private int numero;

        List<Noeud> voisins;

        #region Propriété lecture/constructeur

        public Noeud(int numero)
        {
            this.numero = numero;
            this.voisins = new List<Noeud>();

        }
        public int Numero
        {
            get
            {
                return this.numero;
            }
        }

        public List<Noeud> Voisins
        {
            get
            {
                return this.voisins;
            }
        }
        #endregion
        public void AjouterVoisin(Noeud a)
        {
            if (!Voisins.Contains(a))
            {
                Voisins.Add(a);
            }
        }

    }
}
