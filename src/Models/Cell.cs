using Avalonia.Media;
using Avalonia;


namespace Conway.Models;
public class Cell {
    public int X {get;}
    public int Y {get;}
    public bool IsAlive {get; set;}
    // public int Age {get; set;}       Part of a different simulation, possibly add later
    public SolidColorBrush CellColor {get; set;}
    private SolidColorBrush AliveColor = (SolidColorBrush)Application.Current!.Resources["AliveColor"]!;
    private SolidColorBrush deadColor = (SolidColorBrush)Application.Current.Resources["DeadColor"]!;
    public int[,] NeighborCoords {get;} = new int[8,2];


    public Cell(int x, int y, bool isAlive) {
        this.X = x;
        this.Y = y;
        this.IsAlive = isAlive;
        //Age = 1;
        CellColor = IsAlive ? new SolidColorBrush(Colors.White) : new SolidColorBrush(Colors.Black);
    }

    public void GetNeighborCoords(int rows, int columns) {
        int[,] offsets = { 
            {-1, -1}, {-1, 0}, {-1, +1}, 
            {0, -1},            {0, +1}, 
            {+1, -1}, {+1, 0}, {+1, +1} 
        };
        for (int i = 0; i < 8; i++) {  // wrap-around edges indexing; NOTE: do not refactor
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

    public void UpdateColor() {
        CellColor = (IsAlive == true) ? AliveColor : deadColor;
    }
}

/**
TODO: Cyclic cellular automata

class ColorCell : Cell {
    private static readonly List<\SolidColorBrush> ColorMap =  // indexed based on Age property to assign color 
    new()
    {
        { new SolidColorBrush(Colors.Color0) },
        { new SolidColorBrush(Colors.Color1) },
        { new SolidColorBrush(Colors.Color2) },
        { new SolidColorBrush(Colors.Color3) }
    };
    
    public ColorCell(int x, int y) : base(x, y) {
        LifeStatus = Helper.RandomiseLife()
    }
}
**/
