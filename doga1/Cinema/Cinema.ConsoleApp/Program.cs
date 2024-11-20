using Cinema_Database;
using Cinema_Database.Entities;

using var dbContext = new ApplicationDBContext();

await AddCinemaToDbAsync();
Console.WriteLine("Done");

async Task AddCinemaToDbAsync()
{
    MovieEntity movie = new MovieEntity
    {
        Title = "Interstellar",
        Playtime = 169,
        StartOfShowing = DateTime.Parse("2014-11-06"),
        EndOfShowing = DateTime.Now,
        AgeRestriction = "18+",
        Description = "Sci-fi movie, time-travel, blackhole",
        HasSubtitles = true,
        GenreId = 1,
        LanguageId = 1
    };

    await dbContext.AddAsync(movie);
    await dbContext.SaveChangesAsync();
}