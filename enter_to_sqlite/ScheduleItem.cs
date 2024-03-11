    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enter_to_sqlite
{
    public class ScheduleItem
    {
        public int id_travel { get; set; }
        public int id_train { get; set;  }
        public string typeTrain { get; set; }
        public Route routes { get; set; }
        public string timeStart { get; set; }
        public string dateStart { get; set; }
        public string timeTravel { get; set; }
        public ScheduleItem(int id_travel, int id_train, string typeTrain, Route routes, string timeStart, string dateStart, string timeTravel)
        {
            this.id_travel = id_travel;
            this.id_train = id_train;
            this.typeTrain = typeTrain;
            this.routes = routes;
            this.timeStart = timeStart;
            this.dateStart = dateStart;
            this.timeTravel = timeTravel;
        }
        public string ToString
        {
            get { return $"{this.routes.ToString} - {this.timeStart} - {this.dateStart} - {this.timeTravel}"; }
        }
    }
}
