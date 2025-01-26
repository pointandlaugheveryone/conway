class Cell {
    public Coords Location {get; }
    public int LifeAge {get; set; }
    public string Color {
        get => System.Enum.GetName((ColorStatus)LifeAge)!;
        }
    public Cell[] Neighbors {get; }
    
}