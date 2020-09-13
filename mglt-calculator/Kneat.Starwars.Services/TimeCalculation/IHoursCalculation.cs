namespace Kneat.Starwars.Services.TimeCalculation
{
    /// <summary>
    /// Interface implemented by the concrete classes:
    /// HoursPerDay, HoursPerWeek, HoursPerMonth, HoursPerYear
    /// </summary>
    public interface IHoursCalculation
    {
        double GetHours();
    }
}