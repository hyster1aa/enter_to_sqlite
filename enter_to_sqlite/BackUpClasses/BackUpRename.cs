using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enter_to_sqlite.BackUpClasses
{
    public class BackUpRename
    {
        public List<Passenger> passengers { get; set; }
        public List<BackUpTickets> tickets { get; set; }
        public List<City> cities { get; set; }
        public List<BackUpRoutes> routes { get; set; }
        public List<BackUpSchedule> schedule { get; set; }
        public BackUpRename( List<City>cities, List<Passenger>passengers, List<BackUpRoutes>routes, List<BackUpSchedule> schedule ,List<BackUpTickets> tickets) { 
            this.passengers = passengers;
            this.cities = cities;
            this.routes = routes;
            this.schedule = schedule;
            this.tickets = tickets;
        }

    }
}