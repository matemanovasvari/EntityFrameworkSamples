using Vehicles.Database;
using Vehicles.Database.Entities;

using var dbContext = new ApplicationDbContext();

var peugeot208 = new VehicleEntity
{
    ChassisNumber = "asdfghjklq2345tr5",
    EngineNumber = "de",
    LicencePlate = "AAAA123",
    NumberOfDoors = 5,
    Power = 92,
    Weight = 1000
};

await dbContext.Vehicles.AddAsync(peugeot208);
await dbContext.SaveChangesAsync();

Console.WriteLine("Done");