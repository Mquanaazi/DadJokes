using DadJoke.Interfaces;
using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Input;

namespace DadJoke.ViewModels;
public class JokesViewModel : BaseViewModel
{
    private string _dadJoke;
    private string _ChuckJoke;

    public ICommand GetJokeCommand { get; set; }
    //public ICommand GetChuckJokeCommand { get; set; }


    public string DadJoke
    {
        get { return _dadJoke; }
        set
        {
            _dadJoke = value;
            OnPropertyChanged();
        }
    }

    public string ChuckJoke
    {
        get { return _ChuckJoke; }
        set
        {
            _ChuckJoke = value;
            OnPropertyChanged();
        }
    }

    private IDadJokesHttpApiServices _dadJokeHttpApiServices;
    private IChuckNorriesHttpApiService _chuckNorriesHttpApiService;
    private IPopUp _popUp;

        public JokesViewModel(IDadJokesHttpApiServices service, IChuckNorriesHttpApiService chuckNorriesHttpApiService , IPopUp popUp)
        {
            _dadJokeHttpApiServices  = service;
            _chuckNorriesHttpApiService = chuckNorriesHttpApiService;
            _popUp = popUp;


            GetJokeCommand = new Command(FetchJoke);
            //GetChuckJokeCommand = new Command(FetchChuckJoke);
        }
    private async void FetchJoke(object param)
    {

        try
        {
            DadJoke = await _dadJokeHttpApiServices.GetDadJokeAsync();

        }
        catch (Exception e)
        {

            await _popUp.ShowPopup("Error", e.Message, "OK");
        }

        try
        {
            DadJoke = await _chuckNorriesHttpApiService.GetChuckJokeAsync();

        }
        catch (Exception e)
        {

            await _popUp.ShowPopup("Error", e.Message, "OK");
        }
        /*finally
        {
            IsBusy = false;
       
    }
        private async void FetchChuckJoke(object param)
    {

        try
        {
            DadJoke = await _chuckNorriesHttpApiService.GetChuckJokeAsync();

        }
        catch (Exception e)
        {

            await _popUp.ShowPopup("Error", e.Message, "OK");
        }*/
    }
}


