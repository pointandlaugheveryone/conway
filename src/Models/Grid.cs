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
                    // randomise alive/dead at init
                    this.Cells[row, column] = new Cell(row, column, System.Random.Shared.NextDouble() > 0.7 );
                }
            }
        }
    }
}