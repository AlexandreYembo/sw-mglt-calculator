using Kneat.Starwars.Repositories.Models;

namespace Kneat.Starwars.UnitTesting.Stub
{
    public class StarshipResponseStub
    {
        public StarshipResponse GetOne()
        {
            return new StarshipResponse
            {
                Next = null,
                Results = new System.Collections.Generic.List<Starships>{
                    new Starships{
                        Name = "Millennium Falcon",
                        Consumables = "2 months",
                        MGLT = "75"
                    }
                }
            };
        }
    }
}