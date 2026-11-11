using System;
using System.Collections.Generic;
using System.Text;

namespace DadJoke.Interfaces
{
    public interface IPopUp
    {
        Task ShowPopup(string title, string message, string buttonText);
    }
}
