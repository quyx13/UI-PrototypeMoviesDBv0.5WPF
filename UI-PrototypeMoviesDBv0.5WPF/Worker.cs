﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Threading;

namespace UI_PrototypeMoviesDBv0._5WPF
{
    public class Worker
    {
        public bool run = false;

        public void DoWork(Dispatcher dispatcher, Dictionary<string, Object> controls, int number)
        {
            Trace.WriteLine("started...");

            var timer = new Stopwatch();
            timer.Start();

            ViewUpdates.UpdateBtnStart(dispatcher, controls, false);
            ViewUpdates.UpdateBtnStartImg(dispatcher, controls, @"/res/play24gray.png");
            ViewUpdates.UpdateBtnPause(dispatcher, controls, true);
            ViewUpdates.UpdateBtnPauseImg(dispatcher, controls, @"/res/pause24.png");
            ViewUpdates.UpdateBtnStop(dispatcher, controls, true);
            ViewUpdates.UpdateBtnStopImg(dispatcher, controls, @"/res/stop24.png");
            ViewUpdates.UpdateBtnSettings(dispatcher, controls, false);
            ViewUpdates.UpdateBtnSettingsImg(dispatcher, controls, @"/res/settings24gray.png");
            ViewUpdates.SetupStatusProgressBar(dispatcher, controls, 0, number, 0);
            ViewUpdates.UpdateStatusTextInfo(dispatcher, controls, "Running");
            
            for (int i = 0; i < number; )
            {
                if (run)
                {
                    #region Actually Working Area
                    ViewUpdates.UpdateComboBox(dispatcher, controls, $"...step {i}...");
                    ViewUpdates.UpdateTextBox(dispatcher, controls, $"...step {i}...");
                    ViewUpdates.UpdateStatusTextTime(dispatcher, controls, $"...step {i}...");
                    ViewUpdates.UpdateStatusTextTask(dispatcher, controls, $"...step {i}...");
                    ViewUpdates.UpdateStatusProgressBar(dispatcher, controls);
                    ViewUpdates.UpdateStatusTextPercentage(dispatcher, controls, $"{i}%");
                    //ViewUpdates.UpdateStatusTextInfo(dispatcher, controls, $"...step {i}...");

                    Thread.Sleep(1000);

                    i++; 
                    #endregion
                }
                else
                {
                    break;
                }
            }

            if (run)
            {
                ViewUpdates.UpdateStatusTextInfo(dispatcher, controls, "Done");
            }
            else
            {
                ViewUpdates.UpdateStatusTextInfo(dispatcher, controls, "Stopped");
            }

            ViewUpdates.UpdateBtnStart(dispatcher, controls, true);
            ViewUpdates.UpdateBtnStartImg(dispatcher, controls, @"/res/play24.png");
            ViewUpdates.UpdateBtnPause(dispatcher, controls, false);
            ViewUpdates.UpdateBtnPauseImg(dispatcher, controls, @"/res/pause24gray.png");
            ViewUpdates.UpdateBtnStop(dispatcher, controls, false);
            ViewUpdates.UpdateBtnStopImg(dispatcher, controls, @"/res/stop24gray.png");
            ViewUpdates.UpdateBtnSettings(dispatcher, controls, true);
            ViewUpdates.UpdateBtnSettingsImg(dispatcher, controls, @"/res/settings24.png");

            run = false;
            timer.Reset();

            Trace.WriteLine("...done");
        }
    }
}