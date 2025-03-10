using System.Collections.ObjectModel;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;


namespace Conway.Models;

public partial class Cell : ObservableObject
{
    private bool _isAlive;
    public bool IsAlive
    {
        get => _isAlive;
        set
        {
            // if _isAlive !=value, update the backing field _isAlive with value
            if (SetProperty(ref _isAlive, value))
            {

                CellColor = value ? new SolidColorBrush(Colors.White) : new SolidColorBrush(Colors.Black);
                //TODO: when implementing age, create enum or something with (user defined) colors
            }
        }
    }
    public int X { get; }
    public int Y { get; }

    [ObservableProperty]
    private SolidColorBrush cellColor = new(Colors.Black);
    public int[,] NeighborCoords { get; } = new int[8, 2];


    public Cell(int x, int y, bool isAlive)
    {
        this.X = x;
        this.Y = y;
        _isAlive = !isAlive;
        this.IsAlive = isAlive;
    }

    public void GetNeighborCoords(int rows, int columns)
    {
        int[,] offsets = {
            {-1, -1}, {-1, 0}, {-1, +1},
            {0, -1},            {0, +1},
            {+1, -1}, {+1, 0}, {+1, +1}
        };
        for (int i = 0; i < 8; i++)
        {
            NeighborCoords[i, 0] = (this.X + offsets[i, 0] + rows) % rows;
            NeighborCoords[i, 1] = (this.Y + offsets[i, 1] + columns) % columns;
        }
        // include neighors from opposite of the visible grid for the edge cells
        // yay. A torus-shaped grid.
    }

    public Cell[] GetNeighbors(ObservableCollection<ObservableCollection<Cell>> allCells)
    {
        Cell[] neighbors = new Cell[8];
        for (int i = 0; i < 8; i++)
        {
            int neighborRow = NeighborCoords[i, 0];
            int neighborColumn = NeighborCoords[i, 1];
            neighbors[i] = allCells[neighborRow][neighborColumn];
        }
        return neighbors;
    }
}
