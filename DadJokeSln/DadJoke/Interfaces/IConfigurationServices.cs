using System;
using System.Collections.Generic;
using System.Text;

namespace DadJoke.Interfaces
{
    public interface IConfigurationServices
    {
        string DadJokesApiUrl { get; }
        string ChuckNorrisApiUrl { get; }
    }
}
