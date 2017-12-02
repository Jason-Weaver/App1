using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace App1
{
    [Activity(Label = "App1", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private List<Person> mItems;
        private ListView mListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            mListView = FindViewById<ListView>(Resource.Id.myListView);

            mItems = new List<Person>();
            mItems.Add(new Person() { FirstName = "Mary Kate", LastName = "Stopa", Age = "27", Gender = "Female" } );
            mItems.Add(new Person() { FirstName = "Jason", LastName = "Weaver", Age = "26", Gender = "Male" });
            mItems.Add(new Person() { FirstName = "Left", LastName = "Eye", Age = "26", Gender = "Female" } );

            MyListView adapter = new MyListView(this, mItems);
            mListView.Adapter = adapter;
            mListView.ItemClick += MListView_ItemClick;
            mListView.ItemLongClick += MListView_ItemLongClick;
        }

        private void MListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            System.Console.WriteLine(mItems[e.Position].FirstName + " is the Best!");
        }

        private void MListView_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            System.Console.WriteLine(mItems[e.Position].FirstName + " is so beautiful!");
        }
    }
}

