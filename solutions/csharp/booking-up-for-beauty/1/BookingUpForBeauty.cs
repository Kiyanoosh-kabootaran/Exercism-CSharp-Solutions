using System.Globalization;

static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription)
    {
        return DateTime.Parse(appointmentDateDescription);
    }

    public static bool HasPassed(DateTime appointmentDate)
    {
        return appointmentDate < DateTime.Now;
    }

    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        return appointmentDate.Hour >= 12 && appointmentDate.Hour < 18 ;
    }

    public static string Description(DateTime appointmentDate)
    {
        string formatDate = appointmentDate.ToString("M/d/yyyy h:mm:ss tt",CultureInfo.InvariantCulture);
        return $"You have an appointment on {formatDate}.";
    }

    public static DateTime AnniversaryDate()
    {
        int currentYear = DateTime.Now.Year;
        return new DateTime(currentYear,9,15,0,0,0);
    }
}
