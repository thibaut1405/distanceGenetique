using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculDistanceGenetique
{
    public static class GenererTrajets
    {
        //List<int> listeIdVille = new List<int>();
        static List<Trajet> listeTrajet = new List<Trajet>();
        static List<int> ListeDe1a15() { return new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }; } // A ameliorer : Ne pas le générer a la main mais avec la liste des villes.


        private static Trajet GenererUnTrajet()
        {
            System.Threading.Thread.Sleep(2); //WTFFFFFFFFFFFFF
            Trajet trajet = new Trajet();

            Random rand = new Random();

            List<int> randList = ListeDe1a15();

            while (trajet.listeDesVilles.Count < 15)
            {
                if (randList.Count != 1)
                {
                    int idVille = randList[rand.Next(randList.Count)];

                    randList.Remove(idVille);
                    trajet.listeDesVilles.Add(idVille);
                }
                else
                {
                    trajet.listeDesVilles.Add(randList[0]);
                }
            }
            return trajet;
        }

                     
        public static List<Trajet> GenererListeTrajet(int nombreDeTrajetAGenerer)
        {
            listeTrajet = new List<Trajet>();
            for (int i = 0; i < nombreDeTrajetAGenerer; i++)
            {
                Trajet trajet = GenererUnTrajet();

                if (!listeTrajet.Contains(trajet))
                {
                    listeTrajet.Add(trajet);
                }
            }
            return listeTrajet;
        } 
    }
}
