using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Product
    {
        //properties
        //to get from database
        //these entities should relate to the database
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
