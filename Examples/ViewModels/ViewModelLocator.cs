namespace Examples.ViewModels
{
    public class ViewModelLocator
    {
        private CommandsExampleViewModel _commandsExampleViewModel;
        private CollectionExampleViewModel _collectionExampleViewModel;

        public CommandsExampleViewModel CommandsExampleViewModel => _commandsExampleViewModel ?? (_commandsExampleViewModel = new CommandsExampleViewModel());
        public CollectionExampleViewModel CollectionExampleViewModel => _collectionExampleViewModel ?? (_collectionExampleViewModel = new CollectionExampleViewModel());
    }
}
