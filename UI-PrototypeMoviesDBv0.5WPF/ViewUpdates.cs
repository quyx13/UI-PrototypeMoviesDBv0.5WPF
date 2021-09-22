﻿using System;
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
            }), DispatcherPriority.Background);
        }

        public static void UpdateBtnStartImg(Dispatcher dispatcher,
            Dictionary<string, Object> controls, string text)
        {
            var btnStartImg = (Image)controls["btnStartImg"];

            dispatcher.BeginInvoke(new Action(() =>
            {
                btnStartImg.Source = new BitmapImage(new Uri(text, UriKind.Relative));
            }), DispatcherPriority.Background);
        }

        public static void UpdateBtnStartTxt(Dispatcher dispatcher,
            Dictionary<string, Object> controls, string text)
        {
            var btnStartTxt = (TextBlock)controls["btnStartTxt"];

            dispatcher.BeginInvoke(new Action(() =>
            {
                btnStartTxt.Text = text;
            }), DispatcherPriority.Background);
        }

        public static void UpdateBtnSettings(Dispatcher dispatcher,
            Dictionary<string, Object> controls, bool isEnabled)
        {
            var btnSettings = (Button)controls["btnSettings"];

            dispatcher.BeginInvoke(new Action(() =>
            {
                btnSettings.IsEnabled = isEnabled;
            }), DispatcherPriority.Background);
        }

        public static void UpdateBtnSettingsImg(Dispatcher dispatcher,
            Dictionary<string, Object> controls, string text)
        {
            var btnSettingsImg = (Image)controls["btnSettingsImg"];

            dispatcher.BeginInvoke(new Action(() =>
            {
                btnSettingsImg.Source = new BitmapImage(new Uri(text, UriKind.Relative));
            }), DispatcherPriority.Background);
        }

        public static void UpdateBtnSettingsTxt(Dispatcher dispatcher,
            Dictionary<string, Object> controls, string text)
        {
            var btnSettingsTxt = (TextBlock)controls["btnSettingsTxt"];

            dispatcher.BeginInvoke(new Action(() =>
            {
                btnSettingsTxt.Text = text;
            }), DispatcherPriority.Background);
        }

        public static void UpdateComboBox(Dispatcher dispatcher,
            Dictionary<string, Object> controls, string text)
        {
            var comboBox = (ComboBox)controls["comboBox"];

            dispatcher.BeginInvoke(new Action(() =>
            {
                comboBox.Items.Add(text);
            }), DispatcherPriority.Background);
        }

        public static void UpdateTextBox(Dispatcher dispatcher,
            Dictionary<string, Object> controls, string text)
        {
            var textBox = (TextBox)controls["textBox"];

            dispatcher.BeginInvoke(new Action(() =>
            {
                textBox.AppendText(text + Environment.NewLine);
            }), DispatcherPriority.Background);
        }

        public static void UpdateStatusTextTime(Dispatcher dispatcher,
            Dictionary<string, Object> controls, string text)
        {
            var statusTextTime = (TextBlock)controls["statusTextTime"];

            dispatcher.BeginInvoke(new Action(() =>
            {
                statusTextTime.Text = text;
            }), DispatcherPriority.Background);
        }

        public static void UpdateStatusTextTask(Dispatcher dispatcher,
            Dictionary<string, Object> controls, string text)
        {
            var statusTextTask = (TextBlock)controls["statusTextTask"];

            dispatcher.BeginInvoke(new Action(() =>
            {
                statusTextTask.Text = text;
            }), DispatcherPriority.Background);
        }

        public static void SetupStatusProgressBar(Dispatcher dispatcher,
            Dictionary<string, Object> controls, int min, int max)
        {
            var statusProgressBar = (ProgressBar)controls["statusProgressBar"];

            dispatcher.BeginInvoke(new Action(() =>
            {
                statusProgressBar.Value = min;
                statusProgressBar.Minimum = min;
                statusProgressBar.Maximum = max;
            }), DispatcherPriority.Background);
        }

        public static void UpdateStatusProgressBar(Dispatcher dispatcher,
            Dictionary<string, Object> controls)
        {
            var statusProgressBar = (ProgressBar)controls["statusProgressBar"];

            dispatcher.BeginInvoke(new Action(() =>
            {
                statusProgressBar.Value++;
            }), DispatcherPriority.Background);
        }

        public static void UpdateStatusTextPercentage(Dispatcher dispatcher,
            Dictionary<string, Object> controls, string text)
        {
            var statusTextPercentage = (TextBlock)controls["statusTextPercentage"];

            dispatcher.BeginInvoke(new Action(() =>
            {
                statusTextPercentage.Text = text;
            }), DispatcherPriority.Background);
        }

        public static void UpdateStatusTextInfo(Dispatcher dispatcher,
            Dictionary<string, Object> controls, string text)
        {
            var statusTextInfo = (TextBlock)controls["statusTextInfo"];

            dispatcher.BeginInvoke(new Action(() =>
            {
                statusTextInfo.Text = text;
            }), DispatcherPriority.Background);
        }
    }
}