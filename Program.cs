using IndivAssessment.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<IndivAssessmentDbContext>(builder.Configuration["IndivAssessmentDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//get songs
app.MapGet("/IndivAssessment/Song", (IndivAssessmentDbContext db) =>
{
    return db.Songs.ToList();
});


// Add a song
app.MapPost("api/Songs", async (IndivAssessmentDbContext db, Song song) =>
{
    db.Songs.Add(song);
    db.SaveChanges();
    return Results.Created($"/api/songs{song.Id}", song);
});

//Assign a Genre to a song
app.MapPost("/api/SongGenre", (IndivAssessmentDbContext db, int songId, int genreId) =>
{
    var getSong = db.Songs.FirstOrDefault(s => s.Id == songId);
    var getGenre = db.Genres.FirstOrDefault(g => g.Id == genreId);
    if (getSong.Genres == null)
    {
        getSong.Genres = new List<Genre>();
    }

    getSong.Genres.Add(getGenre);
    db.SaveChanges();
    return getSong;


});

//Details view of a single Song and its associated genres and artist details

app.MapGet("/api/SongsDetails", (IndivAssessmentDbContext db, int id) =>
{
    var song = db.Songs.Where(s => s.Id == id)
    .Include(x => x.Genres)
    .Include(s => s.Artist).ToList();

    return song;
}
);


//update song
app.MapPut("api/Songs/{id}", async (IndivAssessmentDbContext db, int id, Song song) =>
{
    Song songToUpdate = await db.Songs.SingleOrDefaultAsync(song => song.Id == id);
    if (songToUpdate == null)
    {
        return Results.NotFound();
    }
    songToUpdate.Id = song.Id;
    songToUpdate.ArtistId = song.ArtistId;
    songToUpdate.Album = song.Album;
    songToUpdate.Length = song.Length;
    songToUpdate.Title = song.Title;
    db.SaveChanges();
    return Results.NoContent();
}); 

// delete song 
app.MapDelete("api/Songs/{id}", (IndivAssessmentDbContext db, int id) =>
{
    Song song = db.Songs.SingleOrDefault(song => song.Id == id);
    if (song == null)
    {
        return Results.NotFound();
    }
    db.Songs.Remove(song);
    db.SaveChanges();
    return Results.NoContent();
}); 

// Get all artists
app.MapGet("/Artists", (IndivAssessmentDbContext db) =>
{
    return db.Artists.ToList();
});

//Details view of a single Artist and the songs associated with them
app.MapGet("/api/artist/{id}", (IndivAssessmentDbContext db, int id) =>
{
    var artist = db.Artists.Where(a => a.Id == id).Include(x => x.Songs).FirstOrDefault();
    return artist;
});

//post artists 
app.MapPost("api/Artists", async (IndivAssessmentDbContext db, Artist artist) =>
{
    db.Artists.Add(artist);
    db.SaveChanges();
    return Results.Created($"/api/artists{artist.Id}", artist);
});

//update artists
app.MapPut("api/Artists/{id}", async (IndivAssessmentDbContext db, int id, Artist artist) =>
{
    Artist artistToUpdate = await db.Artists.SingleOrDefaultAsync(artist => artist.Id == id);
    if (artistToUpdate == null)
    {
        return Results.NotFound();
    }
    artistToUpdate.Id = artist.Id;
    artistToUpdate.Name = artist.Name;
    artistToUpdate.Age = artist.Age;
    artistToUpdate.Bio = artist.Bio;
    db.SaveChanges();
    return Results.NoContent();
});

// delete artist 
app.MapDelete("api/Artists/{id}", (IndivAssessmentDbContext db, int id) =>
{
    Artist artist = db.Artists.SingleOrDefault(artist => artist.Id == id);
    if (artist == null)
    {
        return Results.NotFound();
    }
    db.Artists.Remove(artist);
    db.SaveChanges();
    return Results.NoContent();
});

// get genre 
app.MapGet("/Genres", (IndivAssessmentDbContext db) =>
{
    return db.Genres.ToList();
});

//Details view of a single Genre and the songs associated with it
app.MapGet("/api/genre/{id}", (IndivAssessmentDbContext db, int id) =>
{
    var genre = db.Genres.Where(g => g.Id == id).Include(x => x.Songs).FirstOrDefault();
    return genre;
});

//post Genre
app.MapPost("api/Genre", async (IndivAssessmentDbContext db, Genre genre) =>
{
    db.Genres.Add(genre);
    db.SaveChanges();
    return Results.Created($"/api/artists{genre.Id}", genre);
});

// update genre
app.MapPut("api/Genres/{id}", async (IndivAssessmentDbContext db, int id, Genre genre) =>
{
    Genre genreToUpdate = await db.Genres.SingleOrDefaultAsync(genre => genre.Id == id);
    if (genreToUpdate == null)
    {
        return Results.NotFound();
    }
    genreToUpdate.Id = genre.Id;
    genreToUpdate.Description = genre.Description;

    db.SaveChanges();
    return Results.NoContent();
});

// delete artist 
app.MapDelete("api/Genres/{id}", (IndivAssessmentDbContext db, int id) =>
{
    Genre genre = db.Genres.SingleOrDefault(genre => genre.Id == id);
    if (genre == null)
    {
        return Results.NotFound();
    }
    db.Genres.Remove(genre);
    db.SaveChanges();
    return Results.NoContent();
});

app.Run();

