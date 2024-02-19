using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enter_to_sqlite
{
    public class Ticket
    {
        public Passenger passenger { get; set; }
        public schedule travelInformation { get; set; }
        public int trainCarNumber { get; set; }
        public int trainCarPlaceNumber { get; set;}
        public Ticket(Passenger passenger, schedule travelInformation, int trainCarNumber, int trainCarPlaceNumber)
        {
            this.passenger = passenger;
            this.travelInformation = travelInformation;
            this.trainCarNumber = trainCarNumber;
            this.trainCarPlaceNumber = trainCarPlaceNumber;
        }
    }
}
