using DadJoke.Interfaces;
using DadJoke.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DadJoke.Services
{
    public class ChuckNorriesHttpApiService : IChuckNorriesHttpApiService
    {
        private  IConfigurationServices _configurationServices;
        private HttpClient _httpClient;
        public ChuckNorriesHttpApiService(IConfigurationServices configurationServices)
        {
            _configurationServices = configurationServices;

            _httpClient = new HttpClient();

        }
        public async Task<string> GetChuckJokeAsync()

        {
            HttpResponseMessage response = await _httpClient.GetAsync(_configurationServices.ChuckNorrisApiUrl);
            //return _httpClient.GetStringAsync(_configurationServices .ChuckNorrisApiUrl).Result;

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                ChuckNorrisJoke Joke = JsonSerializer.Deserialize<ChuckNorrisJoke>(jsonContent);
               

                if (Joke != null)
                {
                    return Joke.value;
                }
                else
                {
                    return "No joke found.";
                }
            }
            return null;

        }


    }
}
