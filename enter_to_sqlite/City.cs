using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enter_to_sqlite
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public City(int Id, string Name) {
            this.Id= Id;
            this.Name= Name;
        }
        public bool Equals(City city)
        {
            return (this.Id == city.Id && this.Name == city.Name);
        }
    }
}
