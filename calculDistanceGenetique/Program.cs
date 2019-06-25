using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace calculDistanceGenetique
{
    class Program
    {
        public static List<Ville> listeDesVilles = new List<Ville>();

        private static List<Trajet> listeTrajet = new List<Trajet>();

        private static List<Trajet> nouvelleListeTrajet = new List<Trajet>();

        private static Trajet trajetGagnant = new Trajet();

        static void Main(string[] args)
        {
            listeDesVilles = JsonReader.GetVilles(); //Lire le Json et récupérer les données dans "listeDesVilles"

            listeTrajet = GenererTrajets.GenererListeTrajet(200); //Génère la liste des trajets aléatoirement

            listeTrajet = CalculateurDeDistance.Calcul(listeTrajet, listeDesVilles); //Calcule la distance de chaque trajet

            for (int i = 0; i < 50; i++)
            {
                listeTrajet = listeTrajet.OrderBy(o => o.distance).ToList(); //Trie les trajets en fonction de leur distance

                trajetGagnant = listeTrajet[0];

                Console.WriteLine(listeTrajet[0].distance); // Ecrit dans la console le trajet trouvé le plus court trouvé

                listeTrajet.RemoveRange(199, listeTrajet.Count - 200);

                nouvelleListeTrajet = MelangeurDeDonnee.Melanger(listeTrajet); //Mélange les données entre elles pour en avoir de nouvelles

                nouvelleListeTrajet.AddRange(GenererTrajets.GenererListeTrajet(100)); //Génère la liste des trajets aléatoirement et l'ajoute à la liste mélangée

                nouvelleListeTrajet = CalculateurDeDistance.Calcul(nouvelleListeTrajet, listeDesVilles);

                listeTrajet.AddRange(nouvelleListeTrajet);

            }
            listeTrajet = listeTrajet.OrderBy(o => o.distance).ToList();

            trajetGagnant.AfficherUnTrajetComplet();
            Console.ReadKey();
        }
    }
}
