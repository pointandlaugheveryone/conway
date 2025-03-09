using Avalonia.Media;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System;


namespace Conway.Models;

public partial class Cell : ObservableObject {
    private bool _isAlive;
    public bool IsAlive {
        get => _isAlive;
        set {
            if (SetProperty(ref _isAlive, value)) {
                var brushResourceKey = value ? "AliveColor" : "DeadColor";
                if (Application.Current!.Resources.TryGetValue(brushResourceKey, out var resource)) {
                    if (resource is Color color)
                        CellColor = new SolidColorBrush(color);
                    else if (resource is SolidColorBrush sb)
                        CellColor = new SolidColorBrush(sb.Color);
                }
                else {
                    // Fallback colors if resource isn't defined
                    CellColor = value ? new SolidColorBrush(Colors.White) : new SolidColorBrush(Colors.Black);
                }
            }
        }
    }
    public int X {get;}
    public int Y {get;}

    [ObservableProperty]
    private SolidColorBrush cellColor = new SolidColorBrush(Colors.Black);
    public int[,] NeighborCoords {get;} = new int[8,2];


    public Cell(int x, int y, bool isAlive) {
        this.X = x;
        this.Y = y;
        _isAlive = !isAlive;
        this.IsAlive = isAlive;
    }

    public void GetNeighborCoords(int rows, int columns) {
        int[,] offsets = { 
            {-1, -1}, {-1, 0}, {-1, +1}, 
            {0, -1},            {0, +1}, 
            {+1, -1}, {+1, 0}, {+1, +1} 
        };
        // to include neighors from opposite of the visible grid for the edge cells
        // basically a torus-shaped grid
        for (int i = 0; i < 8; i++) {
            NeighborCoords[i,0] = (this.X + offsets[i,0] + rows) % rows;
            NeighborCoords[i,1] = (this.Y + offsets[i,1] + columns) % columns;
        } 
    }

    public Cell[] GetNeighbors(Cell[,] allCells) {
        Cell[] Neighbors = new Cell[8];
        for (int i = 0; i < 8; i++) {
            Neighbors[i] = allCells[NeighborCoords[i,0], NeighborCoords[i,1]];
        }
        return Neighbors;
    }
}
