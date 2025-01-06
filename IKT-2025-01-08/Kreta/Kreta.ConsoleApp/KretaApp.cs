using Kreta.Database;
using Kreta.Database.Entities;
using System.Reflection.Emit;

namespace Kreta.ConsoleApp;

public class KretaApp
{
    public static async Task Main()
    {
        Console.Clear();
        await Menu();
    }

    public static async Task Menu()
    {
        using var context = new ApplicationDbContext();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("==== Kreta ConsoleApp ====");
            Console.WriteLine("1. Add new student");
            Console.WriteLine("2. Add new subject");
            Console.WriteLine("3. Add new grade");
            Console.WriteLine("4. Modify student's data");
            Console.WriteLine("5. Display database");
            Console.WriteLine("\n----To Exit Press E----\n");
            Console.Write("Select a choice: ");

            var choice = Console.ReadLine()?.ToLower();
            switch (choice)
            {
                case "1":
                    await OperationFunctions.AddStudent(context);
                    Console.WriteLine("Student added succesfully!");
                    Thread.Sleep(1500);
                    await Menu();
                    break;
                case "2":
                    await OperationFunctions.AddSubject(context);
                    Thread.Sleep(1500);
                    await Menu();
                    break;
                case "3":
                    await OperationFunctions.AddGrade(context);
                    break;
                case "4":
                    await OperationFunctions.ModifyStudent(context);
                    break;
                case "5":
                    await OperationFunctions.ViewStudents(context);
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    break;
                case "e":
                    Console.Clear();
                    Console.WriteLine("Bye");
                    return;
                default:
                    Console.WriteLine("Invalid choice! Press Enter to continue.");
                    Console.ReadLine();
                    await Menu();
                    return;
            }
        }
    }
}