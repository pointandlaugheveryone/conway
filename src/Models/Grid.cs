using System.Collections.ObjectModel;
using System.Linq;


namespace Conway.Models;
public class Grid {
    public int Rows {get; } 
    public int Columns {get; }
    public Cell[,] Cells {get; }
    private Cell[,] NextGeneration {get; set;}

    public Grid(int rows, int columns) {
        this.Rows = rows;
        this.Columns = columns;
        Cells = new Cell[rows, columns];

        NextGeneration = new Cell[rows, columns];

        for (int row = 0; row < rows; row++) {
            for (int column = 0; column < columns; column++) {
                this.Cells[row, column] = new Cell(row, column, System.Random.Shared.NextDouble() > 0.7 ); // randomise alive/dead at init
                this.Cells[row, column].GetNeighborCoords(rows, columns);
            }
        }
        // TODO: timer
    }

    public ObservableCollection<Cell> ParseCells() {   // literally just to convert it because avalonia
        ObservableCollection<Cell> cellList = new();
        for (int row = 0; row < Rows; row++) {
            for (int column = 0; column < Columns; column++) {
                cellList.Add(Cells[row, column]);
            }
        }
        return cellList;
    }
    // pregenerate the next visible grid
    private void GenerateNextGen() { 
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

    public void Update() {
            GenerateNextGen();
            
            for (int row = 0; row < this.Rows; row++) {
                for (int column = 0; column < this.Columns; column++) {
                    this.Cells[row, column] = this.NextGeneration[row, column];
                }
            }
    }
}
