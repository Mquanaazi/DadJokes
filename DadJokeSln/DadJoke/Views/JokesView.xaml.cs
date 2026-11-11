using DadJoke.ViewModels;


namespace DadJoke.Views;


public partial class JokesView : ContentPage
{
    public JokesView(JokesViewModel VM)
    {
        InitializeComponent();

        BindingContext = VM;

    }
}