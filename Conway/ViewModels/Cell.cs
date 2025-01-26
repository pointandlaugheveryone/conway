using System.Collections.Generic;
using Conway.ViewModels;


class Cell : ViewModelBase {
    private readonly List<string> _color = [  // lowest - oldest; 0 = dead
        "000000",
        "ffffff" // for now only two colors for testing; TODO: cyclic cellular automata
    ];
    public Coords Location {get; }
    public int LifeAge {get; set; }
    public string Color  {get; }

    public Cell(int x, int y, int lifeAge = 0) {
        Location = new Coords(x,y);
        this.LifeAge = lifeAge;
        this.Color = _color[LifeAge];
    }
}