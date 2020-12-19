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

namespace Katherine_Lopez_Term_Project_V1
{
    public class Fragment3 : Fragment
    {
        Button saveBtn;
        ListView listView;
        Spinner spinnerView;        //For Quantity
        Spinner spinnerGroceryImage;   //For Grocery Item Image 

        Realm realmDB;              //Connection with DB
        MyCustomAdapter myAdapter;  //Connection with Adapter

        //All arrays:
        int[] groceryItemImage = { Resource.Drawable.Apple1, Resource.Drawable.Banana1, Resource.Drawable.cakeslice, Resource.Drawable.cheese,
                                    Resource.Drawable.egg, Resource.Drawable.fish,
                                    Resource.Drawable.meat, Resource.Drawable.milk};     //Array
        int[] itemQuantity = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };    //Array

        int selectedItemImage;
        int selectedItemQuantity;


        //Create instance objects for List:
        List<MyModel> myOwnList = new List<MyModel>();
        List<int> myitemQuantityList = new List<int>();
        List<ItemImageModel> mygroceryItemImageList = new List<ItemImageModel>();
        private Activity context;

        public Fragment3(Activity passedContext)
        {
            this.context = passedContext;//********ListViewCode
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            realmDB = Realm.GetInstance();

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View myView = inflater.Inflate(Resource.Layout.ThirdTab, container, false); //******New Code

            saveBtn = myView.FindViewById<Button>(Resource.Id.saveBtnID);
            listView = myView.FindViewById<ListView>(Resource.Id.listViewID);
            spinnerView = myView.FindViewById<Spinner>(Resource.Id.spinnerViewID);//ItemQuentity spinner
            spinnerGroceryImage = myView.FindViewById<Spinner>(Resource.Id.groceryImageID);


            //Set Adapters:
            ArrayAdapter arrayAdapter = new ArrayAdapter(context, Android.Resource.Layout.SimpleExpandableListItem1, itemQuantity);
            spinnerView.Adapter = arrayAdapter;
            spinnerView.ItemSelected += spinner_ItemSelected; //ItemQuantity Adpaters
            saveBtn.Click += SaveBtn_Click;

            mygroceryItemImageList = getgroceryItemImage();

            ItemImageAdapter itemimageAdapter = new ItemImageAdapter(context, mygroceryItemImageList);
            spinnerGroceryImage.Adapter = itemimageAdapter;
            spinnerGroceryImage.ItemSelected += spinnerGroceryImage_ItemSelected;

            return myView;////////////////////////////////CHECK THIS LINE////////////////
        }


        //Spinner Methods:

        //ItemQuantity spinner
        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)//For Spinner MovieType
        {
            int index = e.Position;
            selectedItemQuantity = itemQuantity[index];
        }

        private void spinnerGroceryImage_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)//For Spinner Item Quantity
        {
            int index = e.Position;

            ItemImageModel ItemImageModel = mygroceryItemImageList[index];
            selectedItemImage = ItemImageModel.itemimage;
        }



        //Get methods:
        public List<ItemImageModel> getgroceryItemImage()
        {
            List<ItemImageModel> temp = new List<ItemImageModel>();

            temp.Add(new ItemImageModel(Resource.Drawable.Apple1));
            temp.Add(new ItemImageModel(Resource.Drawable.Banana1));
            temp.Add(new ItemImageModel(Resource.Drawable.cakeslice));
            temp.Add(new ItemImageModel(Resource.Drawable.cheese));
            temp.Add(new ItemImageModel(Resource.Drawable.egg));
            temp.Add(new ItemImageModel(Resource.Drawable.fish));
            temp.Add(new ItemImageModel(Resource.Drawable.meat));
            temp.Add(new ItemImageModel(Resource.Drawable.milk));
            temp.Add(new ItemImageModel(Resource.Drawable.pizza));

            return temp;

        }

        //SaveBtn Method:

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            int itemImageInfo = selectedItemImage;
            int itemQuantityInfo = selectedItemQuantity;

            UserInfoDB newObj = new UserInfoDB();
            newObj.itemquantity = itemQuantityInfo;
            newObj.itemimage = itemImageInfo;


            //Saving the info in the DB:
            realmDB.Write(() =>
            {
                realmDB.Add(newObj);
            });


            myOwnList = getDataFromRealmDB();   //Retrieve the records from my DB and populate myOwnList(arraylist)
            myAdapter = new MyCustomAdapter(context, myOwnList); //Create a new adapter and assign it again (Reload the adapter)
            listView.Adapter = myAdapter;
        }



        //This method that retrieve data from DB and populate the array 
        public List<MyModel> getDataFromRealmDB()
        {

            //Get all the record in the DB
            List<MyModel> dbRecordList = new List<MyModel>();

            //get all the Values from Person object from Person Table.
            var resultCollection = realmDB.All<UserInfoDB>();


            //loop to go through each value of the collection 
            foreach (UserInfoDB newObj in resultCollection)
            {
                //get the name and type
                int itemimagefromDB = newObj.itemimage;
                int itemquantityfromDB = newObj.itemquantity;

                //And asign into the list
                MyModel temp = new MyModel(itemimagefromDB, itemquantityfromDB);
                dbRecordList.Add(temp);
            }
            //Return the information retrieved inside and add it to my record list
            return dbRecordList;
        }
    }
}
