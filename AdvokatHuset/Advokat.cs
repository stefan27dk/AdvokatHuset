using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Advokat:Person
    {
        private int AdvokatId { get; set; }
        private int SpecialeId { get; set; }

        public Advokat() //Constructor
        {

        }

        public void CreateSag()
        {
            //Her tilføjes SQL statement for Insert
        }
        public void UpdateSag()
        {
            //Her tilføjes SQL statement for Update
        }
        public void DeleteSag()
        {
            //Her tilføjes SQL statement for Delete
        }
        public void TilføjBrugtTidTilSag()
        {
            //Her oprettes en metoder der tilføjer brugt tid på en sag
        }
    }
}
