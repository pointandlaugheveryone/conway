using CommunityToolkit.Mvvm.Input;
using Conway.Views;


// a lot TODO here
namespace Conway.ViewModels;
public partial class MainWindowViewModel : ViewModelBase
{
    [RelayCommand]
    public void RunSimulationCommand()
    {
        SimulationViewModel simulationViewModel = new(100, 100, 50); //TODO: user sets the parameters

        var simulationWindow = new SimulationWindow
        { // needed set the window to show with binding to vm
            DataContext = simulationViewModel
        };
        simulationWindow.Show();
    }
}
