﻿using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace UI_PrototypeMoviesDBv0._5WPF
{
    public partial class MainWindow : Window
    {
        private View view;
        private Worker worker;
        private Task work;

        public MainWindow()
        {
            InitializeComponent();

            view = new View(this.Dispatcher, this);
            worker = new Worker(view);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(16);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void menuInfo_Click(object sender, RoutedEventArgs e)
        {
            // TODO:Informations-Dialog
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            var number = 5200;

            switch (worker.state)
            {
                case State.ready:
                    view.SetupStatusProgressBar(0, number, 0);
                    goto case State.stopped;
                case State.stopped:
                    goto case State.done;
                case State.done:
                    if (work == null || work.Status == TaskStatus.RanToCompletion)
                    {
                        view.timer.Restart();
                        worker.state = State.running;
                        work = Task.Factory.StartNew(() => worker.DoWork(number));
                        //work = Task.Factory.StartNew(() => worker.DoWork3s(number));
                        view.SetStateRunning();
                    }
                    break;
                case State.paused:
                    view.timer.Start();
                    worker.state = State.running;
                    view.SetStateRunning();
                    break;
            }
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            if (worker.state == State.running)
            {
                view.timer.Stop();
                worker.state = State.paused;
                view.SetStatePaused();
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            switch (worker.state)
            {
                case State.running:
                    view.timer.Stop();
                    goto case State.paused;
                case State.paused:
                    worker.state = State.stopped;
                    view.SetStateStopped();
                    break;
                case State.stopped:
                    goto case State.done;
                case State.done:
                    worker = new Worker(view);
                    break;
            }
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            // TODO:Settings-Fenster
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            DoTest();
        }

        private void DoTest()
        {
            for (int i = 0; i < 1000;)
            {
                this.Dispatcher.Invoke(new Action(() =>
                {
                    this.Title = $"UI-PrototypeMoviesDBv0.5WPF [{i}]";
                }), DispatcherPriority.Background);
                Thread.Sleep(16);
                i++;
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            view.UpdateUi();
        }
    }
}