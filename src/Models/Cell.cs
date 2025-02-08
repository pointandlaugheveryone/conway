using System.Collections.Generic;
using System.Net.NetworkInformation;
using Avalonia.Media;
using Conway.ViewModels;
using Metsys.Bson;


namespace Conway.Models {
    public class Cell : ViewModelBase {
        public int X {get;}
        public int Y {get;}
        public bool IsAlive {get; set;}
        public int Age {get; set;}
        public SolidColorBrush Colour {get; set;}

        public Cell(int x, int y) {
            this.X = x;
            this.Y = y;
            // IsAlive = Helper.RandomiseLife();
            Age = 1;
            Colour = IsAlive ? new SolidColorBrush(Colors.White) : new SolidColorBrush(Colors.Black);
        }
    }

    /**
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