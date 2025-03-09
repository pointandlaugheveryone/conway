class ColorCell : Cell {
    private static readonly List<\SolidColorBrush> ColorMap =  // indexed based on Age property to assign color 
    new()
    {
        { new SolidColorBrush(Colors.Color0) },
        { new SolidColorBrush(Colors.Color1) },
        { new SolidColorBrush(Colors.Color2) },
        { new SolidColorBrush(Colors.Color3) }
    };
    
    public ColorCell(int x, int y) : base(x, y) {
        LifeStatus = Helper.RandomiseLife()
    }
}

---------------


In MainWindowViewModel, provide a command that opens the SimulationWindow when clicked.
Connect MainWindow and SimulationWindow (∼0.5h)

When the user clicks “Start Simulation,” instantiate the SimulationViewModel and SimulationWindow.
Set SimulationWindow’s DataContext to the SimulationViewModel.
Restructure SimulationWindow to use ItemsControl (∼1h)

Replace the <UniformGrid> with an <ItemsControl Items="{Binding Cells}">.
In ItemsControl.ItemsPanel, define a <ItemsPanelTemplate> containing the UniformGrid (with Columns/Rows bound to Rows/Columns in SimulationViewModel).
In ItemsControl.ItemTemplate, have the <Rectangle Fill="{Binding CellColor}" />.
Check property-change behavior and data flow (∼0.5–1h)

In Cell, use ObservableObject or implement INotifyPropertyChanged for IsAlive/CellColor to refresh properly.
Confirm you update your Cells in SimulationViewModel so the UI automatically reflects changes.
Add final touches (∼1–2h)

Style the windows, add margin/padding, handle window transitions, and polish design elements.
Test the simulation run/pause cycle with your timer logic in SimulationViewModel.
With these steps, you ensure each window has a clear role, the data is cleanly exposed via ViewModels, and Avalonia’s data binding does the heavy lifting for UI updates.

-----------
Use properties from CommunityToolkit’s [ObservableProperty] to reduce boilerplate.
Move timer logic into commands or other dedicated methods to keep the constructor clean.
Keep the RunCommand method minimal, and consider raising PropertyChanged events (if needed) on the timer or generation updates for the UI.

ICommand is the standard interface for commands
RelayCommand is a common implementation that wraps an Action or Func and implements ICommand
RelayCommand attribute automatically creates these commands and the related boilerplate (properties, raising change notifications, etc.)
ReactiveUI uses a different approach (ReactiveCommand) with more reactive features, but ultimately they all serve the same purpose
    = binding UI actions to the ViewModel logic.
