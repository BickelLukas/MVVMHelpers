using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVMHelpers
{
    /// <inheritdoc />
    /// <summary>
    /// Object that Implements INotifyPropertyChanged
    /// </summary>
    public class ObservableObject : INotifyPropertyChanged
    {
        /// <summary>
        /// Set the value of the field and invoke the Property Changed event
        /// </summary>
        /// <returns>Whether or not the Property has changed</returns>
        protected bool Set<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (field.Equals(newValue))
                return false;

            field = newValue;
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
