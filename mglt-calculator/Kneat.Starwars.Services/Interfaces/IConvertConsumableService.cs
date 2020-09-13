namespace Kneat.Starwars.Services.Interfaces
{
    /// <summary>
    /// Interface used to implement the consumable calculation
    /// </summary>
    public interface IConvertConsumableService
    {
        double ToHour(double number, string timeType);
    }
}