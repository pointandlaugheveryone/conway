using Conway.Models;
using System.Timers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace Conway.ViewModels;
public partial class SimulationViewModel : ViewModelBase {
    [ObservableProperty]
    private bool isRunning;
    partial void OnIsRunningChanged(bool value) { // needs to be partial
        RunTimer.Enabled = value; 
        TimerText = value ? "Pause" : "Run"; // controls updates with timer ; reasonable speed
    }
    private int generations; 
    private readonly Timer RunTimer = new(200) { Enabled = false };
    [ObservableProperty] // @ notes.md
    private string timerText = "Run"; 
    public int Rows {get;}
    public int Columns {get;}
    public ObservableCollection<Cell> Cells { get; }
    public int Generations {
        get => generations;
        set {
            SetProperty(ref generations, value); // @ notes.md
            OnPropertyChanged(nameof(GenerationsText)); // update toggleButton text
        }
    }
     
    public string GenerationsText => $"{Rows},{Columns}\nCurrently generation {Generations}";
    
    [RelayCommand]
    private void ToggleRun()
    {
        IsRunning = !IsRunning; // run of simulation depends on timer itself, start w enable
    }
    public SimulationViewModel(int rows, int columns, int generations) {
        this.Rows = rows;
        this.Columns = columns;
        this.Generations = generations;
        
        Grid grid = new(rows, columns);
        Cells = grid.ParseCells();

        RunTimer.Elapsed += (_, _) => { 
            grid.GenerateNextGen();
            Generations++;
        };
    }
}
