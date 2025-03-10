using System.Collections.ObjectModel;
using System.Linq;


namespace Conway.Models;
public class Grid
{
    public int Rows { get; }
    public int Columns { get; }
    public ObservableCollection<ObservableCollection<Cell>> Cells { get; }

    public Grid(int rows, int columns)
    {
        this.Rows = rows;
        this.Columns = columns;
        Cells = [];

        for (int row = 0; row < rows; row++)
        {
            ObservableCollection<Cell> cellRow = [];
            for (int column = 0; column < columns; column++)
            {
                Cell currentCell = new(row, column, System.Random.Shared.NextDouble() > 0.9);
                currentCell.GetNeighborCoords(rows, columns);
                cellRow.Add(currentCell);
            }
            Cells.Add(cellRow);
        }
    }

    // pregenerate the next visible grid
    public ObservableCollection<Cell> GenerateNext()
    {
        ObservableCollection<Cell> updatedCells = [];
        bool[,] nextStates = new bool[Rows, Columns];

        for (int row = 0; row < this.Rows; row++)
        {
            ObservableCollection<Cell> currentCellRow = Cells[row];
            for (int column = 0; column < this.Columns; column++)
            {
                Cell currentCell = currentCellRow[column];
                Cell[] Neighbors = currentCell.GetNeighbors(Cells);
                int AliveNeighbors = Neighbors.Count(n => n.IsAlive);

                // actual conway logic
                nextStates[row, column] =
                (currentCell.IsAlive && (AliveNeighbors == 2 ||
                AliveNeighbors == 3)) ||
                (!currentCell.IsAlive && AliveNeighbors == 3);
            }
        }
        for (int row = 0; row < Rows; row++)
        {
            ObservableCollection<Cell> currentCellRow = Cells[row];
            for (int column = 0; column < Columns; column++)
            {
                currentCellRow[column].IsAlive = nextStates[row, column];
                updatedCells.Add(currentCellRow[column]);
            }
        }
        return updatedCells;
    }


}
