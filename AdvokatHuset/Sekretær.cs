using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Sekretær:Person
    {
        private int SekretærId { get; set; }

        public Sekretær() //Constructor
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
