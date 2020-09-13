using System;
using System.Collections.Generic;
using System.Linq;

namespace Kneat.Starwars.Repositories.Models
{
    /// <summary>
    /// Model that presents the contract of StarshipResponse provided by the API or another source
    /// </summary>
    public class StarshipResponse
    {
        public string Next { get; set; }
        public List<Starships> Results {get;set;}
    }
}