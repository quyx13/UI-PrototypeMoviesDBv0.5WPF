﻿using System;
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
            Trace.WriteLine("started...");

            var btnStart = (Button)controls["btnStart"];
            var btnStartImg = (Image)controls["btnStartImg"];
            var btnStartTxt = (TextBlock)controls["btnStartTxt"];
            var btnSettings = (Button)controls["btnSettings"];
            var btnSettingsImg = (Image)controls["btnSettingsImg"];
            var btnSettingsTxt = (TextBlock)controls["btnSettingsTxt"];

            ViewUpdates.SetupStatusProgressBar(dispatcher, controls, 0, number);
            
            for (int i = 0; i < number; )
            {
                ViewUpdates.UpdateComboBox(dispatcher, controls, $"...step {i}...");
                ViewUpdates.UpdateTextBox(dispatcher, controls, $"...step {i}...");
                ViewUpdates.UpdateStatusTextTime(dispatcher, controls, $"...step {i}...");
                ViewUpdates.UpdateStatusTextTask(dispatcher, controls, $"...step {i}...");
                ViewUpdates.UpdateStatusProgressBar(dispatcher, controls);
                ViewUpdates.UpdateStatusTextPercentage(dispatcher, controls, $"{i}%");
                ViewUpdates.UpdateStatusTextInfo(dispatcher, controls, $"...step {i}...");

                Thread.Sleep(1000);

                i++;
            }

            Trace.WriteLine("...done");
        }
    }
}