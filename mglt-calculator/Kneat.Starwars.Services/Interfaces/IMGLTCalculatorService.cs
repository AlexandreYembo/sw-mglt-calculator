namespace Kneat.Starwars.Services.Interfaces
{
    /// <summary>
    /// Interface implemented by calculation for MGLT
    /// </summary>
    public interface IMGLTCalculatorService
    {
         double CalculateStopsByDistance(double distance, string consumables, string mglt);
    }
}