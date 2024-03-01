using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enter_to_sqlite.BackUpClasses
{
    public class BackUpSchedule
    {
        public int id_travel { get; set; }
        public int id_train { get; set; }
        public int id_route { get; set; }
        public string type_train { get; set; }

        public string timeStart { get; set; }
        public string timeTravel { get; set; }
        public string dateStart { get; set; }
        public BackUpSchedule(int id_travel, int id_train, int id_route, string type_train, string timeStart, string timeTravel, string dateStart)
        {
            this.id_travel = id_travel;
            this.id_train = id_train;
            this.id_route = id_route;
            this.type_train = type_train;
            this.timeStart = timeStart;
            this.timeTravel = timeTravel;
            this.dateStart = dateStart;
        }
    }
}
