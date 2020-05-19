using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Ydelse
    {
        //private int YdelseNr { get; set; }
        public string Navn { get; set; }
        public double Pris { get; set; }
        public string Type { get; set; }
        public string Art { get; set; }
        public string Oprets_Dato { get; set; }

        public Ydelse() //Constructor
        {

        }
    }
}
