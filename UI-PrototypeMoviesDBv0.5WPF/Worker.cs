using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Threading;

namespace UI_PrototypeMoviesDBv0._5WPF
{
    public static class Worker
    {
        public static void DoWork(Dispatcher dispatcher, Dictionary<string, Object> controls, int number)
        {
            Trace.WriteLine("started...");

            ViewUpdates.UpdateBtnStartImg(dispatcher, controls, @"/res/stop24.png");
            ViewUpdates.UpdateBtnStartTxt(dispatcher, controls, "Stop");
            ViewUpdates.UpdateBtnSettings(dispatcher, controls, false);
            ViewUpdates.UpdateBtnSettingsImg(dispatcher, controls, @"/res/settings24gray.png");
            ViewUpdates.SetupStatusProgressBar(dispatcher, controls, 0, number, 0);
            
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

            ViewUpdates.UpdateBtnStartImg(dispatcher, controls, @"/res/play24.png");
            ViewUpdates.UpdateBtnStartTxt(dispatcher, controls, "Start");
            ViewUpdates.UpdateBtnSettings(dispatcher, controls, true);
            ViewUpdates.UpdateBtnSettingsImg(dispatcher, controls, @"/res/settings24.png");

            Trace.WriteLine("...done");
        }
    }
}