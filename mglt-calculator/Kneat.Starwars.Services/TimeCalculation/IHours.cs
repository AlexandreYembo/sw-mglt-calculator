namespace Kneat.Starwars.Services.TimeCalculation
{
    /// <summary>
    /// Interface implemented by the concrete class Hour
    /// </summary>
    public interface IHours
    {
         double Get(int days);
    }
}