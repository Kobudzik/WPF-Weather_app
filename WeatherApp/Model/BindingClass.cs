using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeatherApp.Model
{
    //klasa ta sluzy do obslugi zmiany danych, w rzeczywistości porzebna jest jset tylko funkcja OnPropertyChanged 
    public class BindingClass : INotifyPropertyChanged, ICommand, INotifyCollectionChanged
    {
        public BindingClass() { }
        public BindingClass(Action<object> realize, Predicate<object> ifRealize = null)
        {
            this.realize = realize;
            this.ifRealize = ifRealize;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string nameProperty)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(nameProperty));
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;
        protected virtual void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ObservableCollection<object> obserwowanySender = sender as ObservableCollection<object>;

            List<object> editionOrRemoveElement = new List<object>();
            foreach (object newElement in e.NewItems)
            {
                editionOrRemoveElement.Add(newElement);
            }

            foreach (object oldElement in e.OldItems)
            {
                editionOrRemoveElement.Add(oldElement);
            }

            NotifyCollectionChangedAction action = e.Action;
        }



        private readonly Predicate<object> ifRealize;
        private readonly Action<object> realize;


        public event EventHandler CanExecuteChanged;
        public virtual void Execute(object parameter)
        {
            realize(parameter);
        }
        public virtual bool CanExecute(object parameter)
        {
            if (ifRealize == null)
            { return true; }
            return ifRealize(parameter);
        }






    }
}
