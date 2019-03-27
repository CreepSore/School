using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Calculator
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ICommand clickNumButton { get; set; }
        public ICommand onDelete { get; set; }

        public ICommand onPlus { get; set; }
        public ICommand onMinus { get; set; }
        public ICommand onMultiply { get; set; }
        public ICommand onDivide { get; set; }

        private string formula = String.Empty;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Formula
        {
            get => formula;
            set
            {
                formula = value;
                this.OnPropertyChanged();
            }
        }
        private Random rnd = new Random();

        public MainWindow()
        {
            clickNumButton = new WPFCommand(onClick9);
            onDelete = new WPFCommand(onDel);

            onPlus = new WPFCommand(onPl);
            onMinus = new WPFCommand(onMi);
            onMultiply = new WPFCommand(onMu);
            onDivide = new WPFCommand(onDv);

            this.DataContext = this;

            InitializeComponent();
        }

        public void onClick9(object par)
        {
            Formula += rnd.Next(0, 10).ToString();
        }

        public void onDel(object par)
        {
            Formula = String.Empty;
        }

        public void onPl(object par)
        {
            Formula += "+";
        }
        public void onMi(object par)
        {
            Formula += "-";
        }
        public void onMu(object par)
        {
            Formula += "x";
        }
        public void onDv(object par)
        {
            Formula += "/";
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
