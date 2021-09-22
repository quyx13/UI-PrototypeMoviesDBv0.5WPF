using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace UI_PrototypeMoviesDBv0._5WPF
{
    public static class Worker
    {
        public static void DoWork(Dispatcher dispatcher, Dictionary<string, Object> controls, int number)
        {
            Trace.WriteLine("started...");

            var textBox = (TextBox)controls["textBox"];
            var statusTextTime = (TextBlock)controls["statusTextTime"];
            var statusTextTask = (TextBlock)controls["statusTextTask"];
            var statusProgressBar = (ProgressBar)controls["statusProgressBar"];
            var statusTextPercentage = (TextBlock)controls["statusTextPercentage"];
            var statusTextInfo = (TextBlock)controls["statusTextInfo"];

            SetupStatusProgressBar(dispatcher, statusProgressBar, 0, number);
            
            for (int i = 1; i <= number; i++)
            {
                dispatcher.BeginInvoke(new Action(() =>
                {
                    textBox.AppendText(i.ToString() + Environment.NewLine);
                }), DispatcherPriority.Background);

                UpdateStatusTextTime(dispatcher, statusTextTime, $"...step {i}...");
                UpdateStatusTextTask(dispatcher, statusTextTask, $"...step {i}...");
                UpdateStatusProgressBar(dispatcher, statusProgressBar);
                UpdateStatusTextPercentage(dispatcher, statusTextPercentage, $"{i}%");
                UpdateStatusTextInfo(dispatcher, statusTextInfo, $"...step {i}...");

                Trace.WriteLine($"...step {i}...");
                Thread.Sleep(1000);
            }

            Trace.WriteLine("...done");
        }

        private static void UpdateStatusTextTime(Dispatcher dispatcher, 
            TextBlock statusTextTime, string text)
        {
            dispatcher.BeginInvoke(new Action(() =>
            {
                statusTextTime.Text = text;
            }), DispatcherPriority.Background);
        }

        private static void UpdateStatusTextTask(Dispatcher dispatcher,
            TextBlock statusTextTask, string text)
        {
            dispatcher.BeginInvoke(new Action(() =>
            {
                statusTextTask.Text = text;
            }), DispatcherPriority.Background);
        }

        private static void SetupStatusProgressBar(Dispatcher dispatcher,
            ProgressBar statusProgressBar, int min, int max)
        {
            dispatcher.BeginInvoke(new Action(() =>
            {
                statusProgressBar.Value = min;
                statusProgressBar.Minimum = min;
                statusProgressBar.Maximum = max;
            }), DispatcherPriority.Background);
        }

        private static void UpdateStatusProgressBar(Dispatcher dispatcher,
            ProgressBar statusProgressBar)
        {
            dispatcher.BeginInvoke(new Action(() =>
            {
                statusProgressBar.Value++;
            }), DispatcherPriority.Background);
        }

        private static void UpdateStatusTextPercentage(Dispatcher dispatcher,
            TextBlock statusTextPercentage, string text)
        {
            dispatcher.BeginInvoke(new Action(() =>
            {
                statusTextPercentage.Text = text;
            }), DispatcherPriority.Background);
        }

        private static void UpdateStatusTextInfo(Dispatcher dispatcher,
            TextBlock statusTextInfo, string text)
        {
            dispatcher.BeginInvoke(new Action(() =>
            {
                statusTextInfo.Text = text;
            }), DispatcherPriority.Background);
        }
    }
}