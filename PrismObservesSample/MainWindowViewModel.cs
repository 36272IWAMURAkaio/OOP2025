using System;
using System.ComponentModel;
using System.Windows.Input;

namespace PrismObservesSample {
    public class MainWindowViewModel : INotifyPropertyChanged {
        private string _input1;
        public string Input1 {
            get => _input1;
            set {
                if (_input1 != value) {
                    _input1 = value;
                    OnPropertyChanged(nameof(Input1));
                }
            }
        }

        private string _input2;
        public string Input2 {
            get => _input2;
            set {
                if (_input2 != value) {
                    _input2 = value;
                    OnPropertyChanged(nameof(Input2));
                }
            }
        }

        private string _result;
        public string Result {
            get => _result;
            set {
                if (_result != value) {
                    _result = value;
                    OnPropertyChanged(nameof(Result));
                }
            }
        }

        public ICommand SumCommand { get; }

        public MainWindowViewModel() {
            SumCommand = new RelayCommand(ExecuteSum);
        }

        private void ExecuteSum(object parameter) {
            // 文字列→整数に変換して計算
            if (int.TryParse(Input1, out int num1) && int.TryParse(Input2, out int num2)) {
                Result = (num1 + num2).ToString();
            } else {
                Result = "入力エラー";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // シンプルなRelayCommandの実装
    public class RelayCommand : ICommand {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null) {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);

        public void Execute(object parameter) => _execute(parameter);

        public event EventHandler CanExecuteChanged {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
