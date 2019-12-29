using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using FontAwesome;

namespace FontAwesomeDemo
{
    public class MainWindow_Model : INotifyPropertyChanged
    {
        public class Command : ICommand
        {
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                if (!(parameter is FontAwesomeIcon icon))
                    return;

                Clipboard.SetText($"{icon}");
            }

            public event EventHandler CanExecuteChanged;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<FontAwesomeIcon> Icons { get; set; }
        public ICommand CopyIconCommand { get; }

        public Version Version
        {
            get => Assembly.GetEntryAssembly()?.GetName().Version;
        }

        public MainWindow_Model()
        {
            CopyIconCommand = new Command();

            Task.Run(() =>
            {
                var items = Enum.GetValues(typeof(FontAwesomeIcon)).Cast<FontAwesomeIcon>().ToList();
                items.Sort((a, b) => string.CompareOrdinal($"{a}", $"{b}"));
                Icons = new ObservableCollection<FontAwesomeIcon>(items);

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Icons)));
            });
        }
    }
}