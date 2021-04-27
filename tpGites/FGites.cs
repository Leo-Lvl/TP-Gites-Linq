using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cfGites;

namespace tpGites
{
    public partial class FGites : Form
    {
        List<string> requetes;
        ModelesGites bd = new ModelesGites();

        public FGites()
        {
            InitializeComponent();
            this.requetes = new List<string>() {
                "Requête 0 : Liste des gîtes",
                "Requête 1 : Tarifs des gîtes",
                "Requête 2 : Liste des contrats annulés",
                "Requête 3 : Montant du chiffre d'affaires réalisé par client",
                "Requête 4 : Montant total de chaque contrat",
                "Requête 5 : Liste des clients (nom, prénom) qui ont loué au moins un gîte",
                "Requête 6 : Liste des clients qui ont loué plus de 3 gîtes",
                "Requête 7 : Liste des clients qui ont loué un gîte à la fois en période 1 et en période 2",
                "Requête 8 : Nom et prénom du(des client(s) qui a(ont) signé le plus de contrats",
                "Requête 9 : Liste des gites qui n'ont jamais été loués",
                "Requête 10 : Donner le contrat(n° et nom de client) qui représente le plus gros montant",
                "Requête 11 : Donner la liste des clients qui ont loué chaque gîte au moins une fois",
                "Requête 12 : Donner les villes dont le chiffre d'affires réalisé est supérieur à celui de la ville de Sommières"};
            this.cb_requetes.DataSource = this.requetes;
        }

        private void btn_lancerRequetes_Click(object sender, EventArgs e)
        {
            this.lancerRequete(this.cb_requetes.Text);
        }

