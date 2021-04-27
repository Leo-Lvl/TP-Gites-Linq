using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cfGites;

namespace gites
{
    class Program
    {
        static void Main(string[] args)
        {
            ModelesGites bd = new ModelesGites();
            bool isLooping = true;
            while (isLooping) {
                Console.Clear();
                Console.WriteLine("0. Quitter\n1. Afficher les clients\n2. Afficher le nom des gites qui ont plus de 2 épis\n3. Afficher le nom et la ville des gites qui ont plus de 2 épis\n4. Afficher les gites réservés par le client CAMUS");
                switch (Console.ReadLine()) {
                    case "0":
                        isLooping = false;
                        break;
                    case "1":
                        foreach (client cl in bd.clients) {
                            Console.WriteLine(cl.nomClient);
                        }
                        break;
                    case "2":
                        IEnumerable<string> r1 = from gite in bd.gites where gite.nbEpis > 2 orderby gite.nomGite select gite.nomGite;
                        foreach (string nom in r1) {
                            Console.WriteLine(nom);
                        }
                        break;
                    case "3":
                        var req = from gite in bd.gites where gite.nbEpis > 2 orderby gite.nomGite select new { gite.nomGite, gite.villeGite };
                        foreach (var g in req) {
                            Console.WriteLine(String.Format("{0} {1}", g.nomGite, g.villeGite));
                        }
                        break;
                    case "4":
                        var r3 = from git in bd.gites
                                 join plan in bd.plannings on git.numGite equals plan.numGite
                                 join ctr in bd.contrats on plan.numContrat equals ctr.numContrat
                                 join cli in bd.clients on ctr.numClient equals cli.numClient
                                 where cli.nomClient == "CAMUS"
                                 select new { git.nomGite, git.villeGite, ctr.numContrat, plan.numSemaine };
                        foreach (var obj in r3) {
                            Console.WriteLine("Gites loués par CAMUS {0} \t {1} contrat n°{2} pour la semaine n°{3}", obj.nomGite, obj.villeGite, obj.numContrat, obj.numSemaine);
                        }
                        break;
                    default:
                        break;
                }
                Console.Read();
            }

        }
    }
}
