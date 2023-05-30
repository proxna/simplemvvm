using System.ComponentModel;

namespace SimpleMvvm
{
    // All the code in this file is included in all platforms.
    // This is the base class for all ViewModels.
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Sets the value of the field and raises the PropertyChanged event if the value has changed.
        /// </summary>
        /// <typeparam name="T"> The type of the field. </typeparam>
        /// <param name="field"> The field to set. </param>
        /// <param name="value"> The value to set the field to. </param>
        /// <param name="propertyName"> The name of the property. </param>
        protected void Set<T>(ref T field, T value, string propertyName)
        {
            if (Equals(field, value))
            {
                return;
            }

            field = value;
            RaisePropertyChanged(propertyName);
        }

        /// <summary>
        /// Sets the value of the field and raises the PropertyChanged event if the value has changed.
        /// </summary>
        /// <typeparam name="T"> The type of the field. </typeparam>
        /// <param name="field"> The field to set. </param>
        /// <param name="value"> The value to set the field to. </param>
        protected void Set<T>(ref T field, T value)
        {
            Set(ref field, value, nameof(field));
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}