using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace UI_PrototypeMoviesDBv0._5WPF
{
    public class Worker
    {
        public State state;
        private Dispatcher dispatcher;
        private MainWindow main;

        public Worker(Dispatcher dispatcher, MainWindow main)
        {
            this.dispatcher = dispatcher;
            this.main = main;

            state = State.ready;
            SetStateReady();
        }

        public void DoWork(int number)
        {
            var timer = new Stopwatch();
            timer.Start();

            state = State.running;
            SetStateRunning(number);

            for (int i = 0; i < number; )
            {
                #region Actually Working Area

                UpdateTextBox(i.ToString());
                if (i > 0)
                {
                    var timeLeft = TimeSpan.FromMilliseconds((number - i) * ((int)timer.Elapsed.TotalMilliseconds / i));
                    var text = $"{timer.Elapsed.Hours:D2}h:{timer.Elapsed.Minutes:D2}m:{timer.Elapsed.Seconds:D2}s (remaining: {timeLeft.Hours:D2}h:{timeLeft.Minutes:D2}m:{timeLeft.Seconds:D2}s)";
                    UpdateStatusTextTime(text);
                    UpdateTextBox($"{i}\t" + text);
                }
                UpdateStatusTextTask($"{string.Format("{0:0,0}", (i + 1))} of {string.Format("{0:0,0}", (number))}");
                UpdateStatusProgressBar();
                UpdateStatusTextPercentage($"{((i + 1) / (double)number * 100):F2}%");

                i++;
                #endregion
            }

            Trace.WriteLine($"{timer.ElapsedMilliseconds}");

            state = State.done;
            SetStateDone();
        }

        public void SetStateReady()
        {
            UpdateStatusTextTime("00h:00m:00s (remaining: 00h:00m:00s)");
            UpdateStatusTextTask("0 of 0");
            SetupStatusProgressBar(0, 1, 0);
            UpdateStatusTextPercentage("0%");
            UpdateStatusTextInfo("Ready");
        }

        public void SetStateRunning(int number)
        {
            UpdateBtnStart(false);
            UpdateBtnStartImg(@"/res/play24gray.png");
            UpdateBtnPause(true);
            UpdateBtnPauseImg(@"/res/pause24.png");
            UpdateBtnStop(true);
            UpdateBtnStopImg(@"/res/stop24.png");
            UpdateBtnSettings(false);
            UpdateBtnSettingsImg(@"/res/settings24gray.png");
            SetupStatusProgressBar(0, number, 0);
            UpdateStatusTextInfo("Running");
        }

        public void SetStateStopped()
        {
            UpdateBtnStart(true);
            UpdateBtnStartImg(@"/res/play24.png");
            UpdateBtnPause(false);
            UpdateBtnPauseImg(@"/res/pause24gray.png");
            UpdateBtnStop(false);
            UpdateBtnStopImg(@"/res/stop24gray.png");
            UpdateBtnSettings(true);
            UpdateBtnSettingsImg(@"/res/settings24.png");
            UpdateStatusTextInfo("Stopped");
        }

        public void SetStateDone()
        {
            SetStateStopped();
            UpdateStatusTextInfo("Done");
        }

        public void UpdateBtnStart(bool isEnabled)
        {
            dispatcher.Invoke(new Action(() =>
            {
                main.btnStart.IsEnabled = isEnabled;
            }), DispatcherPriority.Background);
        }

        public void UpdateBtnStartImg(string text)
        {
            dispatcher.Invoke(new Action(() =>
            {
                main.btnStartImg.Source = new BitmapImage(new Uri(text, UriKind.Relative));
            }), DispatcherPriority.Background);
        }

        public void UpdateBtnStartTxt(string text)
        {
            dispatcher.Invoke(new Action(() =>
            {
                main.btnStartTxt.Text = text;
            }), DispatcherPriority.Background);
        }

        public void UpdateBtnPause(bool isEnabled)
        {
            dispatcher.Invoke(new Action(() =>
            {
                main.btnPause.IsEnabled = isEnabled;
            }), DispatcherPriority.Background);
        }

        public void UpdateBtnPauseImg(string text)
        {
            dispatcher.Invoke(new Action(() =>
            {
                main.btnPauseImg.Source = new BitmapImage(new Uri(text, UriKind.Relative));
            }), DispatcherPriority.Background);
        }

        public void UpdateBtnPauseTxt(string text)
        {
            dispatcher.Invoke(new Action(() =>
            {
                main.btnPauseTxt.Text = text;
            }), DispatcherPriority.Background);
        }

        public void UpdateBtnStop(bool isEnabled)
        {
            dispatcher.Invoke(new Action(() =>
            {
                main.btnStop.IsEnabled = isEnabled;
            }), DispatcherPriority.Background);
        }

        public void UpdateBtnStopImg(string text)
        {
            dispatcher.Invoke(new Action(() =>
            {
                main.btnStopImg.Source = new BitmapImage(new Uri(text, UriKind.Relative));
            }), DispatcherPriority.Background);
        }

        public void UpdateBtnStopTxt(string text)
        {
            dispatcher.Invoke(new Action(() =>
            {
                main.btnStopTxt.Text = text;
            }), DispatcherPriority.Background);
        }

        public void UpdateBtnSettings(bool isEnabled)
        {
            dispatcher.Invoke(new Action(() =>
            {
                main.btnSettings.IsEnabled = isEnabled;
            }), DispatcherPriority.Background);
        }

        public void UpdateBtnSettingsImg(string text)
        {
            dispatcher.Invoke(new Action(() =>
            {
                main.btnSettingsImg.Source = new BitmapImage(new Uri(text, UriKind.Relative));
            }), DispatcherPriority.Background);
        }

        public void UpdateBtnSettingsTxt(string text)
        {
            dispatcher.Invoke(new Action(() =>
            {
                main.btnSettingsTxt.Text = text;
            }), DispatcherPriority.Background);
        }

        public void UpdateTextBox(string text)
        {
            dispatcher.Invoke(new Action(() =>
            {
                main.textBox.AppendText(text + Environment.NewLine);
                main.textBox.CaretIndex = main.textBox.Text.Length;
                main.textBox.ScrollToEnd();
            }), DispatcherPriority.Background);
        }

        public void UpdateStatusTextTime(string text)
        {
            dispatcher.Invoke(new Action(() =>
            {
                main.statusTextTime.Text = text;
            }), DispatcherPriority.Background);
        }

        public void UpdateStatusTextTask(string text)
        {
            dispatcher.Invoke(new Action(() =>
            {
                main.statusTextTask.Text = text;
            }), DispatcherPriority.Background);
        }

        public void SetupStatusProgressBar(int min, int max, int value)
        {
            dispatcher.Invoke(new Action(() =>
            {
                main.statusProgressBar.Minimum = min;
                main.statusProgressBar.Maximum = max;
                main.statusProgressBar.Value = value;
            }), DispatcherPriority.Background);
        }

        public void UpdateStatusProgressBar()
        {
            dispatcher.Invoke(new Action(() =>
            {
                main.statusProgressBar.Value++;
            }), DispatcherPriority.Background);
        }

        public void UpdateStatusTextPercentage(string text)
        {
            dispatcher.Invoke(new Action(() =>
            {
                main.statusTextPercentage.Text = text;
            }), DispatcherPriority.Background);
        }

        public void UpdateStatusTextInfo(string text)
        {
            dispatcher.Invoke(new Action(() =>
            {
                main.statusTextInfo.Text = text;
            }), DispatcherPriority.Background);
        }
    }
}