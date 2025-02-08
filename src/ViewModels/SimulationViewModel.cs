using System.Dynamic;
using Conway.Models;

namespace Conway.ViewModels {
    public class Simulation : ViewModelBase {
        public void Run(int rows, int columns, int generations) {
            Grid grid = new(rows, columns, generations);

            for (int generationCount = 0; generationCount <= generations; generationCount++) {
                foreach (Cell cell in grid.Cells) {
                    /** TODO:
                    CalculateLifeStatus()
                    for Cell.Neighbor in Cell.Neighbors()
                    **/
                }
            }
        }
    }
}