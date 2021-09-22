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

            var btnStart = (Button)controls["btnStart"];
            var imgBtnStart = (Image)controls["imgBtnStart"];
            var textBtnStart = (TextBlock)controls["textBtnStart"];
            var btnSettings = (Button)controls["btnSettings"];
            var imgBtnSettings = (Image)controls["imgBtnSettings"];
            var textBtnSettings = (TextBlock)controls["textBtnSettings"];
            var textBox = (TextBox)controls["textBox"];

            //UpdateBtnStart(dispatcher, btnStart, imgBtnStart, textBtnStart, "Stop", @"res/stop24.png");
            //UpdateBtnSettings(dispatcher, btnSettings, imgBtnSettings, textBtnSettings, false);

            for (int i = 1; i <= number; i++)
            {
                dispatcher.BeginInvoke(new Action(() =>
                {
                    textBox.AppendText(i.ToString() + Environment.NewLine);
                }), DispatcherPriority.Background);

                Trace.WriteLine($"...step {i}...");
                Thread.Sleep(1000);
            }

            //UpdateBtnStart(dispatcher, btnStart, imgBtnStart, textBtnStart, "Start", @"/res/play24.png");
            //UpdateBtnSettings(dispatcher, btnSettings, imgBtnSettings, textBtnSettings, true);

            Trace.WriteLine("...done");
        }

        private static void UpdateBtnStart(Dispatcher dispatcher, Button btnStart, 
            Image imgBtnStart, TextBlock textBtnStart, string text, string uri)
        {
            dispatcher.BeginInvoke(new Action(() =>
            {
                textBtnStart.Text = text;
                imgBtnStart.Source = new BitmapImage(new Uri(uri, UriKind.Relative));
            }), DispatcherPriority.Background);
        }

        private static void UpdateBtnSettings(Dispatcher dispatcher, Button btnSettings, 
            Image imgBtnSettings, TextBlock textBtnSettings, bool isEnabled)
        {
            dispatcher.BeginInvoke(new Action(() =>
            {
                btnSettings.IsEnabled = isEnabled;
            }), DispatcherPriority.Background);
        }
    }
}