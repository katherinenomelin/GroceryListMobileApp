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


namespace GroceryListMobileApp
{
    public class MyModel
    {

        //public string nameofuser;
        //public string email;
        //public string password;
        //public int phonenumber;
        //public int age;
        public int itemimage;
        public int itemquantity;
        //public string itemimagename;

        public MyModel()
        {
        }


        public MyModel(int Itemimage, int Itemquantity)
        {
            //this.nameofuser = nameofUser;
            //this.email = Email;
            //this.password = Password;
            //this.phonenumber = Phonenumber;
            //this.age = Age;
            this.itemimage = Itemimage;
            this.itemquantity = Itemquantity;
            //this.itemimagename = Itemimagename;
        }

        public static implicit operator string(MyModel v)
        {
            throw new NotImplementedException();
        }
    }
}