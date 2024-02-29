using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enter_to_sqlite
{
    public class ScheduleItem
    {
        public int id { get; set; }
        public string typeTrain { get; set; }
        public Routes routes { get; set; }
        public string timeStart { get; set; }
        public string dateStart { get; set; }
        public string timeTravel { get; set; }
        public ScheduleItem(int id,string typeTrain, Routes routes, string timeStart, string dateStart, string timeTravel)
        {
            this.id = id;
            this.typeTrain = typeTrain;
            this.routes = routes;
            this.timeStart = timeStart;
            this.dateStart = dateStart;
            this.timeTravel = timeTravel;
        }
    }
}
