using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Sag:Omkostninger
    {
        private int SagId { get; set; }
        private int SagNr { get; set; }
        private string Tid { get; set; }
        private string Dato { get; set; }
        private string Deadline { get; set; }
        private string SagType { get; set; }

        public Sag() //Constructor
        {

        }
    }
}
