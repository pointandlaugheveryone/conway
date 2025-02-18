using System.Linq;

namespace Conway.Models {
    public class Grid {
        public int Rows {get; } 
        public int Columns {get; }
        public int Generations {get; set;}
        public Cell[,] Cells {get; }
        private Cell[,] NextGeneration {get; set;}

        public Grid(int rows, int columns, int generations) {
            this.Rows = rows;
            this.Columns = columns;
            Cells = new Cell[rows, columns];

            NextGeneration = new Cell[rows, columns];
            this.Generations = generations;

            for (int row = 0; row <= rows; row++) {
                for (int column = 0; column <= columns; column++) {
                    this.Cells[row, column] = new Cell(row, column, System.Random.Shared.NextDouble() > 0.7 ); // randomise alive/dead at init
                    this.Cells[row, column].GetNeighborCoords(rows, columns);
                }
            }
            // TODO: timer
        }

        // add [relaycommand] later
        public void Randomise() {
            Generations = 0;
            for (int row = 0; row <= Rows; row++) {
                for (int column = 0; column <= Columns; column++) {
                    Cells[row, column].Age = 0;
                    Cells[row, column].IsAlive = System.Random.Shared.NextDouble() > 0.7;
                }
            }
        }

        public void GenerateNextGen() { //age- which cells die, 

        }
    }
}