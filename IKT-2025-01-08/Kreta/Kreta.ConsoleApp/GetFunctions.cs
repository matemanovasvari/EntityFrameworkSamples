using Kreta.Database;
using Kreta.Database.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using static System.Net.Mime.MediaTypeNames;

namespace Kreta.ConsoleApp;

public class GetFunctions
{
    public static long GetEducationCodeThatDoesntYetExist()
    {
        long eduCode = 0;
        string input = string.Empty;

        do
        {
            Console.WriteLine("Enter the educational code (11 digit number): ");
            input = Console.ReadLine();

        } while (input.Length != 11 || !input.All(char.IsDigit) || !long.TryParse(input, out eduCode) || EduCodeExists(eduCode));

        return eduCode;
    }

    public static bool EduCodeExists(long eduCode)
    {
        using var context = new ApplicationDbContext();

        return context.Students.Any(x => x.EducationalCode == eduCode);
    }

    public static DateTime GetDate(string prompt)
    {
        string input = string.Empty;
        DateTime date;

        do
        {
            Console.WriteLine(prompt);
            input = Console.ReadLine();
        }
        while (!DateTime.TryParse(input, out date));

        return date;
    }

    public static string GetName(string prompt)
    {
        string name = string.Empty;
        string input = string.Empty;

        do
        {
            Console.WriteLine(prompt);
            input = Console.ReadLine();
        }
        while (input.All(char.IsDigit) || input.Length < 2);

        name = input.ToUpper();

        return name;
    }

    public static string GetStringCantContainNumber(string prompt){

        string userInput;
        bool hasNumber;

        do
        {
            Console.Write(prompt);
            userInput = Console.ReadLine();

            hasNumber = false;
            foreach (char c in userInput)
            {
                if (char.IsDigit(c))
                {
                    hasNumber = true;
                }
            }

        } while (hasNumber);

        return userInput;
    }

    public static long GetStudentCodeThatAlreadyExists(string prompt)
    {
        long code = 0;
        string input = string.Empty;

        do
        {
            Console.WriteLine(prompt);
            input = Console.ReadLine();
        }
        while (!long.TryParse(input, out code) || !EduCodeExists(code));

        return code;
    }

    public static string GetStringCanHaveNumber(string promt)
    {
        string input = string.Empty;
        bool isValid = true;

        do
        {
            Console.Write(promt);
            input = Console.ReadLine();
            isValid = input.Length != 0;

        } while (!isValid);

        return input;
    }

    public static string GetSubjectNameThatAlreadyExists(StudentEntity student)
    {
        string subjectName = string.Empty;
        do
        {
            Console.WriteLine("Enter the subject name to add grades:");
            subjectName = Console.ReadLine();

        } while (!student.Subjects.Any(x => x.SubjectName == subjectName));

        return subjectName;
    }

    public static bool SubjectExists(string subjectName)
    {
        using var context = new ApplicationDbContext();

        return context.Subjects.Any(x => x.SubjectName == subjectName);
    }

    public static uint GetGradeValue(string promt)
    {
        uint number = 0;
        string text = string.Empty;
        do
        {
            Console.WriteLine($"{promt}");
            text = Console.ReadLine();
        }
        while (!uint.TryParse(text, out number) || (number < 1 || number > 5));

        return number;
    }

    public static string GetStringCanBeEmpty(string promt)
    {
        string input = string.Empty;
        bool isValid = true;

        do
        {
            Console.Write(promt);
            input = Console.ReadLine();
            isValid = input.All(c => !char.IsDigit(c));

        } while (!isValid);

        return input;
    }

    public static string GetStringWithNumberCanBeEmpty(string promt)
    {
        string input = string.Empty;

        Console.Write(promt);
        input = Console.ReadLine();

        return input;
    }
}