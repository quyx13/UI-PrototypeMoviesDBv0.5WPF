using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace UI_PrototypeMoviesDBv0._5WPF
{
    public static class ViewUpdates
    {
        public static void UpdateBtnStart(Dispatcher dispatcher,
            Dictionary<string, Object> controls, bool isEnabled)
        {
            var btnStart = (Button)controls["btnStart"];

            dispatcher.BeginInvoke(new Action(() =>
            {
                btnStart.IsEnabled = isEnabled;
            }), DispatcherPriority.Normal);
        }

        public static void UpdateBtnStartImg(Dispatcher dispatcher,
            Dictionary<string, Object> controls, string text)
        {
            var btnStartImg = (Image)controls["btnStartImg"];

            dispatcher.BeginInvoke(new Action(() =>
            {
                btnStartImg.Source = new BitmapImage(new Uri(text, UriKind.Relative));
            }), DispatcherPriority.Normal);
        }

        public static void UpdateBtnStartTxt(Dispatcher dispatcher,
            Dictionary<string, Object> controls, string text)
        {
            var btnStartTxt = (TextBlock)controls["btnStartTxt"];

            dispatcher.BeginInvoke(new Action(() =>
            {
                btnStartTxt.Text = text;
            }), DispatcherPriority.Normal);
        }

        public static void UpdateBtnPause(Dispatcher dispatcher,
            Dictionary<string, Object> controls, bool isEnabled)
        {
            var btnPause = (Button)controls["btnPause"];

            dispatcher.BeginInvoke(new Action(() =>
            {
                btnPause.IsEnabled = isEnabled;
            }), DispatcherPriority.Normal);
        }

        public static void UpdateBtnPauseImg(Dispatcher dispatcher,
            Dictionary<string, Object> controls, string text)
        {
            var btnPauseImg = (Image)controls["btnPauseImg"];

            dispatcher.BeginInvoke(new Action(() =>
            {
                btnPauseImg.Source = new BitmapImage(new Uri(text, UriKind.Relative));
            }), DispatcherPriority.Normal);
        }

        public static void UpdateBtnPauseTxt(Dispatcher dispatcher,
            Dictionary<string, Object> controls, string text)
        {
            var btnPauseTxt = (TextBlock)controls["btnPauseTxt"];

            dispatcher.BeginInvoke(new Action(() =>
            {
                btnPauseTxt.Text = text;
            }), DispatcherPriority.Normal);
        }

        public static void UpdateBtnStop(Dispatcher dispatcher,
            Dictionary<string, Object> controls, bool isEnabled)
        {
            var btnStop = (Button)controls["btnStop"];

            dispatcher.BeginInvoke(new Action(() =>
            {
                btnStop.IsEnabled = isEnabled;
            }), DispatcherPriority.Normal);
        }

        public static void UpdateBtnStopImg(Dispatcher dispatcher,
            Dictionary<string, Object> controls, string text)
        {
            var btnStopImg = (Image)controls["btnStopImg"];

            dispatcher.BeginInvoke(new Action(() =>
            {
                btnStopImg.Source = new BitmapImage(new Uri(text, UriKind.Relative));
            }), DispatcherPriority.Normal);
        }

        public static void UpdateBtnStopTxt(Dispatcher dispatcher,
            Dictionary<string, Object> controls, string text)
        {
            var btnStopTxt = (TextBlock)controls["btnStopTxt"];

            dispatcher.BeginInvoke(new Action(() =>
            {
                btnStopTxt.Text = text;
            }), DispatcherPriority.Normal);
        }

        public static void UpdateBtnSettings(Dispatcher dispatcher,
            Dictionary<string, Object> controls, bool isEnabled)
        {
            var btnSettings = (Button)controls["btnSettings"];

            dispatcher.BeginInvoke(new Action(() =>
            {
                btnSettings.IsEnabled = isEnabled;
            }), DispatcherPriority.Normal);
        }

        public static void UpdateBtnSettingsImg(Dispatcher dispatcher,
            Dictionary<string, Object> controls, string text)
        {
            var btnSettingsImg = (Image)controls["btnSettingsImg"];

            dispatcher.BeginInvoke(new Action(() =>
            {
                btnSettingsImg.Source = new BitmapImage(new Uri(text, UriKind.Relative));
            }), DispatcherPriority.Normal);
        }

        public static void UpdateBtnSettingsTxt(Dispatcher dispatcher,
            Dictionary<string, Object> controls, string text)
        {
            var btnSettingsTxt = (TextBlock)controls["btnSettingsTxt"];

            dispatcher.BeginInvoke(new Action(() =>
            {
                btnSettingsTxt.Text = text;
            }), DispatcherPriority.Normal);
        }

        public static void UpdateTextBox(Dispatcher dispatcher,
            Dictionary<string, Object> controls, string text)
        {
            var textBox = (TextBox)controls["textBox"];

            dispatcher.BeginInvoke(new Action(() =>
            {
                textBox.AppendText(text + Environment.NewLine);
                ScrollToEnd(textBox);
            }), DispatcherPriority.Normal);
        }

        private static void ScrollToEnd(TextBox textBox)
        {
            textBox.CaretIndex = textBox.Text.Length;
            textBox.ScrollToEnd();
        }

        public static void UpdateStatusTextTime(Dispatcher dispatcher,
            Dictionary<string, Object> controls, string text)
        {
            var statusTextTime = (TextBlock)controls["statusTextTime"];

            dispatcher.BeginInvoke(new Action(() =>
            {
                statusTextTime.Text = text;
            }), DispatcherPriority.Normal);
        }

        public static void UpdateStatusTextTask(Dispatcher dispatcher,
            Dictionary<string, Object> controls, string text)
        {
            var statusTextTask = (TextBlock)controls["statusTextTask"];

            dispatcher.BeginInvoke(new Action(() =>
            {
                statusTextTask.Text = text;
            }), DispatcherPriority.Normal);
        }

        public static void SetupStatusProgressBar(Dispatcher dispatcher,
            Dictionary<string, Object> controls, int min, int max, int value)
        {
            var statusProgressBar = (ProgressBar)controls["statusProgressBar"];

            dispatcher.BeginInvoke(new Action(() =>
            {
                statusProgressBar.Minimum = min;
                statusProgressBar.Maximum = max;
                statusProgressBar.Value = value;
            }), DispatcherPriority.Normal);
        }

        public static void UpdateStatusProgressBar(Dispatcher dispatcher,
            Dictionary<string, Object> controls)
        {
            var statusProgressBar = (ProgressBar)controls["statusProgressBar"];

            dispatcher.BeginInvoke(new Action(() =>
            {
                statusProgressBar.Value++;
            }), DispatcherPriority.Normal);
        }

        public static void UpdateStatusTextPercentage(Dispatcher dispatcher,
            Dictionary<string, Object> controls, string text)
        {
            var statusTextPercentage = (TextBlock)controls["statusTextPercentage"];

            dispatcher.BeginInvoke(new Action(() =>
            {
                statusTextPercentage.Text = text;
            }), DispatcherPriority.Normal);
        }

        public static void UpdateStatusTextInfo(Dispatcher dispatcher,
            Dictionary<string, Object> controls, string text)
        {
            var statusTextInfo = (TextBlock)controls["statusTextInfo"];

            dispatcher.BeginInvoke(new Action(() =>
            {
                statusTextInfo.Text = text;
            }), DispatcherPriority.Normal);
        }

        public static void SetStateReady(Dispatcher dispatcher,
            Dictionary<string, Object> controls)
        {
            UpdateStatusTextTime(dispatcher, controls, "00h:00m:00s (remaining: 00h:00m:00s)");
            UpdateStatusTextTask(dispatcher, controls, "0 of 0");
            SetupStatusProgressBar(dispatcher, controls, 0, 1, 0);
            UpdateStatusTextPercentage(dispatcher, controls, "0%");
            UpdateStatusTextInfo(dispatcher, controls, "Ready");
        }

        public static void SetStateRunning(Dispatcher dispatcher,
            Dictionary<string, Object> controls, int number)
        {
            UpdateBtnStart(dispatcher, controls, false);
            UpdateBtnStartImg(dispatcher, controls, @"/res/play24gray.png");
            UpdateBtnPause(dispatcher, controls, true);
            UpdateBtnPauseImg(dispatcher, controls, @"/res/pause24.png");
            UpdateBtnStop(dispatcher, controls, true);
            UpdateBtnStopImg(dispatcher, controls, @"/res/stop24.png");
            UpdateBtnSettings(dispatcher, controls, false);
            UpdateBtnSettingsImg(dispatcher, controls, @"/res/settings24gray.png");
            SetupStatusProgressBar(dispatcher, controls, 0, number, 0);
            UpdateStatusTextInfo(dispatcher, controls, "Running");
        }

        public static void SetStatePaused(Dispatcher dispatcher,
            Dictionary<string, Object> controls)
        {
            UpdateBtnStart(dispatcher, controls, true);
            UpdateBtnStartImg(dispatcher, controls, @"/res/play24.png");
            UpdateBtnPause(dispatcher, controls, false);
            UpdateBtnPauseImg(dispatcher, controls, @"/res/pause24gray.png");
            UpdateBtnStop(dispatcher, controls, true);
            UpdateBtnStopImg(dispatcher, controls, @"/res/stop24.png");
            UpdateBtnSettings(dispatcher, controls, false);
            UpdateBtnSettingsImg(dispatcher, controls, @"/res/settings24gray.png");
            UpdateStatusTextInfo(dispatcher, controls, "Paused");
        }

        public static void SetStateStopped(Dispatcher dispatcher,
            Dictionary<string, Object> controls)
        {
            UpdateBtnStart(dispatcher, controls, true);
            UpdateBtnStartImg(dispatcher, controls, @"/res/play24.png");
            UpdateBtnPause(dispatcher, controls, false);
            UpdateBtnPauseImg(dispatcher, controls, @"/res/pause24gray.png");
            UpdateBtnStop(dispatcher, controls, false);
            UpdateBtnStopImg(dispatcher, controls, @"/res/stop24gray.png");
            UpdateBtnSettings(dispatcher, controls, true);
            UpdateBtnSettingsImg(dispatcher, controls, @"/res/settings24.png");
            UpdateStatusTextInfo(dispatcher, controls, "Stopped");
        }

        public static void SetStateDone(Dispatcher dispatcher,
            Dictionary<string, Object> controls)
        {
            SetStateStopped(dispatcher, controls);
            UpdateStatusTextInfo(dispatcher, controls, "Done");
        }
    }
}