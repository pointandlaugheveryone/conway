using System.Dynamic;
using Conway.Models;

namespace Conway.ViewModels {
    public class Grid : ViewModelBase {
        public int Rows {get; } 
        public int Columns {get; }
        public int Generations {get; set;}
        public Cell[,] Cells {get; }
        private Cell[,] NextGeneration {get; set;}


        public Grid(int rows, int columns) {
            this.Rows = rows;
            this.Columns = columns;
        }
    }
}