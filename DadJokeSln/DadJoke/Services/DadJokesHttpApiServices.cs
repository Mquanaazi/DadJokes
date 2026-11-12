using System;
using System.Collections.Generic;
using System.Text;
//using System.Net.Http.Json;
using System.Text.Json;
//using System.Text.Json.Serialization;
using DadJoke.Models;
using System.Net.Http.Headers;
using DadJoke.Interfaces;


namespace DadJoke.Services
{
    public class DadJokesHttpApiServices : IDadJokesHttpApiServices
    {
        private HttpClient _httpClient;
        private IConfigurationServices _configurationServices;
        public DadJokesHttpApiServices(IConfigurationServices configurationService)
        {
            _configurationServices = configurationService;

            _httpClient = new HttpClient();

            _httpClient.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue("application/json"));

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
