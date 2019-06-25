using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculDistanceGenetique
{
    static class MelangeurDeDonnee
    {
        static public List<Trajet> Melanger(List<Trajet> listeTrajets)
        {
            List<Trajet> anciensTrajets = new List<Trajet>();
            anciensTrajets = listeTrajets;
            List<Trajet> nouvelleListe = new List<Trajet>();
            int i = 0;
            int y = Program.nombreDeGenerationAleatoire-1;
            while (i < Program.nombreDeGenerationAleatoire/2)
            {
                Trajet trajet1 = anciensTrajets[i++];
                Trajet trajet2 = anciensTrajets[y--];

                List<int> nouveauTrajet = new List<int>();
                for (int x = 0; x < 8; x++) // Récupère les 8 premieres villes du premier trajet
                {
                    nouveauTrajet.Add(trajet1.listeDesVilles[x]);
                }
                foreach(int x in trajet2.listeDesVilles) // Recupère les villes qu'il manque dans le premier trajet dans l'ordre de leur apparition dans le 2ème
                {
                    if(!nouveauTrajet.Contains(x))
                    {
                        nouveauTrajet.Add(x);
                    }
                }
                Trajet trajet = new Trajet { listeDesVilles = nouveauTrajet };

                nouvelleListe.Add(trajet);
            }

            return nouvelleListe;
        }
    }
}
