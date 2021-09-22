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
            var textBox = (TextBox)controls["textBox"];

            UpdateBtnStart(dispatcher, btnStart, false, "Stop");

            for (int i = 1; i <= number; i++)
            {
                dispatcher.BeginInvoke(new Action(() =>
                {
                    textBox.AppendText(i.ToString() + Environment.NewLine);
                }), DispatcherPriority.Background);

                Thread.Sleep(1000);
            }

            UpdateBtnStart(dispatcher, btnStart, true, "Start");

            Trace.WriteLine("Done");
        }

        private static void UpdateBtnStart(Dispatcher dispatcher, Button btnStart, bool isEnabled, string text)
        {
            dispatcher.BeginInvoke(new Action(() =>
            {
                btnStart.IsEnabled = isEnabled;
                btnStart.Content = text;
            }), DispatcherPriority.Background);
        }
    }
}