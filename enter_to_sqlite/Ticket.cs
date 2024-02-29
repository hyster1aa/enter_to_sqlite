using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enter_to_sqlite
{
    public class Ticket
    {
        public int id_ticket { get; set; }
        public Passenger passenger { get; set; }
        public ScheduleItem travelInformation { get; set; }
        public int trainCarNumber { get; set; }
        public int trainCarPlaceNumber { get; set;}
        public Ticket(int id_ticket, Passenger passenger, ScheduleItem travelInformation, int trainCarNumber, int trainCarPlaceNumber)
        {
            this.id_ticket = id_ticket;
            this.passenger = passenger;
            this.travelInformation = travelInformation;
            this.trainCarNumber = trainCarNumber;
            this.trainCarPlaceNumber = trainCarPlaceNumber;
        }

        public Ticket(int id_ticket)
        {
            this.id_ticket = id_ticket;
        }
    }
}
