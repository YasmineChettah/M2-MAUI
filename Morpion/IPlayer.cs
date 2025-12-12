public interface IPlayer
{
    char Symbol { get; }
    int[] GetNextMove();
}