using Microsoft.EntityFrameworkCore;
using IndivAssessment.Models;
public class IndivAssessmentDbContext : DbContext
{

    public DbSet<Artist>? Artists { get; set; }
    public DbSet<Genre>? Genres { get; set; }
    public DbSet<Song>? Songs { get; set; }
    public DbSet<SongGenre>? SongGenre { get; set; }

    public IndivAssessmentDbContext(DbContextOptions<IndivAssessmentDbContext> context) : base(context)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artist>().HasData(new Artist[]
        {
            new Artist { Id = 1, Name = "Michael Jackson", Age = 27, Bio = "Sample Bio" },
            new Artist { Id = 2, Name = "Elvis", Age = 50, Bio = "Sample Bio" },
            new Artist { Id = 3, Name = "Montana of 300", Age = 32, Bio = "Sample Bio" },
            new Artist { Id = 4, Name = "Lil Wayne", Age = 29, Bio = "Sample Bio" },
        });
        _ = modelBuilder.Entity<Song>().HasData(new Song[]
        {
               new Song { Id = 1, Title = "Beat it", ArtistId = 1, Album = "Thriller 25", Length = 110 },
               new Song { Id = 2, Title = "Jail house rock", ArtistId = 2, Album = "Jail house rock", Length = 130 },
               new Song { Id = 3, Title = "Fire in the church", ArtistId = 3, Album = "Fire in the church", Length = 170 },
               new Song { Id = 4, Title = "A mili", ArtistId = 4, Album = "Tha carter 3", Length = 140 }
           });
        modelBuilder.Entity<Genre>().HasData(new Genre[]
        {
            new Genre { Id = 1, Description = "This is pop"},
            new Genre { Id = 2, Description = "This is rock"},
            new Genre { Id = 3, Description = "This is drill rap"},
            new Genre { Id = 4, Description = "This is hip hop"}
        });
        modelBuilder.Entity<SongGenre>().HasData(new SongGenre[]
            {
                new SongGenre { Id = 1, GenreId = 1, SongId = 1 },
                new SongGenre { Id = 2, GenreId = 2, SongId = 2 },
                new SongGenre { Id = 3, GenreId = 3, SongId = 3 },
                new SongGenre { Id = 4, GenreId = 4, SongId = 4 }
                });
    }
}