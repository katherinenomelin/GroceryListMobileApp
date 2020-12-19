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
    public class MyCustomAdapter : BaseAdapter<MyModel>
    {
        Activity context;
        List<MyModel> arrayList;


        public MyCustomAdapter(Activity myContext, List<MyModel> myListItems)
        {

            this.context = myContext;
            this.arrayList = myListItems;
        }


        public override MyModel this[int position] //Method that return position in an array
        {
            get { return arrayList[position]; }
        }


        public override int Count //Method that count and return the same amount of register entered
        {

            get { return arrayList.Count; } //1000
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            MyModel myModelObjet = arrayList[position];

            View myView = convertView;

            if (myView == null)
            {
                myView = context.LayoutInflater.Inflate(Resource.Layout.myView, null);
            }

            ImageView myImage = myView.FindViewById<ImageView>(Resource.Id.myImageID);
            //TextView myName = myView.FindViewById<TextView>(Resource.Id.myNameID);
            TextView myQuantity = myView.FindViewById<TextView>(Resource.Id.myQuantityID);

            myImage.SetImageResource(myModelObjet.itemimage);
            //myName.Text = myModelObjet.itemimagename;
            myQuantity.Text = myModelObjet.itemquantity.ToString();

            return myView;
        }
    }
}