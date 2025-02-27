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
            private Noeud Source;
            private Noeud Destination;
            private int Poids;

            #region Propriété constructeur/lecture/écriture

            public Lien(Noeud source, Noeud destination, int poids)
            {
                this.Source = source;
                this.Destination = destination;
                this.Poids = poids;
            }
            public Noeud source
            {
                get
                {
                    return this.Source;
                }
            }

            public Noeud destination
            {
                get
                {
                    return this.Destination;
                }
            }

            public string ToString()
            {
                return $"Lien entre {source.id} et {destination.id} avec poids {Poids}"; 
            }

            #endregion


        }

    }