        public void lancerRequete(string requete)
        {
            this.rtb_resultat.Text = String.Empty;
            switch (requete) {
                case "Requête 0 : Liste des gîtes":
                    var listeGites = from gite in bd.gites select new { gite.numGite, gite.nomGite, gite.villeGite };
                    foreach (var o in listeGites) {
                        this.rtb_resultat.Text += String.Format("Numéro de gîte: {0}  Nom du gîte: {1}  Ville: {2}\n", o.numGite, o.nomGite, o.villeGite);
                    }
                    break;
                case "Requête 1 : Tarifs des gîtes":
                    var tarifsGites = from gite in bd.gites join tarif in bd.tarifs on gite.numGite equals tarif.numGite select new { gite.numGite, gite.nomGite, tarif.prixSemaine };
                    foreach (var o in tarifsGites) {
                        this.rtb_resultat.Text += String.Format("Numéro de gîte: {0}  Nom du gîte: {1}  Tarif par semaine: {2}\n", o.numGite, o.nomGite, o.prixSemaine);
                    }
                    break;
                case "Requête 2 : Liste des contrats annulés":
                    var contratsAnnules = from contrat in bd.contrats where contrat.annule == 1 select new { contrat.numContrat };
                    foreach (var o in contratsAnnules) {
                        this.rtb_resultat.Text += String.Format("Numéro du contrat: {0}\n", o.numContrat);
                    }
                    break;
                case "Requête 3 : Montant du chiffre d'affaires réalisé par client":
                    var montantChiffreAffaireParClient = from ctr in bd.contrats
                                                         from plan in bd.plannings
                                                         from cli in bd.clients
                                                         from tf in bd.tarifs
                                                         from sem in bd.semaines
                                                         where ctr.numContrat == plan.numContrat
                                                         && ctr.numClient == cli.numClient
                                                         && plan.numGite == tf.numGite
                                                         && plan.numSemaine == sem.numsemaine
                                                         && sem.numPeriode == tf.numPeriode
                                                         group tf by new { cli.nomClient }
                                                         into CaClient
                                                         let CA = CaClient.Sum(i => i.prixSemaine)
                                                         select new { CaClient.Key.nomClient, CA };
                    foreach (var o in montantChiffreAffaireParClient) {
                        this.rtb_resultat.Text += String.Format("Le client {0} a généré un chiffre d'affaires de {1} euros.\n", o.nomClient, o.CA);
                    }
                    break;
                case "Requête 4 : Montant total de chaque contrat":
                    var montantTotalChaqueContrat = from ctr in bd.contrats
                                                    from plan in bd.plannings
                                                    from tarif in bd.tarifs
                                                    from semaine in bd.semaines
                                                    where ctr.numContrat == plan.numContrat
                                                    && plan.numSemaine == semaine.numsemaine
                                                    && semaine.numPeriode == tarif.numPeriode
                                                    && plan.numGite == tarif.numGite
                                                    group tarif by new { ctr.numContrat }
                                                    into Con
                                                    let CON = Con.Sum(i => i.prixSemaine)
                                                    select new { Con.Key.numContrat, CON };
                    foreach (var o in montantTotalChaqueContrat){
                        this.rtb_resultat.Text += String.Format("Le contrat {0} a généré un chiffre d'affaires de {1} euros.\n", o.numContrat, o.CON);
                    }
                    break;
                case "Requête 5 : Liste des clients (nom, prénom) qui ont loué au moins un gîte":
                    var listeClientsLouesUnGite = from gite in bd.gites
                                                  from client in bd.clients
                                                  from contrat in bd.contrats
                                                  from planning in bd.plannings
                                                  where planning.numContrat == contrat.numContrat
                                                  && contrat.numClient == client.numClient
                                                  && gite.numGite == planning.numGite
                                                  select new { client.nomClient };
                    foreach (var o in listeClientsLouesUnGite){
                        this.rtb_resultat.Text += String.Format("Le client {0} a loué au moins un gîte.\n", o.nomClient);
                    }
                    break;
                case "Requête 6 : Liste des clients qui ont loué plus de 3 gîtes":
                    var listClientsLouesPlusDe3Gites = from gite in bd.gites
                                                       from client in bd.clients
                                                       from contrat in bd.contrats
                                                       from planning in bd.plannings
                                                       where planning.numContrat == contrat.numContrat
                                                       && contrat.numClient == client.numClient
                                                       && gite.numGite == planning.numGite
                                                       group client by new { client.nomClient }
                                                  into nbClients
                                                       select new { nbClients.Key.nomClient, nbrClients = nbClients.Count() };
                    foreach (var o in listClientsLouesPlusDe3Gites)
                    {
                        if (o.nbrClients >= 3)
                        {
                            this.rtb_resultat.Text += String.Format("Le client {0} a loué au moins trois gîtes. ({1})\n", o.nomClient, o.nbrClients);
                        }                        
                    }
                    break;
                case "Requête 7 : Liste des clients qui ont loué un gîte à la fois en période 1 et en période 2":
                    var Listeclientslouéenperiode12 = (from ctr in bd.contrats
                                                       from plan in bd.plannings
                                                       from cli in bd.clients
                                                       from per in bd.periodes
                                                       where (ctr.numContrat == plan.numContrat) && (ctr.numClient == cli.numClient) && (per.numPeriode == 1 || per.numPeriode == 2)
                                                       select new
                                                       {
                                                           cli.nomClient,
                                                           cli.numClient,
                                                       }).Distinct().ToList();
                    foreach (var o in Listeclientslouéenperiode12)
                    {
                        this.rtb_resultat.Text += String.Format("le client : {0} n°{1} \n", o.nomClient, o.numClient);
                    }

                    break;
                case "Requête 8 : Nom et prénom du(des client(s) qui a(ont) signé le plus de contrats":
                    var ListNomPrenomClientSigneContrat = from ctr in bd.clients
                                                          from c in bd.contrats
                                                          where ctr.numClient == c.numClient
                                                          group c by new
                                                          {
                                                              ctr.numClient,
                                                              ctr.nomClient
                                                          } into nbGitesContrat
                                                          select new
                                                          {
                                                              nbGitesContrat.Key.numClient,
                                                              nbGitesContrat.Key.nomClient,
                                                              nbrsContrat = nbGitesContrat.Count()

                                                          };
                    List<int> a = new List<int>();
                    foreach (var obj in ListNomPrenomClientSigneContrat)
                    {

                        a.Add(obj.nbrsContrat);
                    }
                    foreach (var o in ListNomPrenomClientSigneContrat)
                    {
                        if (a.Max() == o.nbrsContrat)
                        {
                            this.rtb_resultat.Text += String.Format("{0} a signé le plus de contrat {1}. \n", o.nomClient, o.nbrsContrat);
                        }
                    }
                    break;
                case "Requête 9 : Liste des gites qui n'ont jamais été loués":
                    var ListGitesJamaisLoues = (from c in bd.contrats
                                              from p in bd.plannings
                                              where c.numContrat == p.numContrat && c.valide == 1 && c.annule == 0
                                              select new
                                              {
                                                  p.numGite, }).ToList();

                    var interQuery = (from g in bd.gites
                                      select new
                                      {
                                          g.numGite,
                                      }).ToList();

                    var interQuerya = interQuery.Except(ListGitesJamaisLoues);

                    var result = (from z in interQuerya
                                    from g in bd.gites
                                    where z.numGite == g.numGite
                                    select new
                                    {
                                        g.nomGite,
                                    }).ToList();

                    foreach (var gite in result)
                    {
                        this.rtb_resultat.Text += String.Format("Gîtes non loués : {0} \n ", gite.nomGite);
                    }
                    break;
                case "Requête 10 : Donner le contrat(n° et nom de client) qui représente le plus gros montant":
                    var ListContratRpzPlusGrosMontant = from c in bd.contrats
                                                        join cl in bd.clients on c.numClient equals cl.numClient
                                                        join p in bd.plannings on c.numContrat equals p.numContrat
                                                        join s in bd.semaines on p.numSemaine equals s.numsemaine
                                                        join g in bd.gites on p.numGite equals g.numGite
                                                        join t in bd.tarifs on g.numGite equals t.numGite
                                                        where t.numPeriode == s.numPeriode && c.valide == 1
                                                        group t by new
                                                        {
                                                            c.numContrat
                                                        } into CaContrat
                                                        let CA = CaContrat.Sum(i => i.prixSemaine)
                                                        select new
                                                        {
                                                            CaContrat.Key.numContrat,
                                                            CA
                                                        };
                    foreach (var item in ListContratRpzPlusGrosMontant)
                    {

                        this.rtb_resultat.Text += String.Format("le contrat {0} vaut {1}$ .", item.numContrat, item.CA);
                    }
                    break;
                case "Requête 11 : Donner la liste des clients qui ont loué chaque gîte au moins une fois":

                case "Requête 12 : Donner les villes dont le chiffre d'affires réalisé est supérieur à celui de la ville de Sommières":
                    var ListVillesCASupVilleSommières = from c in bd.contrats
                                                        join cl in bd.clients on c.numClient equals cl.numClient
                                                        join p in bd.plannings on c.numContrat equals p.numContrat
                                                        join s in bd.semaines on p.numSemaine equals s.numsemaine
                                                        join g in bd.gites on p.numGite equals g.numGite
                                                        join t in bd.tarifs on g.numGite equals t.numGite
                                                        where t.numPeriode == s.numPeriode && c.valide == 1
                                                        group t by new
                                                        {
                                                            g.numGite,
                                                            g.villeGite
                                                        } into CaContrat
                                                        let CA = CaContrat.Sum(i => i.prixSemaine)
                                                        select new
                                                        {
                                                            CaContrat.Key.numGite,
                                                            CaContrat.Key.villeGite,
                                                            CA
                                                        };
                    decimal j = 0;
                    foreach (var item in ListVillesCASupVilleSommières)
                    {
                        if (item.villeGite.Contains("Gap"))
                        {
                            j = (decimal)item.CA;
                        }
                    }
                    foreach (var item in ListVillesCASupVilleSommières)
                    {
                        if (item.CA > j)
                        {
                            this.rtb_resultat.Text += String.Format("le gite {0} a rapporté {1}$ pour la ville de {2}.", item.numGite, item.CA, item.villeGite);
                        }

                    }
                    break;


                default:
                    break;
                    
                
            }
        }

        private void cb_requetes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
