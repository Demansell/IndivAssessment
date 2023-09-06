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
app.MapGet("/api/Song", (IndivAssessmentDbContext db) =>
{
    return db.Songs.ToList();
});


// Add a song
app.MapPost("/api/Song", (IndivAssessmentDbContext db, Song songs) =>
{
    db.Songs.Add(songs);
    db.SaveChanges();
    return Results.Created($"/api/songs/{songs.Id}", songs);
});




/*update song
app.MapPut("api/Song/{id}", async (IndivAssessmentDbContext db, int id, Song song) =>
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
}); */

/* delete song 
app.MapDelete("api/Song/{id}", (IndivAssessmentDbContext db, int id) =>
{
    Song song = db.Songs.SingleOrDefault(song => song.Id == id);
    if (song == null)
    {
        return Results.NotFound();
    }
    db.Songs.Remove(song);
    db.SaveChanges();
    return Results.NoContent();
}); */

/* Get all artists
app.MapGet("/artists", (IndivAssessmentDbContext db) =>
{
    return db.Artists.ToList();
}); */


app.Run();

