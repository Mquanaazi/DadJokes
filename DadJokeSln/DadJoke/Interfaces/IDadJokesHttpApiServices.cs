using System;
using System.Collections.Generic;
using System.Text;

namespace DadJoke.Interfaces
{
    internal interface IDadJokesHttpApiServices
    {
        Task<string> GetDadJoke();
    }
}
