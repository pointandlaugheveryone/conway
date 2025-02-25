using System.Dynamic;
using Conway.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace Conway.ViewModels;
public partial class Simulation : ViewModelBase {
    public int Rows {get;}
    public int Columns {get;}
    public int Generations;
    public string GenerationsText => $"{Rows},{Columns}\nCurrently generation {Generations}";
    
    public Simulation(int rows, int columns, int generations) {
        Grid grid = new(rows, columns, generations);
        grid.Run();
    }
}
