using System;
using System.Linq.Expressions;
using MVVMHelpers.Observers;

namespace MVVMHelpers.Collections
{
    public static class Extensions
    {
        /// <summary>
        /// Observes the given Property and refilteres to collection when it changes
        /// </summary>
        public static FilteredObservableCollection<TCommand> Observes<TCommand, TProp>(this FilteredObservableCollection<TCommand> command, Expression<Func<TProp>> propertyExpression)
        {
            PropertyObserver.Observes(propertyExpression, command.FilterChanged);
            return command;
        }
    }
}
