using var dbContext = new ApplicationDbContext();

//adat hozzáadása az adatbázishoz
//var vehicle = new VehicleEntity
//{
//    ChassisNumber = "ioplghjklq2345tr5",
//    EngineNumber = "df",
//    LicencePlate = "CCEE123",
//    NumberOfDoors = 5,
//    Power = 140,
//    Weight = 1500,
//    ColorId = 2,
//    ModelId = 1
//}; //így ha kell az id. lehet az addasyncbe is tenni ezeket

//await dbContext.Vehicles.AddAsync(vehicle);
//await dbContext.SaveChangesAsync();//változtatások elmentése

//rekord módosítása, 
//var vehicle = await dbContext.Vehicles.FindAsync((uint)1);
//vehicle.ChassisNumber = "11111111111111111";

//törlése
//dbContext.Vehicles.Remove(vehicle);
//await dbContext.SaveChangesAsync();

//adatok kiolvasása
//var vehicles = await dbContext.Vehicles.Include(x => x.Color)
//.ToListAsync();
//var vehicles = await dbContext.Vehicles.ToListAsync();
//PrintVehiclesOnConsole(vehicles);

//Console.WriteLine("Done");

//await AddFirstVehicleToDBAsync();
//await AddSecondVehicleToDB();
//var vehicles = await dbContext.Vehicles.Include(vehicle => vehicle.Color)
//                                       .Include(vehicle => vehicle.Model)
//                                        .ThenInclude(model => model.Manufacturer)
//                                       .ToListAsync();//listába tevés, előtte nincs tényleges adat csak egy query

//PrintVehiclesOnConsole(vehicles);

//var vehicle = await dbContext.Vehicles.Include(vehicle => vehicle.Color)
//                                       .Include(vehicle => vehicle.Model)
//                                        .ThenInclude(model => model.Manufacturer)
//                                       .FirstAsync(x => x.Id == 1);
//PrintVehicleOnConsole(vehicle);

//await AddFirstVehicleToDBAsync();
await AddSecondVehicleToDB();

var vehicles = await dbContext.Vehicles.Include(vehicle => vehicle.Color)
                                      .Include(vehicle => vehicle.FormOfUse)
                                      .Include(vehicle => vehicle.Model)
                                      .ThenInclude(model => model.Manufacturer)
                                      .ToListAsync();

PrintVehiclesOnConsole(vehicles);

Console.WriteLine("Done");

async Task AddFirstVehicleToDBAsync()
{
    ManufacturerEntity manufacturer = new ManufacturerEntity
    {
        Name = "Mazda"
    };

    await dbContext.Manufacturers.AddAsync(manufacturer);
    await dbContext.SaveChangesAsync();

    ModelEntity model = new ModelEntity
    {
        ModelName = "2 DE",
        ManufacturerId = manufacturer.Id,
    };

    await dbContext.Models.AddAsync(model);
    await dbContext.SaveChangesAsync();

    VehicleEntity vehicle = new VehicleEntity
    {
        ChassisNumber = "asdfghjklqwertzui",
        ColorId = 1,
        EngineNumber = "ZK",
        LicencePlate = "AABB678",
        ModelId = 1,
        NumberOfDoors = 5,
        Power = 86,
        Weight = 990,
        FormOfUseId = 1
    };

    await dbContext.Vehicles.AddAsync(vehicle);
    await dbContext.SaveChangesAsync();
}

async Task AddSecondVehicleToDB()
{
    VehicleEntity vehicle = new VehicleEntity
    {
        ChassisNumber = "123456789asdfgerd",
        EngineNumber = "WE",
        LicencePlate = "KKLL123",
        NumberOfDoors = 2,
        Power = 1500,
        Weight = 4000,
        ColorId = 3,
        Model = new ModelEntity
        {
            ModelName = "260 Harmonika",
            Manufacturer = new ManufacturerEntity
            {
                Name = "Ikarus"
            }
        },
        FormOfUseId = 2,
        TypeId = 1
    };

    await dbContext.Vehicles.AddAsync(vehicle);
    await dbContext.SaveChangesAsync();
}

void PrintVehiclesOnConsole(ICollection<VehicleEntity> vehicles)
{
    foreach (var vehicle in vehicles)
    {
        PrintVehicleOnConsole(vehicle);
    }
}

void PrintVehicleOnConsole(VehicleEntity vehicle)
{
    Console.WriteLine(
        $"{vehicle?.LicencePlate} " +
        $"{vehicle?.Model?.Manufacturer?.Name} " +
        $"{vehicle?.Model?.ModelName} " +
        $"({vehicle?.Color?.Name})" +
        $"{vehicle?.FormOfUse?.Name}"
        );
}