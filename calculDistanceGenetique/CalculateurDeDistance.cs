using GeoCoordinatePortable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculDistanceGenetique
{
    public static class CalculateurDeDistance
    {
        public static List<Trajet> Calcul(List<Trajet> ListeDesTrajets, List<Ville> listeVille)
        {
            for (int i = 0; i < ListeDesTrajets.Count; i++)
            {
                ListeDesTrajets[i] = CalculDUnTrajet(ListeDesTrajets[i], listeVille);
            }

            return ListeDesTrajets;
        }


        static Trajet CalculDUnTrajet(Trajet trajet, List<Ville> listeVille)
        {
            for (int i = 1; i < 15; i++)
            {
                var ville1 = listeVille[trajet.listeDesVilles[i] - 1];
                var ville2 = listeVille[trajet.listeDesVilles[i - 1] - 1];

                trajet.distance += GetDistance(ville1.lng, ville1.lan, ville2.lng, ville2.lan);
            }
            return trajet;
        }


        static double GetDistance(double longitude1, double latitude1, double longitude2, double latitude2)
        {
            GeoCoordinate coordonneeVille1 = new GeoCoordinate(latitude1, longitude1);
            GeoCoordinate coordonneeVille2 = new GeoCoordinate(latitude2, longitude2);
            return coordonneeVille1.GetDistanceTo(coordonneeVille2); // En m et pas en Km !
        }
    }
}
