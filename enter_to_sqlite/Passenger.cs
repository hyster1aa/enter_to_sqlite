using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enter_to_sqlite
{
    public class Passenger
    {
        public int id_p { get; set; }
        public string full_name { get; set; }
        public string passport { get; set; }
        public bool benefit { get; set; }
        public Passenger(int id_p, string full_name, string passport, bool benefit)
        {
            this.id_p = id_p;
            this.full_name = full_name;
            this.passport = passport;
            this.benefit = benefit;
        }
    }
}
