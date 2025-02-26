using PSI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI
{
    public class Lien
    {
        public Noeud a;
        private Noeud b;

        #region Propriété lecture/constructeur

        public Lien(Noeud a, Noeud b)
        {
            this.a = a;
            this.b = b;

        }
        public Noeud A
        {
            get
            {
                return this.a;
            }
        }

        public Noeud B
        {
            get
            {
                return this.b;
            }
        }
        #endregion
    }
}
