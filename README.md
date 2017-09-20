# MVVMHelpers

This is a collection of useful Helpers needed when developing applications with MVVM

Available on NuGet: https://www.nuget.org/packages/Bickellukas.MVVMHelpers

## Included Files

### ObservableObject
A basic implementation Of INotifyPropertyChanged

### ViewModelBase
A ViewModel base implementing ObservableObject

### RelayCommand
Implementation of ICommand
#### RelayCommand.Observes
Observes the given Property and calls CanExecuteChanged when it changes

### ObservableRangeCollection
ObservableCollection that supports adding and removing in bulk

### FilteredObservableCollection
A collection that automatically updates when its source collection updates and only shows the items corresponding to the given Filter

#### FilteredObservableCollection.Observes
Observes the given Property and refilteres the List when it changes

## Usage
See Example Project
