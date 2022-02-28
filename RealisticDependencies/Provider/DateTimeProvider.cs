namespace RealisticDependencies.Provider;

public class DateTimeProvider : IDateTimeProvider {
    public DateTimeProvider() { }

    public DateTime CurrentUtc() => DateTime.UtcNow;

    public bool IsMorning()=> CurrentUtc().Hour >= 6 && CurrentUtc().Hour <12;

    public bool IsAfternoon() => CurrentUtc().Hour >= 12 && CurrentUtc().Hour < 18;

    public bool IsEvening() => CurrentUtc().Hour >= 18 && CurrentUtc().Hour < 24;
    public bool IsLateNightEarlyMorning() => CurrentUtc().Hour >= 1 && CurrentUtc().Hour < 6;
}