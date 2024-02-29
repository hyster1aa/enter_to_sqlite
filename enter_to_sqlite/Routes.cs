using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enter_to_sqlite
{
    public class Routes
    {
        public int id_route { get; set; }
        public string depPoint { get; set; }
        public string arrPoint { get; set; }
        public Routes(int id_route, string depPoint, string arrPoint)
        {
            this.id_route = id_route;
            this.depPoint = depPoint;
            this.arrPoint = arrPoint;
        }
    }
}
