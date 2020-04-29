using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    abstract class Person
    {
        private string Fornavn { get; set; }
        private string Efternavn { get; set; }
        private string Mail { get; set; }
        private int TlfNr { get; set; }
        private string Adresse { get; set; }
        private int PostNr { get; set; }

        public Person() //Constructor
        {

        }
    }
}
