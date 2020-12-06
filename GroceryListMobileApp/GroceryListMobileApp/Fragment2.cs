using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace GroceryListMobileApp
{
    public class Fragment2 : Fragment
    {
        ListView myFirstList;//********ListViewCode
        Activity context;   //*********ListViewCode
        string[] cars = { "Honda", "Toyota", "BMV" };

        public Fragment2(Activity passedContext)    //Activity:passedContext is a ListView part of the code
        {
            this.context = passedContext;//********ListViewCode
        }


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View myView = inflater.Inflate(Resource.Layout.SecondTab, container, false); //******New Code
            myFirstList = myView.FindViewById<ListView>(Resource.Id.listView1); //********ListViewCode
            ArrayAdapter arrayAdapter = new ArrayAdapter(context, Android.Resource.Layout.SimpleListItem1, cars); //********ListViewCode

            myFirstList.SetAdapter(arrayAdapter);   //********ListViewCode

            return myView; //NewCode
        }
    }
}