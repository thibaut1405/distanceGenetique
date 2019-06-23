using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculDistanceGenetique
{
    static class JsonReader
    {
        public static List<Ville> GetVilles() //Récupère chaque ville, créé un objet "ville" pour chaque ville, et retourne la liste des villes
        {
            using (StreamReader r = new StreamReader("cities.json"))
            {
                string json = r.ReadToEnd();
                var ListVille = JsonConvert.DeserializeObject<List<Ville>>(json);
                int x = 1;
                foreach (var ville in ListVille)
                {
                    ville.id = x++;
                }
                return ListVille;
            }
        }
    }
}
