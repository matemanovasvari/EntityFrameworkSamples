using var dbContext = new ApplicationDbContext();

//adat hozzáadása az adatbázishoz
//var vehicle = new VehicleEntity
//{
//    ChassisNumber = "ioplghjklq2345tr5",
//    EngineNumber = "df",
//    LicencePlate = "CCBB123",
//    NumberOfDoors = 5,
//    Power = 140,
//    Weight = 1500,
//    ColorId = 2
//}; //így ha kell az id. lehet az addasyncbe is tenni ezeket

await dbContext.Vehicles.AddAsync(new VehicleEntity
{
    ChassisNumber = "12345678910asdfgh",
    EngineNumber = "3F",
    LicencePlate = "CCDD123",
    NumberOfDoors = 5,
    Power = 170,
    Weight = 1400,
    ColorId = 1,
    ManufacturerId = 1,
    ModelId = 1
});
await dbContext.SaveChangesAsync();//változtatások elmentése

//rekord módosítása, 
//var vehicle = await dbContext.Vehicles.FindAsync((uint)1);
//vehicle.ChassisNumber = "11111111111111111";

//törlése
//dbContext.Vehicles.Remove(vehicle);
//await dbContext.SaveChangesAsync();

//adatok kiolvasása
//var vehicles = await dbContext.Vehicles.Include(x => x.Color)
//                                       .ToListAsync();
var vehicles = await dbContext.Vehicles.ToListAsync();
PrintVehiclesOnConsole(vehicles);

Console.WriteLine("Done");

void PrintVehiclesOnConsole(ICollection<VehicleEntity> vehicles)
{
    foreach (var vehicle in vehicles)
    {
        Console.WriteLine($"{vehicle.LicencePlate} ({vehicle.Color.Name})");
    }
}