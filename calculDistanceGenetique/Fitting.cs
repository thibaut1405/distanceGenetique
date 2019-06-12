using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Json;
using System.IO;
using Newtonsoft.Json;
using GeoCoordinatePortable;

namespace calculDistanceGenetique
{
    class Fitting
    {
        public List<Item> LoadJson()
        {
            using (StreamReader r = new StreamReader("cities.json"))
            {
                string json = r.ReadToEnd();
                var ListVille = JsonConvert.DeserializeObject<List<Item>>(json);
                int x = 1;
                foreach (var ville in ListVille)
                {
                    ville.id = x++;
                }
                return ListVille;
            }
        }

        public void calcul()
        {
            RandGen gen = new RandGen();
            var q = gen.generateId();
            //Item item = new Item();

            var lesVilles = LoadJson();

            foreach (var idVillesAleat in q)
            {

                foreach (var id in idVillesAleat)
                {
                    foreach (var villes in lesVilles)
                    {
                        if (id == villes.id)
                        {
                            GetDistance(villes.lng, villes.lan);
                            //Console.WriteLine("{0} {1} {2} {3}", villes.id, villes.city, villes.lan, villes.lan);
                        }
                     }
                }
            }
         }
        void GetDistance(double lng, double lan)
        {
            var distance = new GeoCoordinate(lan, lng);
            Console.WriteLine(distance.GetDistanceTo(distance).ToString());
        }

        
    }
}
