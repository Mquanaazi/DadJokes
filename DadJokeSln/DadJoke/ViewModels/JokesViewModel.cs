using DadJoke.Interfaces;
using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Input;

namespace DadJoke.ViewModels;
public class JokesViewModel : BaseViewModel
{
    private string _dadJoke;

    public ICommand GetJokeCommand { get; }

    public string DadJoke
    {
        get { return _dadJoke; }
        set
        {
            _dadJoke = value;
            OnPropertyChanged();
        }
    }


        private IDadJokesHttpApiServices _dadJokeHttpApiServices;
        public JokesViewModel(IDadJokesHttpApiServices service)
        {
            _dadJokeHttpApiServices  = service;


            GetJokeCommand = new Command(FetchJoke);
        }
        private async void FetchJoke(object param)
        {
            DadJoke = await _dadJokeHttpApiServices.GetDadJokeAsync();
        }
}


