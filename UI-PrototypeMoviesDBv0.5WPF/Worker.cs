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
            var textBox = (TextBox)controls["textBox"];

            for (int i = 1; i <= number; i++)
            {
                dispatcher.BeginInvoke(new Action(() =>
                {
                    textBox.AppendText(i.ToString() + Environment.NewLine);
                }), DispatcherPriority.Background);

                Thread.Sleep(1000);
            }

            Trace.WriteLine("Done");
        }
    }
}