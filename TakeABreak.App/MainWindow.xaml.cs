using System;
using System.Windows;
using System.Windows.Threading;

namespace TakeABreak.App;

public partial class MainWindow
{
    private readonly DispatcherTimer _timer;

    public MainWindow()
    {
        InitializeComponent();

        var time = TimeSpan.FromMinutes(10);
        Timer.Content = time.ToString("c");

        _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal,
            delegate
            {
                if (time == TimeSpan.Zero) _timer?.Stop();

                time = time.Add(TimeSpan.FromSeconds(-1));
                Timer.Content = time.ToString("c");
            }, Application.Current.Dispatcher);
    }
}