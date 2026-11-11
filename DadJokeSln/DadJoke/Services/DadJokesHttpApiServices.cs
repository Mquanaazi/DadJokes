using DadJoke.Interfaces;
using DadJoke.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace DadJoke.Services
{
    public class DadJokesHttpApiServices : IDadJokesHttpApiServices
    {
        private IConfigurationServices _configurationServices;
        private HttpClient _httpClient;
        public DadJokesHttpApiServices(IConfigurationServices configurationService)
        {
            _configurationServices = configurationService;

            _httpClient = new HttpClient();

        }

        public async Task<string> GetDadJokeAsync()
        {
            {
                HttpResponseMessage response = await _httpClient.GetAsync(_configurationServices.DadJokesApiUrl);
                //return _httpClient.GetStringAsync(_configurationService.ChuckNorrisApiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = await response.Content.ReadAsStringAsync();
                    DadJokeContent Joke = JsonSerializer.Deserialize<DadJokeContent>(jsonContent);

                    if (Joke != null)
                    {
                        return Joke.joke;
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
}
