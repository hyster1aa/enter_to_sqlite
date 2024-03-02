using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enter_to_sqlite
{
    public class Route
    {
        public int id_route { get; set; }
        public City depPoint { get; set; }
        public City arrPoint { get; set; }
        public Route(int id_route, City depPoint, City arrPoint)
        {
            this.id_route = id_route;
            this.depPoint = depPoint;
            this.arrPoint = arrPoint;
        }

        public string ToString
        {
            get { return $"{this.depPoint.Name} — {this.arrPoint.Name}"; }
        }
        public bool Equals(Route other)
        {
            return (this.depPoint.Equals(other.depPoint)&&this.arrPoint.Equals(other.arrPoint) && this.id_route==other.id_route);
        }
    }
}
