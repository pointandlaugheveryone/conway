namespace Conway.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "in construction";
    /*
    TODO:   [UI] generation counter, colors, save as png
    */

    public int rows {get; } 
    public int columns {get; }
    
}
