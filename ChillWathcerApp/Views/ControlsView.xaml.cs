using ChillWathcerApp.ViewModels;

namespace ChillWathcerApp.Views;

public partial class ControlsView : ContentPage
{
	public readonly ControlViewModel viewModel;
	public ControlsView(ControlViewModel model)
	{
		InitializeComponent();
		viewModel = model;
		BindingContext = viewModel;
	}
}