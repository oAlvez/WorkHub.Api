namespace WorkHub.Application.Extensions;
public static class DateExtension
{
    public static DateTime UtcToTimeZone(this DateTime currentUtc, string timeZone = "America/Sao_Paulo")
    {
        try
        {
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
            return TimeZoneInfo.ConvertTimeFromUtc(currentUtc, timeZoneInfo);
        }
        catch
        {
            return currentUtc;
        }
    }
}