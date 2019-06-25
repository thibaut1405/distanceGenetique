using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculDistanceGenetique
{
    static class MelangeurDeDonnee
    {
        public static List<Trajet> Decouper(List<Trajet> listeTrajets)
        {
            List<Trajet> nouvelleListe = new List<Trajet>();

            List<Trajet> premierQuart = new List<Trajet>();
            List<Trajet> deuxiemeQuart = new List<Trajet>();
            List<Trajet> troisiemeQuart = new List<Trajet>();
            List<Trajet> dernierQuart = new List<Trajet>();
            int i = 0;
            foreach (var x in listeTrajets)
            {
                if (i < Program.nombreDeGenerationAleatoire * 0.25)
                    premierQuart.Add(x);
                else if (i < Program.nombreDeGenerationAleatoire * 0.5)
                    deuxiemeQuart.Add(x);
                else if (i < Program.nombreDeGenerationAleatoire * 0.75)
                    troisiemeQuart.Add(x);
                else dernierQuart.Add(x);
                i++;
            }
            for (int z = 0; z < premierQuart.Count*0.5; z++)
            {
                nouvelleListe.Add(premierQuart[z]);
            }
            for (int z = 0; z < deuxiemeQuart.Count * 0.3; z++)
            {
                nouvelleListe.Add(deuxiemeQuart[z]);
            }
            for (int z = 0; z < troisiemeQuart.Count * 0.15; z++)
            {
                nouvelleListe.Add(troisiemeQuart[z]);
            }
            for (int z = 0; z < dernierQuart.Count * 0.05; z++)
            {
                nouvelleListe.Add(dernierQuart[z]);
            }
            return nouvelleListe;

        }

        static public List<Trajet> Melanger(List<Trajet> listeTrajets)
        {
            List<Trajet> anciensTrajets = new List<Trajet>();
            anciensTrajets = listeTrajets;
            List<Trajet> nouvelleListe = new List<Trajet>();
            int i = 0;
            int y = Program.nombreDeGenerationAleatoire/4 - 1;
            List<int> nouveauTrajet = new List<int>();
            while (i < Program.nombreDeGenerationAleatoire / 8)
            {
                Trajet trajet1 = anciensTrajets[i++];
                Trajet trajet2 = anciensTrajets[y--];


                for (int x = 0; x < 8; x++) // Récupère les 8 premieres villes du premier trajet
                {
                    nouveauTrajet.Add(trajet1.listeDesVilles[x]);
                }
                foreach (int x in trajet2.listeDesVilles) // Recupère les villes qu'il manque dans le premier trajet dans l'ordre de leur apparition dans le 2ème
                {
                    if (!nouveauTrajet.Contains(x))
                    {
                        nouveauTrajet.Add(x);
                    }
                }
                Trajet trajet = new Trajet { listeDesVilles = nouveauTrajet };
                if (trajet.listeDesVilles.Count != 15)
                    Console.WriteLine("bz");
                nouvelleListe.Add(trajet);
            }
            return nouvelleListe;
        }

        static public List<Trajet> Muter(List<Trajet> listeTrajets)
        {
            Random rnd = new Random((int)DateTime.Now.Ticks);

            foreach (Trajet trajet in listeTrajets)
            {
                if (rnd.Next(Program.nombreDeGenerationAleatoire / 2) == 1)
                {
                    var a = rnd.Next(0, 14);
                    var b = rnd.Next(0, 14);
                    var x = trajet.listeDesVilles[a];
                    trajet.listeDesVilles[b] = trajet.listeDesVilles[a];
                    trajet.listeDesVilles[a] = x;
                }
            }

            return listeTrajets;
        }
    }
}
