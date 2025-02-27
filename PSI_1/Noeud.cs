using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI
{
    public class Noeud
    {
        private int Id;

        List<Lien> Liens;

        #region Propriété constructeur/écriture/lecture

        public Noeud(int id)
        {
            this.Id = id;
            this.Liens = new List<Lien>();

        }

        public int id
        {
            get
            {
                return this.Id;
            }
        }

        public List<Lien> liens
        {
            get
            {
                return this.Liens;
            }
        }

        #endregion

        public override string ToString()
        {
            return $"Noeud {Id}";
        }

        public void AjouterVoisin(Lien a)
        {
            if (!liens.Contains(a))
            {
                liens.Add(a);
            }
        }


    }
}