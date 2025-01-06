using Kreta.Database.Entities;
using Kreta.Database;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Kreta.ConsoleApp;

public class OperationFunctions
{
    public static async Task AddStudent(ApplicationDbContext context)
    {
        Console.Clear();
        Console.WriteLine("---------Add new student---------\n");

        var student = new StudentEntity
        {
            EducationalCode = GetFunctions.GetEducationCodeThatDoesntYetExist(),
            Name = GetFunctions.GetName("Enter the student's name: "),
            DateOfBirth = GetFunctions.GetDate("Enter the student's date of birth (year-month-day): "),
            MothersName = GetFunctions.GetName("Enter the mother's name: ")
        };

        var newAddress = new AddressEntity
        {
            CountryName = GetFunctions.GetStringCantContainNumber("Enter the country name: "),
            CityName = GetFunctions.GetStringCantContainNumber("Enter the city name: "),
            PostalCode = GetFunctions.GetStringCanHaveNumber("Enter the postal code: "),
            StreetName = GetFunctions.GetStringCantContainNumber("Enter the street name: "),
            HouseNumber = GetFunctions.GetStringCanHaveNumber("Enter the house number: ")
        };

        student.AddressId = await CheckAndAddAddressAsync(context, newAddress);

        await context.AddAsync(student);
        await context.SaveChangesAsync();
    }


    public static async Task AddSubject(ApplicationDbContext context)
    {
        ViewStudentsNameAndCode(context);

        long studentCodeToAddSubjectTo = GetFunctions.GetStudentCodeThatAlreadyExists("Enter the code of the student you wanna add a subject to: ");

        var student = await context.Students
            .Where(student => student.EducationalCode == studentCodeToAddSubjectTo)
            .Include(s => s.Subjects)
            .FirstOrDefaultAsync();

        bool subjectAdded = false;

        do
        {
            string subjectName = GetFunctions.GetStringCanHaveNumber("Enter the subject name: ");

            var existingSubject = await context.Subjects
                .FirstOrDefaultAsync(x => x.SubjectName.ToLower() == subjectName.ToLower());

            if (existingSubject != null)
            {
                if (!student.Subjects.Any(x => x.SubjectName.ToLower() == subjectName.ToLower()))
                {
                    student.Subjects.Add(existingSubject);
                    subjectAdded = true;
                }
            }
            else
            {
                var newSubject = new SubjectEntity
                {
                    SubjectName = subjectName
                };

                student.Subjects.Add(newSubject);
                subjectAdded = true;
            }
        }
        while (subjectAdded);

        await context.SaveChangesAsync();
    }

    public static async Task AddGrade(ApplicationDbContext context)
    {
        await ViewStudentsNameAndCode(context);
        long studentCode = GetFunctions.GetStudentCodeThatAlreadyExists("Enter the code of the student you wanna add a grade to:");

        var studentWithSubjects = await context.Students.Where(student => student.EducationalCode == studentCode).Include(student => student.Subjects).FirstOrDefaultAsync();

        await ViewSubjects(context, studentWithSubjects);
        uint subjectId = studentWithSubjects.Subjects.FirstOrDefault(x => x.SubjectName == GetFunctions.GetSubjectNameThatAlreadyExists(studentWithSubjects)).Id;

        GradeEntity grade = new GradeEntity
        {
            Date = GetFunctions.GetDate("Enter the date when this grade was given: "),
            Value = GetFunctions.GetGradeValue("Enter the given grade: "),
            SubjectId = subjectId,
            StudentEducationalCode = studentCode
        };

        await context.Grades.AddAsync(grade);
        await context.SaveChangesAsync();
    }

