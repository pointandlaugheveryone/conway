using CommunityToolkit.Mvvm.Input;
using Conway.Views;

namespace Conway.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{ 
// TODO: entry menu with text & simulation settings 
    [RelayCommand]
    public void RunSimulationCommand() {
        SimulationViewModel simulationViewModel = new(20,20,100);

        var simulationWindow = new SimulationWindow { // set the window to show with binding to simulationvm
            DataContext = simulationViewModel
        };
        simulationWindow.Show();
    }
}
