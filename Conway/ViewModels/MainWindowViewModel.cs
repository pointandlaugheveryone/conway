namespace Conway.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public const string Black = "000000";
    public const string White = "ffffff";

    public int rows {get; } 
    public int columns {get; }
    public int generations {get; set;}
    
}
