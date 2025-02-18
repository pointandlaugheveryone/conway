using System.Collections.Generic;
using System.Net.NetworkInformation;
using Avalonia.Media;
using Conway.ViewModels;
using Metsys.Bson;


namespace Conway.Models {
    public class Cell {
        public int X {get;}
        public int Y {get;}
        public bool IsAlive {get; set;}
        public int Age {get; set;}
        public SolidColorBrush Colour {get; set;}
        public int[,] Neighbors {get;} = new int[8,2];

        public Cell(int x, int y, bool isAlive) {
            this.X = x;
            this.Y = y;
            this.IsAlive = isAlive;
            Age = 1;
            Colour = IsAlive ? new SolidColorBrush(Colors.White) : new SolidColorBrush(Colors.Black);
        }

        public void GetNeighborCoords(int rows, int columns) {
            int[,] offsets = { 
                {-1, -1}, {-1, 0}, {-1, +1}, 
                {0, -1},            {0, +1}, 
                {+1, -1}, {+1, 0}, {+1, +1} 
            };
            for (int i = 0; i < 8; i++) {  // wrap-around edges indexing; NOTE: do not refactor
                Neighbors[i,0] = (this.X + offsets[i,0] + rows) % rows;
                Neighbors[i,1] = (this.Y + offsets[i,1] + columns) % columns;
            }
        }
    }

    /**
    TODO: maybe eventually expand this to a different simulation type

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
}