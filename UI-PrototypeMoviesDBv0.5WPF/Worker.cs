using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Threading;

namespace UI_PrototypeMoviesDBv0._5WPF
{
    public static class Worker
    {
        public static void DoWork(Dispatcher dispatcher, Dictionary<string, Object> controls, int number)
        {
            var btnStart = (Button)controls["btnStart"];
            var btnSettings = (Button)controls["btnSettings"];
            var textBox = (TextBox)controls["textBox"];

            UpdateBtnStart(dispatcher, btnStart, "Stop");
            UpdateBtnSettings(dispatcher, btnSettings, false);

            for (int i = 1; i <= number; i++)
            {
                dispatcher.BeginInvoke(new Action(() =>
                {
                    textBox.AppendText(i.ToString() + Environment.NewLine);
                }), DispatcherPriority.Background);

                Thread.Sleep(1000);
            }

            UpdateBtnStart(dispatcher, btnStart, "Start");
            UpdateBtnSettings(dispatcher, btnSettings, true);

            Trace.WriteLine("Done");
        }

        private static void UpdateBtnStart(Dispatcher dispatcher, Button btnStart, string text)
        {
            dispatcher.BeginInvoke(new Action(() =>
            {
                btnStart.Content = text;
            }), DispatcherPriority.Background);
        }

        private static void UpdateBtnSettings(Dispatcher dispatcher, Button btnSettings, bool isEnabled)
        {
            dispatcher.BeginInvoke(new Action(() =>
            {
                btnSettings.IsEnabled = isEnabled;
            }), DispatcherPriority.Background);
        }
    }
}