    public static async Task ModifyStudent(ApplicationDbContext context)
    {
        await ViewStudentsNameAndCode(context);
        long studentCode = GetFunctions.GetStudentCodeThatAlreadyExists("Enter the code of the student you wanna modify: ");

        var student = await context.Students
            .Include(s => s.Address)
            .Where(s => s.EducationalCode == studentCode)
            .FirstOrDefaultAsync();

        Console.WriteLine("\nPress Enter to keep the current value.\n");

        Console.WriteLine($"Current Name: {student.Name}");
        string newName = GetFunctions.GetStringCanBeEmpty("New name:");
        student.Name = !string.IsNullOrWhiteSpace(newName) ? newName.ToUpper() : student.Name;

        Console.WriteLine($"Current Date of Birth: {student.DateOfBirth:yyyy-MM-dd}");
        string newDateOfBirth = GetFunctions.GetStringWithNumberCanBeEmpty("New Date of Birth(yyyy-MM-dd): ");
        student.DateOfBirth = !string.IsNullOrWhiteSpace(newDateOfBirth) ? DateTime.Parse(newDateOfBirth) : student.DateOfBirth;

        Console.WriteLine($"Current Mother's Name: {student.MothersName}");
        string newMothersName = GetFunctions.GetStringCanBeEmpty("New Mother's Name: ");
        student.MothersName = !string.IsNullOrWhiteSpace(newMothersName) ? newMothersName.ToUpper() : student.MothersName;

        Console.WriteLine($"Current Country: {student.Address.CountryName}");
        string newCountry = GetFunctions.GetStringCanBeEmpty("New Country: ");
        student.Address.CountryName = !string.IsNullOrWhiteSpace(newCountry) ? newCountry.ToUpper() : student.Address.CountryName;

        Console.WriteLine($"Current City: {student.Address.CityName}");
        string newCity = GetFunctions.GetStringCanBeEmpty("New City: ");
        student.Address.CityName = !string.IsNullOrWhiteSpace(newCity) ? newCity.ToUpper() : student.Address.CityName;

        Console.WriteLine($"Current PostalCode: {student.Address.PostalCode}");
        string newPostalCode = GetFunctions.GetStringCanBeEmpty("New Postal Code: ");
        student.Address.PostalCode = !string.IsNullOrWhiteSpace(newPostalCode) ? newPostalCode.ToUpper() : student.Address.PostalCode;

        Console.WriteLine($"Current Street Name: {student.Address.StreetName}");
        string newStreetName = GetFunctions.GetStringCanBeEmpty("New Street Name: ");
        student.Address.StreetName = !string.IsNullOrWhiteSpace(newStreetName) ? newStreetName.ToUpper() : student.Address.StreetName;

        Console.WriteLine($"Current House Number: {student.Address.HouseNumber}");
        string newHouseNumber = GetFunctions.GetStringCanBeEmpty("New House Number: ");
        student.Address.HouseNumber = !string.IsNullOrWhiteSpace(newHouseNumber) ? newHouseNumber.ToUpper() : student.Address.HouseNumber;

        await context.SaveChangesAsync();
        Console.WriteLine("\nStudent data updated successfully.");
    }

    public static async Task ViewStudents(ApplicationDbContext context)
    {
        Console.WriteLine("Current students in the database:");

        var students = await context.Students.OrderBy(x => x.Name).Include(student => student.Address).Include(student => student.Subjects).ThenInclude(x => x.Grades).ToListAsync();

        foreach (var student in students)
        {
            Console.WriteLine($"Name: {student.Name}" +
                              $"\n\tEducation Code: {student.EducationalCode}" +
                              $"\n\tDate Of Birth: {student.DateOfBirth:yyyy-MM-dd}" +
                              $"\n\tMother's name: {student.MothersName}" +
                              $"\n\tAddress: {student.Address.CountryName} {student.Address.CityName} {student.Address.PostalCode} {student.Address.StreetName} {student.Address.HouseNumber}" +
                              $"\n\tSubjects: ");
            
            foreach (var subject in student.Subjects)
            {
                Console.WriteLine($"\t\t{subject.SubjectName}");

                Console.WriteLine($"\t\t\tGrades:");
                foreach(var grade in subject.Grades)
                {
                    Console.WriteLine($"\t\t\t\t{grade.Value}");
                }
            }

        }
    }

    public static async Task ViewStudentsNameAndCode(ApplicationDbContext context)
    {
        var students = await context.Students.OrderBy(x => x.Name).ToListAsync();

        foreach(var student in students)
        {
            Console.WriteLine($"Name: {student.Name}, Education Code:{student.EducationalCode}");
        }
    }

    public static async Task ViewSubjects(ApplicationDbContext context, StudentEntity student)
    {
        var subjects = student.Subjects;

        foreach(var subject in subjects)
        {
            Console.WriteLine(subject.SubjectName);
        }
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
}