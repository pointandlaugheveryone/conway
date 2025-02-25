using System.Linq;


namespace Conway.Models;
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

        // Get neighbor coordinates to access
        for (int row = 0; row <= rows; row++) {
            for (int column = 0; column <= columns; column++) {
                this.Cells[row, column] = new Cell(row, column, System.Random.Shared.NextDouble() > 0.7 ); // randomise alive/dead at init
                this.Cells[row, column].GetNeighborCoords(rows, columns);
            }
        }
        // TODO: timer
    }


    private void GenerateNextGen() { //age- which cells die, 
        for (int row = 0; row < this.Rows; row++) {
            for (int column = 0; column < this.Columns; column++) {

                Cell currentCell = this.Cells[row, column];
                Cell[] Neighbors = currentCell.GetNeighbors(Cells);
                int AliveNeighbors = Neighbors.Where(cell => cell.IsAlive == true).Count();
                
                bool nextIsAlive = false;
                if (
                    ((currentCell.IsAlive == true) && 
                    (AliveNeighbors == 2  || AliveNeighbors == 3)) ||
                    ((currentCell.IsAlive == false) && 
                    (AliveNeighbors == 3))
                    ) 
                    { nextIsAlive = true;
                }

                
                currentCell.UpdateColor();
                NextGeneration[row, column] = new Cell(row, column, nextIsAlive);
            }
        }
    }

    public void Run() {
        for (int generation = 0; generation < Generations; generation++) {
            GenerateNextGen();
            
            for (int row = 0; row < this.Rows; row++) {
                for (int column = 0; column < this.Columns; column++) {
                    this.Cells[row, column] = this.NextGeneration[row, column];
                }
            }
        }
    }

    public void Randomise() {
        for (int row = 0; row <= Rows; row++) {
            for (int column = 0; column <= Columns; column++) {
                // Cells[row, column].Age = 0;
                Cells[row, column].IsAlive = System.Random.Shared.NextDouble() > 0.7;
            }
        }
    }
}
