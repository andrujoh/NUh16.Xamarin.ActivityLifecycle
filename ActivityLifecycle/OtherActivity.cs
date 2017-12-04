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
using Android.Graphics;

namespace ActivityLifecycle
{
    [Activity(Label = "OtherActivity")]
    public class OtherActivity : Activity
    {
        private Color currentColor;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Other);

            var button = FindViewById<Button>(Resource.Id.button1);
            button.Click += Button_Click;

            var color = new Color(Intent.GetIntExtra("Color", Color.White.ToArgb()));
            SetColor(color);
        }

        private void SetColor(Color color)
        {
            currentColor = color;
            FindViewById<TextView>(Resource.Id.textView1).SetTextColor(currentColor);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var textView = FindViewById<TextView>(Resource.Id.textView1);
            var editText = FindViewById<EditText>(Resource.Id.editText1);
            textView.Text = editText.Text;
        }
    }
}