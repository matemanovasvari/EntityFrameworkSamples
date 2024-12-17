using Kreta.Database.Entities;
using Kreta.Database;
using System.Diagnostics;

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
            MothersName = GetFunctions.GetMothersName()
        };

        var newAddress = new AddressEntity
        {
            CountryName = GetFunctions.GetCountryName(),
            CityName = GetFunctions.GetCityName(),
            PostalCode = GetFunctions.GetPostalCode(),
            StreetName = GetFunctions.GetStreetName(),
            HouseNumber = GetFunctions.GetHouseNumber()
        };

        student.AddressId = await CheckAndAddAddressAsync(context, newAddress);

        await context.AddAsync(student);
        await context.SaveChangesAsync();
    }

    private static async Task<uint> CheckAndAddAddressAsync(ApplicationDbContext context, AddressEntity newAddress)
    {
        var existingAddress = await context.Addresses
            .FirstOrDefaultAsync(a =>
                a.CountryName == newAddress.CountryName &&
                a.CityName == newAddress.CityName &&
                a.PostalCode == newAddress.PostalCode &&
                a.StreetName == newAddress.StreetName &&
                a.HouseNumber == newAddress.HouseNumber);

        if (existingAddress != null)
        {
            return existingAddress.Id;
        }
        else
        {
            await context.AddAsync(newAddress);
            await context.SaveChangesAsync();
            return newAddress.Id;
        }
    }

    public static async Task AddSubject(ApplicationDbContext context)
    {
        
    }

    public static async Task ViewStudents(ApplicationDbContext context)
    {
        Console.WriteLine("Current students in the database:");

        var students = await context.Students.OrderBy(x => x.Name).ToListAsync();

        foreach (var student in students)
        {
            Console.WriteLine($"Name: {student.Name}\n\tEducation Id: {student.EducationalCode}\n\tDate Of Birth: {student.DateOfBirth:yyyy-MM-dd}" +
                              $"\n\tMother's name: {student.MothersName}"); //\n\tAddress: {student.Address.CountryName} {student.Address.CityName} {student.Address.StreetName} {student.Address.HouseNumber}
        }
    }
}