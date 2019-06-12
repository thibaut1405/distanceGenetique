using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculDistanceGenetique
{
    class RandGen
    {
        List<int> listVille = new List<int>();
        List<List<int>> listTrajet = new List<List<int>>();
        List<int> ListeDe1a15() { return new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }; }

        public List<List<int>> generateId()
        {
            Random rand = new Random();
            for (int i = 0; i < 200; i++)
            {
                var randList = ListeDe1a15();

                while (listVille.Count < 15)
                {
                    if (randList.Count != 1) {
                        int idVille = randList[rand.Next(randList.Count)];

                        randList.Remove(idVille);
                        listVille.Add(idVille);
                    }
                    else
                    {
                        listVille.Add(randList[0]);
                    }
                }
                if (!listTrajet.Contains(listVille))
                {
                    listTrajet.Add(listVille);
                }

                listVille = new List<int>();
            }
            return listTrajet;
        } 
    }
}
