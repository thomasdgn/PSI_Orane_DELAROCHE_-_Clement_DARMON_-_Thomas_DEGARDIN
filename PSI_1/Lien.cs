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
            private Noeud depart;
            private Noeud arrivee;

            public Noeud Depart { get { return depart; } }
            public Noeud Arrivee { get { return arrivee; } }
            
            public Lien(Noeud depart, Noeud arrivee)
            {
                this.depart = depart;
                this.arrivee = arrivee;
            }
        }

    }