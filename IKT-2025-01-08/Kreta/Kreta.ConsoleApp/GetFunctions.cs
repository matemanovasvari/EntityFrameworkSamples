using Kreta.Database;

namespace Kreta.ConsoleApp;

public class GetFunctions
{
    public static long GetEducationCode()
    {
        long eduCode = 0;
        string input = string.Empty;

        do
        {
            Console.WriteLine("Enter the educational code (11 digit number): ");
            input = Console.ReadLine();

            if (input.Length != 11 || !input.All(char.IsDigit) || !long.TryParse(input, out eduCode))
            {
                Console.WriteLine("Incorrect input!");
            }

            if (EduCodeExists(eduCode))
            {
                Console.WriteLine("This educational code already exists. Please enter a different code.");
                eduCode = 0;
            }

        } while (eduCode == 0);

        return eduCode;
    }

    public static bool EduCodeExists(long eduCode)
    {
        using var context = new ApplicationDbContext();

        return context.Students.Any(x => x.EducationalCode == eduCode);
    }

    public static string GetStudentName()
    {
        string name = string.Empty;
        string input = string.Empty;

        do
        {
            Console.WriteLine("Enter the student's name: ");
            input = Console.ReadLine();
        }
        while (input.All(char.IsDigit) || input.Length < 2);

        name = input.ToUpper();

        return name;
    }

    public static DateTime GetStudentDateOfBirth()
    {
        string input = string.Empty;
        DateTime dateOfBirth;

        do
        {
            Console.WriteLine("Enter the date of birth (year-month-day): ");
            input = Console.ReadLine();
        }
        while (!DateTime.TryParse(input, out dateOfBirth));

        dateOfBirth = DateTime.Parse(input);

        return dateOfBirth;
    }

    public static string GetMothersName()
    {
        string name = string.Empty;
        string input = string.Empty;

        do
        {
            Console.WriteLine("Enter the mother's name: ");
            input = Console.ReadLine();
        }
        while (input.All(char.IsDigit) || input.Length < 2);

        name = input.ToUpper();

        return name;
    }

    public static string GetCountryName() 
    {
        string countryName = string.Empty;
        string input = string.Empty;

        do
        {
            Console.WriteLine("Enter the country's name: ");
            input = Console.ReadLine();
        }
        while (input.All(char.IsDigit));

        countryName = input.ToUpper();

        return countryName;
    }

    public static string GetCityName()
    {
        string cityName = string.Empty;
        string input = string.Empty;

        do
        {
            Console.WriteLine("Enter the city's name: ");
            input = Console.ReadLine();
        }
        while (input.All(char.IsDigit));

        cityName = input.ToUpper();

        return cityName;
    }

    public static string GetPostalCode()
    {
        Console.WriteLine("Enter the postal code: ");
        string postalCode = Console.ReadLine();

        return postalCode;
    }

    public static string GetStreetName()
    {
        string streetName = string.Empty;
        string input = string.Empty;

        do
        {
            Console.WriteLine("Enter the street's name: ");
            input = Console.ReadLine();
        }
        while (input.All(char.IsDigit));

        streetName = input.ToUpper();

        return streetName;
    }

    public static string GetHouseNumber()
    {
        Console.WriteLine("Enter the house number: ");
        string houseNumber = Console.ReadLine();
      
        return houseNumber;
    }
}
