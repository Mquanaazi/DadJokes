namespace DadJoke.Interfaces
{
    public interface IChuckNorriesHttpApiService
    {
        Task<string> GetChuckJokeAsync();
    }
}