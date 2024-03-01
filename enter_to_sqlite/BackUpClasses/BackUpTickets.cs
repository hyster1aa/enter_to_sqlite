using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enter_to_sqlite.BackUpClasses
{
    public class BackUpTickets
    {
        public int id_ticket { get; set; }
        public int id_travel { get; set; }
        public int id_p { get; set; }
        public int car_number { get; set; }
        public int place_number { get; set; }
        public BackUpTickets(int id_ticket, int id_travel, int id_p, int car_number, int place_number)
        {
            this.id_ticket = id_ticket;
            this.id_travel = id_travel;
            this.id_p = id_p;
            this.car_number = car_number;
            this.place_number = place_number;
        }

    }
}
