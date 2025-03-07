using Conway.Models;
using System.Timers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace Conway.ViewModels;
public partial class SimulationViewModel : ViewModelBase {
    public int Rows {get;}
    public int Columns {get;}
    public int Generations;
    private readonly Timer RunTimer = new Timer(200) { 
        Enabled = false
    };
    //[ObservableProperty]
    string TimerText;
    //[ObservableProperty]
    public string GenerationsText => $"{Rows},{Columns}\nCurrently generation {Generations}";
    
    public SimulationViewModel(int rows, int columns, int generations) {
        this.Generations = generations;
        TimerText = "Pause";
        Grid grid = new(rows, columns);

        RunTimer.Elapsed += (_, _) => {
            grid.Update();
            Generations++;
        };
    }
    [RelayCommand]
    public void Run(bool toggle = false) {
        RunTimer.Enabled = toggle == true;
        TimerText = RunTimer.Enabled ? "Pause" : "Run";
    }
}
