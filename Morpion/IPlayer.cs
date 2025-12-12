public interface IPlayer
{
    char Symbol { get; }
    Task<int[]> GetNextMove();
}