using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpGites
{
    public class Requetes
    {
        private List<string> requete;

        public Requetes(string libelle, List<string> requete)
        {
            this.Libelle = libelle;
            this.requete = requete;
        }

        public string Libelle { get; set; }
    }
}
