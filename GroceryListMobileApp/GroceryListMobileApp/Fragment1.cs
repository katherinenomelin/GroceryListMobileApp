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
using Realms;


namespace GroceryListMobileApp
{
    public class Fragment1 : Fragment
    {
        TextView userinfo;
        UserInfoDB userinfodbObj;
        Activity context;

        public Fragment1(UserInfoDB userInfo)
        {
            this.userinfodbObj = userInfo;
            //this.context = context;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment

            View myView = inflater.Inflate(Resource.Layout.FirstTab, container, false); //******New Code


            userinfo = myView.FindViewById<TextView>(Resource.Id.textView1);


            userinfo.Text = userinfodbObj.nameofuser;

            return myView;
        }
    }
}