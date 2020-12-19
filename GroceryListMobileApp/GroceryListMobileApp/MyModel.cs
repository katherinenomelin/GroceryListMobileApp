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


namespace Katherine_Lopez_Term_Project_V1
{
    public class MyModel
    {

        public string nameofuser;
        public string email;
        public string password;
        public int phonenumber;
        public int age;
        public int itemimage;
        public int itemquantity;
        public string itemimagename;


        //Create the cosntructos for the variables:
        public MyModel()
        {
        }


        public MyModel(String nameofUser, String Email, string Password, int Phonenumber, int Age, int Itemimage, int Itemquantity, String Itemimagename)
        {
            this.nameofuser = nameofUser;
            this.email = Email;
            this.password = Password;
            this.phonenumber = Phonenumber;
            this.age = Age;
            this.itemimage = Itemimage;
            this.itemquantity = Itemquantity;
            this.itemimagename = Itemimagename;
        }

    }
}