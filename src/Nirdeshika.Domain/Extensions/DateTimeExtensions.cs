namespace Nirdeshika.Domain.Extensions;
public static class DateTimeExtensions
{
    /// <summary>
    /// Calculates age in years from a birthdate as of today.
    /// </summary>
    public static int CalculateAge(this DateTime birthDate)
    {
        var today = DateTime.Today;

        if (birthDate > today)
        {
            throw new ArgumentException("Birth date cannot be in the future.");
        }

        if (today.Year == birthDate.Year)
        {
            return today.Month - birthDate.Month >= 6 ? 1 : 0;
        }

        var age = today.Year - birthDate.Year;

        DateTime birthdayThisYear;
        try
        {
            birthdayThisYear = new DateTime(today.Year, birthDate.Month, birthDate.Day);
        }
        catch (ArgumentOutOfRangeException)
        {
            // Handles Feb 29 in non-leap years
            birthdayThisYear = new DateTime(today.Year, 2, 28);
        }

        if (today < birthdayThisYear)
        {
            age--;
        }

        return age;
    }
}
