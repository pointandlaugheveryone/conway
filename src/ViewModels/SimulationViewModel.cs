using System.Dynamic;
using Conway.Models;

namespace Conway.ViewModels {
    public class Simulation : ViewModelBase {
        public void Precalculate(Grid grid) {
            foreach (Cell cell in grid.Cells) {
                
            }
        }

        public void Run(int rows, int columns, int generations) {
            Grid grid = new(rows, columns, generations);

            for (int generationCount = 0; generationCount <= generations; generationCount++) {
                foreach (Cell cell in grid.Cells) {
                    /** TODO:
                    cell.LifeStatus = Precalculate.isalive
                    if isalive {age++}
                    cell.Colour = IsAlive ? new SolidColorBrush(Colors.White) : new SolidColorBrush(Colors.Black);
                    **/
                }
            }
        }
    }
}