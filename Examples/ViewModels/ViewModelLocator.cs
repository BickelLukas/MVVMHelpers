namespace Examples.ViewModels
{
    public class ViewModelLocator
    {
        private CommandsExampleViewModel _commandsExampleViewModel;
        
        public CommandsExampleViewModel CommandsExampleViewModel => _commandsExampleViewModel ?? (_commandsExampleViewModel = new CommandsExampleViewModel());
    }
}
