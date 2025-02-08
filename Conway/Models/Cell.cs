using System.Collections.Generic;
using System.Net.NetworkInformation;
using Avalonia.Media;
using Conway.ViewModels;


namespace Conway.Models {
    class Cell : ViewModelBase {
        public int x {get;}
        public int y {get;}
        public LifeStatus LifeStatus {get; set;}
        public Color Colour {get; set;}
        private static readonly Dictionary<LifeStatus, SolidColorBrush> Colors =
        new()
        {
            //{ LifeStatus.Dead, new SolidColorBrush(Colors.Black) },
            //{ LifeStatus.Active, new SolidColorBrush(Colors.White) }
        };
        
        public Cell(int x, int y) {
            this.x = x;
            this.y = y;
        
        }
    }
}