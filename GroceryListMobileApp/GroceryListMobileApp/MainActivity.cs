using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Realms;
using Android.Content;
using System.Linq;
using System;

namespace GroceryListMobileApp
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {

        EditText email;
        EditText password;
        Button loginBtn;
        Button registerBtn;

        Realm realmDB;

        string emailValue;
        string passwordValue;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            realmDB = Realm.GetInstance();

            email = FindViewById<EditText>(Resource.Id.emailID);
            password = FindViewById<EditText>(Resource.Id.passwordID);

            loginBtn = FindViewById<Button>(Resource.Id.button1);
            loginBtn.Click += loginBtn_Click;

            registerBtn = FindViewById<Button>(Resource.Id.registerBtnID);
            registerBtn.Click += RegisterBtn_Click;

        }

        private void loginBtn_Click(object sender, System.EventArgs e)
        {
            emailValue = email.Text;
            passwordValue = password.Text;

            if (emailValue.Trim() == "" || emailValue.Trim() == " ")
            {
                Toast.MakeText(this, "Please Enter Email!", ToastLength.Long).Show();
            }

            else if (passwordValue.Trim() == "" || passwordValue.Trim() == " ")
            {
                Toast.MakeText(this, "Please Enter Password!", ToastLength.Long).Show();
            }

            else
            {
                //Validation that user didn't exist already (validating user name):
                var userinfodbObj = realmDB.All<UserInfoDB>().Where(d => d.email == emailValue.ToLower() && d.password == passwordValue);
                var count = userinfodbObj.Count();

                if (count > 0)
                {
                    Intent newFrameScreen = new Intent(this, typeof(Frame));
                    //Pass information from one screen to another because Frame or Welcome screen is gonna use it to show the name:
                    newFrameScreen.PutExtra("email", emailValue);
                    StartActivity(newFrameScreen);
                }

                else
                {
                    Toast.MakeText(this, "User not found, Please register!", ToastLength.Long).Show();
                }
            }
        }

        private void RegisterBtn_Click(object sender, System.EventArgs e)
        {
            Intent newRegisterScreen = new Intent(this, typeof(Register));
            StartActivity(newRegisterScreen);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}