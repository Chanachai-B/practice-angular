namespace Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public DateOnly Dob { get; set; }

    public int Age
    {
        get
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var age = today.Year - Dob.Year;
            if (Dob.Month > today.Month || (Dob.Month == today.Month && Dob.Day > today.Day))
                age--;
            return age;
        }
    }
}