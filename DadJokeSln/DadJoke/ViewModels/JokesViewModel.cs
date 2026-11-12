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
    private IPopUp _popUp;

        public JokesViewModel(IDadJokesHttpApiServices service , IPopUp popUp)
        {
            _dadJokeHttpApiServices  = service;
            _popUp = popUp;


            GetJokeCommand = new Command(FetchJoke);
        }
        private async void FetchJoke(object param)
        {

        try
        {
            DadJoke = await _dadJokeHttpApiServices.GetDadJokeAsync();

        }
        catch (Exception e)
        {

            await 
        }
        }
}


