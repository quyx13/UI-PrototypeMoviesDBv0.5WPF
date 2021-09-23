using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace UI_PrototypeMoviesDBv0._5WPF
{
    public class Worker
    {
        public State state;
        private Dispatcher dispatcher;

        private Button btnStart;
        private Image btnStartImg;
        private TextBlock btnStartTxt;
        private Button btnPause;
        private Image btnPauseImg;
        private TextBlock btnPauseTxt;
        private Button btnStop;
        private Image btnStopImg;
        private TextBlock btnStopTxt;
        private Button btnSettings;
        private Image btnSettingsImg;
        private TextBlock btnSettingsTxt;
        private TextBox textBox;
        private TextBlock statusTextTime;
        private TextBlock statusTextTask;
        private ProgressBar statusProgressBar;
        private TextBlock statusTextPercentage;
        private TextBlock statusTextInfo;

        public Worker(Dispatcher dispatcher, Dictionary<string, Object> controls)
        {
            this.dispatcher = dispatcher;

            btnStart = (Button)controls["btnStart"];
            btnStartImg = (Image)controls["btnStartImg"];
            btnStartTxt = (TextBlock)controls["btnStartTxt"];
            btnPause = (Button)controls["btnPause"];
            btnPauseImg = (Image)controls["btnPauseImg"];
            btnPauseTxt = (TextBlock)controls["btnPauseTxt"];
            btnStop = (Button)controls["btnStop"];
            btnStopImg = (Image)controls["btnStopImg"];
            btnStopTxt = (TextBlock)controls["btnStopTxt"];
            btnSettings = (Button)controls["btnSettings"];
            btnSettingsImg = (Image)controls["btnSettingsImg"];
            btnSettingsTxt = (TextBlock)controls["btnSettingsTxt"];
            textBox = (TextBox)controls["textBox"];
            statusTextTime = (TextBlock)controls["statusTextTime"];
            statusTextTask = (TextBlock)controls["statusTextTask"];
            statusProgressBar = (ProgressBar)controls["statusProgressBar"];
            statusTextPercentage = (TextBlock)controls["statusTextPercentage"];
            statusTextInfo = (TextBlock)controls["statusTextInfo"];

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
                btnStart.IsEnabled = isEnabled;
            }), DispatcherPriority.Background);
        }

        public void UpdateBtnStartImg(string text)
        {
            dispatcher.Invoke(new Action(() =>
            {
                btnStartImg.Source = new BitmapImage(new Uri(text, UriKind.Relative));
            }), DispatcherPriority.Background);
        }

        public void UpdateBtnStartTxt(string text)
        {
            dispatcher.Invoke(new Action(() =>
            {
                btnStartTxt.Text = text;
            }), DispatcherPriority.Background);
        }

        public void UpdateBtnPause(bool isEnabled)
        {
            dispatcher.Invoke(new Action(() =>
            {
                btnPause.IsEnabled = isEnabled;
            }), DispatcherPriority.Background);
        }

        public void UpdateBtnPauseImg(string text)
        {
            dispatcher.Invoke(new Action(() =>
            {
                btnPauseImg.Source = new BitmapImage(new Uri(text, UriKind.Relative));
            }), DispatcherPriority.Background);
        }

        public void UpdateBtnPauseTxt(string text)
        {
            dispatcher.Invoke(new Action(() =>
            {
                btnPauseTxt.Text = text;
            }), DispatcherPriority.Background);
        }

        public void UpdateBtnStop(bool isEnabled)
        {
            dispatcher.Invoke(new Action(() =>
            {
                btnStop.IsEnabled = isEnabled;
            }), DispatcherPriority.Background);
        }

        public void UpdateBtnStopImg(string text)
        {
            dispatcher.Invoke(new Action(() =>
            {
                btnStopImg.Source = new BitmapImage(new Uri(text, UriKind.Relative));
            }), DispatcherPriority.Background);
        }

        public void UpdateBtnStopTxt(string text)
        {
            dispatcher.Invoke(new Action(() =>
            {
                btnStopTxt.Text = text;
            }), DispatcherPriority.Background);
        }

        public void UpdateBtnSettings(bool isEnabled)
        {
            dispatcher.Invoke(new Action(() =>
            {
                btnSettings.IsEnabled = isEnabled;
            }), DispatcherPriority.Background);
        }

        public void UpdateBtnSettingsImg(string text)
        {
            dispatcher.Invoke(new Action(() =>
            {
                btnSettingsImg.Source = new BitmapImage(new Uri(text, UriKind.Relative));
            }), DispatcherPriority.Background);
        }

        public void UpdateBtnSettingsTxt(string text)
        {
            dispatcher.Invoke(new Action(() =>
            {
                btnSettingsTxt.Text = text;
            }), DispatcherPriority.Background);
        }

        public void UpdateTextBox(string text)
        {
            dispatcher.Invoke(new Action(() =>
            {
                textBox.AppendText(text + Environment.NewLine);
                textBox.CaretIndex = textBox.Text.Length;
                textBox.ScrollToEnd();
            }), DispatcherPriority.Background);
        }

        public void UpdateStatusTextTime(string text)
        {
            dispatcher.Invoke(new Action(() =>
            {
                statusTextTime.Text = text;
            }), DispatcherPriority.Background);
        }

        public void UpdateStatusTextTask(string text)
        {
            dispatcher.Invoke(new Action(() =>
            {
                statusTextTask.Text = text;
            }), DispatcherPriority.Background);
        }

        public void SetupStatusProgressBar(int min, int max, int value)
        {
            dispatcher.Invoke(new Action(() =>
            {
                statusProgressBar.Minimum = min;
                statusProgressBar.Maximum = max;
                statusProgressBar.Value = value;
            }), DispatcherPriority.Background);
        }

        public void UpdateStatusProgressBar()
        {
            dispatcher.Invoke(new Action(() =>
            {
                statusProgressBar.Value++;
            }), DispatcherPriority.Background);
        }

        public void UpdateStatusTextPercentage(string text)
        {
            dispatcher.Invoke(new Action(() =>
            {
                statusTextPercentage.Text = text;
            }), DispatcherPriority.Background);
        }

        public void UpdateStatusTextInfo(string text)
        {
            dispatcher.Invoke(new Action(() =>
            {
                statusTextInfo.Text = text;
            }), DispatcherPriority.Background);
        }
    }
}