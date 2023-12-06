namespace SWIFTcard.Views;

public partial class CardDetailPage : ContentPage
{
	public CardDetailPage()
	{
		InitializeComponent();
    }

    void OnSwipedDown(System.Object sender, Microsoft.Maui.Controls.SwipedEventArgs e)
    {
        Navigation.PopModalAsync();
    }
}
