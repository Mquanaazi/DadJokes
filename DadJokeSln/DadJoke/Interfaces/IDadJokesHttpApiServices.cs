using System;
using System.Collections.Generic;
using System.Text;

namespace DadJoke.Interfaces
{
    public interface IDadJokesHttpApiServices
    {
        Task<string> GetDadJokeAsync();
    }
}
