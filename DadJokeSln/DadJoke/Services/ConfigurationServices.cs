using DadJoke.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DadJoke.Services
{
    public class ConfigurationService : IConfigurationServices
    {
      public string DadJokesApiUrl { get; }

        public ConfigurationService()
        {
            DadJokesApiUrl = "https://icanhazdadjoke.com/";
        }
    }
}
