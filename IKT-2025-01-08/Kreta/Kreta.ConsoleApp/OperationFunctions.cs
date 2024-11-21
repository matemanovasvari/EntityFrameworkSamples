using Kreta.Database.Entities;
using Kreta.Database;

namespace Kreta.ConsoleApp;

public class OperationFunctions
{
    public static async Task AddStudent(ApplicationDbContext context)
    {
        Console.Clear();
        Console.WriteLine("---------Add new student---------\n");

        var student = new StudentEntity
        {
            EducationalCode = GetFunctions.GetEducationCode(),
            Name = GetFunctions.GetStudentName(),
            DateOfBirth = GetFunctions.GetStudentDateOfBirth(),
            MothersName = GetFunctions.GetMothersName(),
            Address = new AddressEntity
            {
                CountryName = GetFunctions.GetCountryName(),
                CityName = GetFunctions.GetCityName(),
                PostalCode = GetFunctions.GetPostalCode(),
                StreetName = GetFunctions.GetStreetName(),
                HouseNumber = GetFunctions.GetHouseNumber()
            }
        };

        await context.AddAsync(student);
        await context.SaveChangesAsync();
    }
}
