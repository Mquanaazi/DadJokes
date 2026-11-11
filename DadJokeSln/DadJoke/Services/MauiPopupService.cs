using DadJoke.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DadJoke.Services
{
    internal class MauiPopupService : IPopUp
    {
        public async Task ShowPopup(string title, string message, string buttonText)
        {
           await Shell.Current.DisplayAlertAsync(title,message, buttonText);
           
        }
    }
}
