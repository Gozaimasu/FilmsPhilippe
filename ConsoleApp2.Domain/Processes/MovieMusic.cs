namespace ConsoleApp2.Domain.Processes;

public static class AddMusicDefaults
{
    public static AddParticipant AddAnyMusic => (movie, music) =>
        movie with { Music = [.. movie.Music, music] };
    public static AddParticipant AddUniqueMusic => (movie, music) =>
        movie.Music.Contains(music)
        ? movie
        : movie with { Music = [.. movie.Music, music] };
}