﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculDistanceGenetique
{
    public class Trajet
    {
        public List<int> listeDesVilles = new List<int>();
        public double distance = 0D;

        public override string ToString()
        {
            string ret = "";
            foreach( var x in listeDesVilles)
            {
                ret += x.ToString()+",";
            }
            return ret;
        }

        public bool Contains(int x)
        {
            return listeDesVilles.Contains(x);
        }

        public void AfficherUnTrajetComplet()
        {
            string resultat = "";
            foreach (int idVille in listeDesVilles)
            {
                resultat += Program.listeDesVilles[idVille - 1].city + ", ";
            }

            Console.WriteLine(resultat +"avec une distance de : "+ (distance/1000).ToString() + " Km");
        }
    }
}
