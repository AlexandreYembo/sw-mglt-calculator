namespace Kneat.Starwars.Services.TimeCalculation
{
    /// <summary>
    /// This is a generic class that is get hours = 0 for unknow format of time.
    /// </summary>
    public class UnknowTime : IHoursCalculation
    {protected readonly IHours _hours;

        public UnknowTime(IHours hours)
        {
            this._hours = hours;
        }
        public double GetHours() => _hours.Get(0);
    }
}