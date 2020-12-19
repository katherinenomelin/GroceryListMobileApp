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
using Realms;

namespace GroceryListMobileApp
{
    [Activity(Label = "Register")]
    public class Register : Activity
    {
        //Declare variables

        EditText nameofuser;
        EditText email;
        EditText phonenumber;
        EditText age;
        EditText password;
        Button registerBtn;
        Button returnBtn;

        //Declare Realm Database Instance

        Realm realmDB;
        string nameofuserValue;
        string emailValue;
        //int phonenumberValue;
        //int ageValue;
        string passwordValue;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Register);

            //Step 1 to init the database with user information in the Register Page
            realmDB = Realm.GetInstance();

            //Find the fileds in the view
            nameofuser = FindViewById<EditText>(Resource.Id.nameofuserID);
            email = FindViewById<EditText>(Resource.Id.emailID);
            phonenumber = FindViewById<EditText>(Resource.Id.phonenumberID);
            age = FindViewById<EditText>(Resource.Id.ageID);
            password = FindViewById<EditText>(Resource.Id.passwordID);

            returnBtn = FindViewById<Button>(Resource.Id.returnBtnID);
            returnBtn.Click += ReturnBtn_Click;

            registerBtn = FindViewById<Button>(Resource.Id.registerBtnID);
            registerBtn.Click += RegisterBtn_Click;
        }


        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            emailValue = email.Text;
            passwordValue = password.Text;
            nameofuserValue = nameofuser.Text;

            // check if the value is empty
            if (emailValue.Trim() == "" || emailValue.Trim() == " ")
            {
                Toast.MakeText(this, "Please Enter Email!", ToastLength.Long).Show();
            }

            else if (nameofuserValue.Trim() == "" || nameofuserValue.Trim() == " ")
            {
                Toast.MakeText(this, "Please Enter User Name!", ToastLength.Long).Show();
            }

            else if (passwordValue.Trim() == "" || passwordValue.Trim() == " ")
            {
                Toast.MakeText(this, "Please Enter the Password!", ToastLength.Long).Show();
            }

            else
            {
                //Validation that user didn't exist already (validating user name):
                var userinfodbObj = realmDB.All<UserInfoDB>().Where(d => d.email == emailValue.ToLower());
                var userinfodbFirst = userinfodbObj.Count();

                if (userinfodbFirst != null && userinfodbFirst > 0)
                {
                    Toast.MakeText(this, "User already exist. Please use different Email!", ToastLength.Long).Show();
                }

                else
                {
                    //Create a UserInfoDB Realm Object:
                    UserInfoDB saveUserInfo = new UserInfoDB();

                    saveUserInfo.nameofuser = nameofuserValue;
                    saveUserInfo.email = emailValue.ToLower();
                    saveUserInfo.password = passwordValue.ToLower();

                    //Saving the info into the database
                    realmDB.Write(() =>
                    {
                        realmDB.Add(saveUserInfo);
                    });

                    Toast.MakeText(this, "User Saved! ", ToastLength.Short).Show();
                }
            }
        }
        private void ReturnBtn_Click(object sender, EventArgs e)

        {
            Intent newMainActivityScreen = new Intent(this, typeof(MainActivity));
            StartActivity(newMainActivityScreen);
        }

    }
}