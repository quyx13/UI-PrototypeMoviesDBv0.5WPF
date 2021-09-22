using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace UI_PrototypeMoviesDBv0._5WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void menuInfo_Click(object sender, RoutedEventArgs e)
        {
            // TODO:Informations-Dialog
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            //Task.Factory.StartNew(() => DoWork(10));
            Task.Factory.StartNew(() => Worker.DoWork(this.Dispatcher, new Dictionary<string, Object> { { "textBox", textBox } }, 10));
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            // TODO:Settings-Fenster
        }

        private void DoWork(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                Dispatcher.BeginInvoke(new Action(() => 
                { 
                    textBox.AppendText(i.ToString() + Environment.NewLine); 
                }), DispatcherPriority.Background);
                
                Thread.Sleep(1000);
            }

            Trace.WriteLine("Done");
        }
    }
}