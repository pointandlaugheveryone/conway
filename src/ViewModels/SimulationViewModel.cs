using Conway.Models;
using System.Timers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Avalonia.Threading;
using System;


namespace Conway.ViewModels;
public partial class SimulationViewModel : ViewModelBase {
    [ObservableProperty]
    private bool isRunning;
    partial void OnIsRunningChanged(bool value) { 
        if (value) {
            RunTimer.Start();
            Console.WriteLine("Timer started");
        }
        else {
            RunTimer.Stop();
            Console.WriteLine("Timer stopped");
        }
        TimerText = value ? "Pause" : "Run"; 
    }
    private int generations; 
    private readonly DispatcherTimer RunTimer = new() { IsEnabled = false };
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
        Console.WriteLine("IsRunning changed");
    }
    public SimulationViewModel(int rows, int columns, int generations) {
        this.Rows = rows;
        this.Columns = columns;
        this.Generations = generations;
        
        Grid grid = new(rows, columns);
        Cells = grid.ParseCells();
        RunTimer.Interval = TimeSpan.FromMilliseconds(200);
        RunTimer.Tick += (_, _) => { 
            grid.GenerateNextGen();
            Generations++;
            Console.WriteLine("Generation updated");
        };
        Console.WriteLine("SimulationWindow init");
    }
}
