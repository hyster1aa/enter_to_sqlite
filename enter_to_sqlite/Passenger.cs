using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enter_to_sqlite
{
    public class Passenger
    {
        public string full_name { get; set; }
        public string passport { get; set; }
        public bool benefit { get; set; }
        public Passenger(string full_name, string passport, bool benefit)
        {
            this.full_name = full_name;
            this.passport = passport;
            this.benefit = benefit;
        }
    }
}
