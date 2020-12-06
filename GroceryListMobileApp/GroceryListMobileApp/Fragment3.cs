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
    public class Fragment3 : Fragment
    {
        /*
        Button saveBtn;
        ListView listView;
        Spinner spinnerView;        //For Quantity
        Spinner spinnerGroceryImage;   //For Grocery Item Image 

        Realm realmDB;              //Connection with DB
        MyCustomAdapter myAdapter;  //Connection with Adapter

        //All arrays:
        int[] groceryItemImage = { Resource.Drawable.Apple1, Resource.Drawable.Banana1 };     //Array
        string[] groceryItemListImage = { "Apple1", "Banana1" }; //Array
        int[] itemQuantity = {1, 2, 3, 4, 5, 6};    //Array

        int selectedItemImage;
        int selectedItemQuantity;


        //Create instance objects for List:
        List<MyModel> myOwnList = new List<MyModel>();
        List<string> myMovieTypeList = new List<string>();
        List<MovieImageModel> myMovieImageList = new List<MovieImageModel>();

        */






        public Fragment3(Frame frame)
        {

        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View myView = inflater.Inflate(Resource.Layout.ThirdTab, container, false); //******New Code

            return myView;
        }
    }
}