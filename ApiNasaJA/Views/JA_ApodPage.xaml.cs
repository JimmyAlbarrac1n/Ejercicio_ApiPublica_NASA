using ApiNasaJA.ViewModels;

namespace ApiNasaJA.Views;

public partial class JA_ApodPage : ContentPage
{
	public JA_ApodPage()
	{
		InitializeComponent();
        BindingContext = new JA_ApodViewModel();
    }

}