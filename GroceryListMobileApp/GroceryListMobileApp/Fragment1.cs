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
        TextView email;
        TextView phonenumber;
        TextView name;
        TextView age;
        Activity context;

        Realm realmDB;
        string changeName;
        string changeEmail;
        string changePhone;
        string changeAge;

        public Fragment1( UserInfoDB userInfo)
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

            View myView = inflater.Inflate(Resource.Layout.FirstTab, container, false);


            userinfo = myView.FindViewById<TextView>(Resource.Id.textView1);
            email = myView.FindViewById<TextView>(Resource.Id.emailID);
            phonenumber = myView.FindViewById<TextView>(Resource.Id.phonenumberID);
            name = myView.FindViewById<TextView>(Resource.Id.nameofuserID);
            age = myView.FindViewById<TextView>(Resource.Id.ageID);

            userinfo.Text = userinfodbObj.nameofuser;
            email.Text = userinfodbObj.email;
            name.Text = userinfodbObj.nameofuser;
           

            return myView;
        }
        private void changeUserInfo(object sender, EventArgs e)
        {
            changeName = name.Text;

            changePhone = phonenumber.Text;

            changeAge = age.Text;

            UserInfoDB saveUserData = new UserInfoDB();

            saveUserData.nameofuser = changeName;


            var toast = Toast.MakeText(context, "Your profile has been updated.", ToastLength.Short);
            toast.Show();

            realmDB.Write(() =>
            {
                realmDB.Add(saveUserData);
            });
            name.Text = changeName;


        }
    }
}
