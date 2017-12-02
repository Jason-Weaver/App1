using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App1
{
    class MyListView : BaseAdapter<Person>
    {
        private List<Person> mItems;
        private Context mContext;

        public MyListView(Context context, List<Person> items)
        {
            mContext = context;
            mItems = items;
        }

        public override int Count
        {
            get
            {
                return mItems.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Person this[int position]
        {
            get
            {
                return mItems[position];
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.listview_row, null, false);
            }

            TextView textFirstName = row.FindViewById<TextView>(Resource.Id.firstName);
            textFirstName.Text = mItems[position].FirstName;

            TextView textLastName = row.FindViewById<TextView>(Resource.Id.lastName);
            textLastName.Text = mItems[position].LastName;

            TextView textAge = row.FindViewById<TextView>(Resource.Id.age);
            textAge.Text = mItems[position].Age;

            TextView textGender = row.FindViewById<TextView>(Resource.Id.gender);
            textGender.Text = mItems[position].Gender;

            return row;
        }
    }
}