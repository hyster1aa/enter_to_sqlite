using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enter_to_sqlite.BackUpClasses
{
    public class BackUpRoutes
    {
        public int id_route { get; set; }
        public int dep_point { get; set; }
        public int arr_point { get; set; }
        public BackUpRoutes(int id_route, int dep_point, int arr_point) { 
            this.id_route = id_route;
            this.dep_point = dep_point;
            this.arr_point = arr_point;
        }
    }
}
