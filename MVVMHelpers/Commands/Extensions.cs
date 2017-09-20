using System;
using System.Linq.Expressions;
using MVVMHelpers.Observers;

namespace MVVMHelpers.Commands
{
    public static class Extensions
    {
        /// <summary>
        /// Observes the given Property and Raises CanExecuteChanged when it changes
        /// </summary>
        public static RelayCommand<TCommand> Observes<TCommand, TProp>(this RelayCommand<TCommand> command, Expression<Func<TProp>> propertyExpression)
        {
            PropertyObserver.Observes(propertyExpression, command.RaiseCanExecuteChanged);
            return command;
        }

        /// <summary>
        /// Observes the given Property and Raises CanExecuteChanged when it changes
        /// </summary>
        public static RelayCommand Observes<T>(this RelayCommand command, Expression<Func<T>> propertyExpression)
        {
            PropertyObserver.Observes(propertyExpression, command.RaiseCanExecuteChanged);
            return command;
        }
    }
}
