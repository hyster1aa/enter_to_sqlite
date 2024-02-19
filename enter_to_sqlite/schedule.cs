using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enter_to_sqlite
{
    public class schedule
    {
        public string typeTrain { get; set; }
        public string depPoint { get; set; }
        public string arrPoint { get; set; }
        public string timeStart { get; set; }
        public string dateStart { get; set; }
        public string timeTravel { get; set; }
        public schedule(string typeTrain, string depPoint, string arrPoint, string timeStart, string dateStart, string timeTravel)
        {
            this.typeTrain = typeTrain;
            this.depPoint = depPoint;
            this.arrPoint = arrPoint;
            this.timeStart = timeStart;
            this.dateStart = dateStart;
            this.timeTravel = timeTravel;
        }
    }
}
