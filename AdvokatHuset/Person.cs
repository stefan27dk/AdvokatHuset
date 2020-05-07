using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    abstract class Person
    {
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string Mail { get; set; }
        public int TlfNr { get; set; }
        public string Adresse { get; set; }
        public int PostNr { get; set; }

        public Person() //Constructor
        {

        }
    }
}
