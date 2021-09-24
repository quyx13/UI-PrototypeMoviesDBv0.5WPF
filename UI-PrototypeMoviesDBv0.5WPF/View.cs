﻿using System;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace UI_PrototypeMoviesDBv0._5WPF
{
    public class View
    {
        private Dispatcher dis;
        private MainWindow main;

        public View(Dispatcher dis, MainWindow main)
        {
            this.dis = dis;
            this.main = main;
        }

        public void UpdateUi(TimeSpan timeSpan, int i, int number)
        {
            var text = "00h:00m:00s (remaining: 00h:00m:00s)";

            if (i > 0)
            {
                var timeLeft = TimeSpan.FromMilliseconds((number - i) *
                    ((int)timeSpan.TotalMilliseconds / i));
                text = $"{timeSpan.Hours:D2}h:{timeSpan.Minutes:D2}m:{timeSpan.Seconds:D2}s " +
                    $"(remaining: {timeLeft.Hours:D2}h:{timeLeft.Minutes:D2}m:{timeLeft.Seconds:D2}s)";
            }

            UpdateStatusTextTime(text);
            UpdateTextBox($"{i}\t" + text);
            ScrollToEnd();

            UpdateStatusTextTask($"{string.Format("{0:0,0}", (i + 1))} of {string.Format("{0:0,0}", (number))}");
            UpdateStatusProgressBar();
            UpdateStatusTextPercentage($"{((i + 1) / (double)number * 100):F2}%");
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

        public void UpdateStatusProgressBar()
        {
            dis.Invoke(new Action(() =>
            {
                main.statusProgressBar.Value++;
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
            System.Diagnostics.Trace.WriteLine("Ready");
            UpdateBtnStart(true);
            UpdateBtnStartImg(@"/res/play24.png");
            UpdateBtnPause(false);
            UpdateBtnPauseImg(@"/res/pause24gray.png");
            UpdateBtnStop(false);
            UpdateBtnStopImg(@"/res/stop24gray.png");
            UpdateBtnSettings(true);
            UpdateBtnSettingsImg(@"/res/settings24.png");
            main.textBox.Clear();
            UpdateStatusTextTime("00h:00m:00s (remaining: 00h:00m:00s)");
            UpdateStatusTextTask("0 of 0");
            SetupStatusProgressBar(0, 1, 0);
            UpdateStatusTextPercentage("0%");
            UpdateStatusTextInfo("Ready");
        }

        public void SetStateRunning()
        {
            System.Diagnostics.Trace.WriteLine("Running");
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
            System.Diagnostics.Trace.WriteLine("Paused");
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
            System.Diagnostics.Trace.WriteLine("Stopped");
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
            System.Diagnostics.Trace.WriteLine("Done");
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