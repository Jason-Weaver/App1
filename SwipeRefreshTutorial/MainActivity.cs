using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Widget;
using System.ComponentModel;
using System;
using System.Threading;

namespace SwipeRefreshTutorial
{
    [Activity(Label = "SwipeRefreshTutorial", MainLauncher = true)]
    public class MainActivity : Activity
    {
        SwipeRefreshLayout mSwipeRefreshLayout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            mSwipeRefreshLayout = FindViewById<SwipeRefreshLayout>(Resource.Id.swipeLayout);
            mSwipeRefreshLayout.SetColorSchemeColors(Android.Resource.Color.HoloBlueBright, Android.Resource.Color.HoloBlueDark,
                                               Android.Resource.Color.HoloGreenLight, Android.Resource.Color.HoloRedLight);
            mSwipeRefreshLayout.Refresh += mSwipeRefreshLayout_Refresh;
        }

        void mSwipeRefreshLayout_Refresh(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Will run on separate thread
            Thread.Sleep(3000);
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RunOnUiThread(() => { mSwipeRefreshLayout.Refreshing = false; });
        }
    }
}

