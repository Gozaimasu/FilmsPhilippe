using ConsoleApp2.Models;

namespace ConsoleApp2.Processes;

public delegate MovieType AddMusic(MovieType movie, NameType music);

public static class AddMusicExtensions
{
    public static Func<NameType, MovieType> Apply(this AddMusic strategy, MovieType movie) =>
        music => strategy(movie, music);
}

public static class AddMusicDefaults
{
    public static AddMusic AddAnyMusic => (movie, music) =>
        movie with { Music = [.. movie.Music, music] };
    public static AddMusic AddUniqueMusic => (movie, music) =>
        movie.Music.Contains(music)
        ? movie
        : movie with { Music = [.. movie.Music, music] };
}