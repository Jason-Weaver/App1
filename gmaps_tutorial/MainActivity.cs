using Android.App;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;
using System;

namespace gmaps_tutorial
{
    [Activity(Label = "gmaps_tutorial", MainLauncher = true)]
    public class MainActivity : Activity, IOnMapReadyCallback
    {
        private GoogleMap mMap;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            setUpMap();
        }

        private void setUpMap()
        {
            if (mMap == null)
            {
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);
            }
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            if (mMap == null)
            {
                return;
            }

            mMap = googleMap;
        }
    }
}

