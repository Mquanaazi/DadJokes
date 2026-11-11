using System;
using System.Collections.Generic;
using System.Text;

namespace DadJoke.Interfaces
{
    internal interface IPopUp
    {
        Task ShowPopup(string title, string message, string buttonText);
    }
}
