using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace UI_PrototypeMoviesDBv0._5WPF
{
    public class View
    {
        private Dispatcher dis;
        private MainWindow main;
        private List<Tuple<int, int>> updates = new List<Tuple<int, int>>();

        private string textRemain = "00h:00m:00s";
        private TimeSpan timeLeft = new TimeSpan();

        public Stopwatch timer = new Stopwatch();
        public string output = string.Empty;

        public View(Dispatcher dis, MainWindow main)
        {
            this.dis = dis;
            this.main = main;
        }

        public void AddUpdate(int item, int number)
        {
            updates.Add(new Tuple<int, int>(item, number));
        }

        public void UpdateUi()
        {
            if (updates.Count > 0)
            {
                if (updates[updates.Count - 1].Item1 > 0)
                {
                    try
                    {
                        timeLeft = TimeSpan.FromMilliseconds((updates[updates.Count - 1].Item2 - updates[updates.Count - 1].Item1) * ((int)timer.Elapsed.TotalMilliseconds / updates[updates.Count - 1].Item1));
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine(ex);
                    }
                }

                for (int i = 0; i < updates.Count; i++)
                {
                    output += updates[i].Item1.ToString() + Environment.NewLine;
                }
                UpdateTextBox();
                ScrollToEnd();

                UpdateStatusProgressBar(updates[updates.Count - 1].Item1 + 1);
                UpdateStatusTextTask($"{string.Format("{0:0,0}", (updates[updates.Count - 1].Item1 + 1))} " +
                    $"of {string.Format("{0:0,0}", (updates[updates.Count - 1].Item2))}");
                UpdateStatusTextPercentage(
                    $"{((updates[updates.Count - 1].Item1 + 1) / (double)updates[updates.Count - 1].Item2 * 100):F2}%");

                updates.Clear();
            }

            textRemain = $"{timeLeft.Hours:D2}h:{timeLeft.Minutes:D2}m:{timeLeft.Seconds:D2}s";
            var textElapsed = $"{timer.Elapsed.Hours:D2}h:{timer.Elapsed.Minutes:D2}m:{timer.Elapsed.Seconds:D2}s";
            var textTime = $"{textElapsed} (remaining: {textRemain})";
            UpdateStatusTextTime(textTime);
            UpdateWindowTitle($"UI-PrototypeMoviesDBv0.5WPF [{DateTime.Now.ToString("HH:mm:ss")}]");
        }

        public void UpdateWindowTitle(string text)
        {
            dis.Invoke(new Action(() =>
            {
                main.Title = text;
            }), DispatcherPriority.Background);
        }

        public void UpdateBtnStart(bool isEnabled)
        {
            dis.Invoke(new Action(() =>
            {
                main.btnStart.IsEnabled = isEnabled;
            }), DispatcherPriority.Background);
        }

        public void UpdateBtnStartImg(string text)
        {
            dis.Invoke(new Action(() =>
            {
                main.btnStartImg.Source = new BitmapImage(new Uri(text, UriKind.Relative));
            }), DispatcherPriority.Background);
        }

        public void UpdateBtnStartTxt(string text)
        {
            dis.Invoke(new Action(() =>
            {
                main.btnStartTxt.Text = text;
            }), DispatcherPriority.Background);
        }

        public void UpdateBtnPause(bool isEnabled)
        {
            dis.Invoke(new Action(() =>
            {
                main.btnPause.IsEnabled = isEnabled;
            }), DispatcherPriority.Background);
        }

        public void UpdateBtnPauseImg(string text)
        {
            dis.Invoke(new Action(() =>
            {
                main.btnPauseImg.Source = new BitmapImage(new Uri(text, UriKind.Relative));
            }), DispatcherPriority.Background);
        }

        public void UpdateBtnPauseTxt(string text)
        {
            dis.Invoke(new Action(() =>
            {
                main.btnPauseTxt.Text = text;
            }), DispatcherPriority.Background);
        }

        public void UpdateBtnStop(bool isEnabled)
        {
            dis.Invoke(new Action(() =>
            {
                main.btnStop.IsEnabled = isEnabled;
            }), DispatcherPriority.Background);
        }

        public void UpdateBtnStopImg(string text)
        {
            dis.Invoke(new Action(() =>
            {
                main.btnStopImg.Source = new BitmapImage(new Uri(text, UriKind.Relative));
            }), DispatcherPriority.Background);
        }

        public void UpdateBtnStopTxt(string text)
        {
            dis.Invoke(new Action(() =>
            {
                main.btnStopTxt.Text = text;
            }), DispatcherPriority.Background);
        }

        public void UpdateBtnSettings(bool isEnabled)
        {
            dis.Invoke(new Action(() =>
            {
                main.btnSettings.IsEnabled = isEnabled;
            }), DispatcherPriority.Background);
        }

        public void UpdateBtnSettingsImg(string text)
        {
            dis.Invoke(new Action(() =>
            {
                main.btnSettingsImg.Source = new BitmapImage(new Uri(text, UriKind.Relative));
            }), DispatcherPriority.Background);
        }

        public void UpdateBtnSettingsTxt(string text)
        {
            dis.Invoke(new Action(() =>
            {
                main.btnSettingsTxt.Text = text;
            }), DispatcherPriority.Background);
        }

        public void UpdateTextBox()
        {
            dis.Invoke(new Action(() =>
            {
                main.textBox.Text = output;
            }), DispatcherPriority.Background);
        }

        public void UpdateTextBox(string text)
        {
            dis.Invoke(new Action(() =>
            {
                main.textBox.AppendText(text + Environment.NewLine);
            }), DispatcherPriority.Background);
        }

        public void ScrollToEnd()
        {
            dis.Invoke(new Action(() =>
            {
                main.textBox.ScrollToEnd();
            }), DispatcherPriority.Background);
        }

        public void UpdateStatusTextTime(string text)
        {
            dis.Invoke(new Action(() =>
            {
                main.statusTextTime.Text = text;
            }), DispatcherPriority.Background);
        }

        public void UpdateStatusTextTask(string text)
        {
            dis.Invoke(new Action(() =>
            {
                main.statusTextTask.Text = text;
            }), DispatcherPriority.Background);
        }

        public void SetupStatusProgressBar(int min, int max, int value)
        {
            dis.Invoke(new Action(() =>
            {
                main.statusProgressBar.Minimum = min;
                main.statusProgressBar.Maximum = max;
                main.statusProgressBar.Value = value;
            }), DispatcherPriority.Background);
        }

        public void UpdateStatusProgressBar(int value)
        {
            dis.Invoke(new Action(() =>
            {
                main.statusProgressBar.Value = value;
            }), DispatcherPriority.Background);
        }

        public void UpdateStatusTextPercentage(string text)
        {
            dis.Invoke(new Action(() =>
            {
                main.statusTextPercentage.Text = text;
            }), DispatcherPriority.Background);
        }

        public void UpdateStatusTextInfo(string text)
        {
            dis.Invoke(new Action(() =>
            {
                main.statusTextInfo.Text = text;
            }), DispatcherPriority.Background);
        }

        public void SetStateReady()
        {
            timer.Reset();
            timeLeft = new TimeSpan();
            UpdateBtnStart(true);
            UpdateBtnStartImg(@"/res/play24.png");
            UpdateBtnPause(false);
            UpdateBtnPauseImg(@"/res/pause24gray.png");
            UpdateBtnStop(false);
            UpdateBtnStopImg(@"/res/stop24gray.png");
            UpdateBtnSettings(true);
            UpdateBtnSettingsImg(@"/res/settings24.png");

            output = "";
            UpdateTextBox();
            ScrollToEnd();

            UpdateStatusTextTime("00h:00m:00s (remaining: 00h:00m:00s)");
            UpdateStatusTextTask("0 of 0");
            SetupStatusProgressBar(0, 1, 0);
            UpdateStatusTextPercentage("0%");
            UpdateStatusTextInfo("Ready");
        }

        public void SetStateRunning()
        {
            timer.Start();
            UpdateBtnStart(false);
            UpdateBtnStartImg(@"/res/play24gray.png");
            UpdateBtnPause(true);
            UpdateBtnPauseImg(@"/res/pause24.png");
            UpdateBtnStop(true);
            UpdateBtnStopImg(@"/res/stop24.png");
            UpdateBtnSettings(false);
            UpdateBtnSettingsImg(@"/res/settings24gray.png");
            UpdateStatusTextInfo("Running");
        }

        public void SetStatePaused()
        {
            timer.Stop();
            UpdateBtnStart(true);
            UpdateBtnStartImg(@"/res/play24.png");
            UpdateBtnPause(false);
            UpdateBtnPauseImg(@"/res/pause24gray.png");
            UpdateBtnStop(true);
            UpdateBtnStopImg(@"/res/stop24.png");
            UpdateBtnSettings(false);
            UpdateBtnSettingsImg(@"/res/settings24gray.png");
            UpdateStatusTextInfo("Paused");
        }

        public void SetStateStopped()
        {
            timer.Stop();
            UpdateBtnStart(false);
            UpdateBtnStartImg(@"/res/play24gray.png");
            UpdateBtnPause(false);
            UpdateBtnPauseImg(@"/res/pause24gray.png");
            UpdateBtnStop(true);
            UpdateBtnStopImg(@"/res/stop24.png");
            UpdateBtnSettings(false);
            UpdateBtnSettingsImg(@"/res/settings24gray.png");
            UpdateStatusTextInfo("Stopped");
        }

        public void SetStateDone()
        {
            timer.Stop();
            UpdateBtnStart(false);
            UpdateBtnStartImg(@"/res/play24gray.png");
            UpdateBtnPause(false);
            UpdateBtnPauseImg(@"/res/pause24gray.png");
            UpdateBtnStop(true);
            UpdateBtnStopImg(@"/res/stop24.png");
            UpdateBtnSettings(false);
            UpdateBtnSettingsImg(@"/res/settings24gray.png");
            UpdateStatusTextInfo("Done");
        }
    }
}