using SWIFTcard.ViewModels;

namespace SWIFTcard.Views;

public partial class ManageDecksPage : ContentPage
{
	private ManageDecksViewModel _viewModel;


    public ManageDecksPage(ManageDecksViewModel manageDecksViewModel)
	{
		InitializeComponent();
		_viewModel = manageDecksViewModel;
		BindingContext = _viewModel;
    }
}
