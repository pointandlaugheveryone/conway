using Conway.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Avalonia.Threading;
using System;


namespace Conway.ViewModels;
public partial class SimulationViewModel : ViewModelBase
{
    [ObservableProperty]
    private bool isRunning;
    partial void OnIsRunningChanged(bool value)
    {
        if (value)
        {
            RunTimer.Start();
        }
        else
        {
            RunTimer.Stop();
        }
        TimerText = value ? "Pause" : "Run";
    }
    private int generations;
    private readonly DispatcherTimer RunTimer = new() { IsEnabled = false };
    [ObservableProperty]
    private string timerText = "Run";
    public int Rows { get; }
    public int Columns { get; }
    public ObservableCollection<Cell> Cells { get; private set; }
    public int Generations
    {
        get => generations;
        set
        {
            SetProperty(ref generations, value);
            OnPropertyChanged(nameof(GenerationsText)); // update toggleButton text
        }
    }

    public string GenerationsText => $"{Rows},{Columns}\nCurrently generation {Generations}";

    [RelayCommand]
    private void ToggleRunCommand()
    {
        IsRunning = !IsRunning; // run of simulation depends on timer itself, start w enable
    }
    public SimulationViewModel(int rows, int columns, int generations)
    {
        this.Rows = rows;
        this.Columns = columns;
        this.Generations = generations;

        Grid grid = new(rows, columns);
        Cells = grid.GenerateNext();
        RunTimer.Interval = TimeSpan.FromMilliseconds(200);
        RunTimer.Tick += (_, _) =>
        {
            Cells = grid.GenerateNext();
            Generations++;
        };
    }
}
