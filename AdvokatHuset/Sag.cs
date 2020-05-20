using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Sag:Omkostninger
    {
        
        public string AdvokatID { get; set; }
        public string KundeID { get; set; }
        public string Oprets_Dato { get; set; }
        public string SagType { get; set; }
        public bool Afslutet { get; set; }

        public Sag() //Constructor
        {

        }
    }
}
