using Conway.Models;
using System.Timers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Conway.ViewModels;
public partial class SimulationViewModel : ViewModelBase {
    public int Rows {get;}
    public int Columns {get;}
    private int generations; 
    public int Generations {get => generations;
    set {
        SetProperty(ref generations, value); // @ notes.md
        OnPropertyChanged(nameof(GenerationsText)); // updates the topbar text
    }}
    public ObservableCollection<Cell> Cells { get; } 
    private readonly Timer RunTimer = new(200) { // controls updates with timer for reasonable speed
        Enabled = false
    };
    [ObservableProperty] // !!! observableproperty generates the same field but public
    private string timerText; // TODO: topbar on simulationwindow

    public string GenerationsText => $"{Rows},{Columns}\nCurrently generation {Generations}";
    
    public SimulationViewModel(int rows, int columns, int generations) {
        this.Generations = generations;
        TimerText = "Pause";
        Grid grid = new(rows, columns);

        this.Cells = grid.ParseCells();

        RunTimer.Elapsed += (_, _) => { 
            grid.Update();
            Generations++;
        };
    }

    [RelayCommand]
    public void Run(bool toggle = false) { // should be false when I finish and toggled with a call
        RunTimer.Enabled = toggle == true;
        TimerText = RunTimer.Enabled ? "Pause" : "Run";
    } 
    // run of simulation depends on timer itself, start w enable
}
