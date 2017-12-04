using Android.App;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using Android.Content;

namespace ActivityLifecycle
{
    [Activity(Label = "ActivityLifecycle", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private Color currentColor = Color.Red;

        private Color[] colors = { Color.Red, Color.Green, Color.Blue };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


            var radioGroup = FindViewById<RadioGroup>(Resource.Id.radioGroup1);

            radioGroup.CheckedChange += ColorSelected;
            ColorSelected(this, new RadioGroup.CheckedChangeEventArgs(Resource.Id.radioRed));

            FindViewById<Button>(Resource.Id.gotoOtherActivity).Click += MainActivity_Click;
        }

        private void MainActivity_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(OtherActivity));

            intent.PutExtra("Color", currentColor.ToArgb());

            StartActivity(intent);
        }

        private void ColorSelected(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            var radioGroup = FindViewById<RadioGroup>(Resource.Id.radioGroup1);
            var radioButton = FindViewById<RadioButton>(e.CheckedId);

            var selectedIndex = radioGroup.IndexOfChild(radioButton);
            currentColor = colors[selectedIndex];

            var selectedColor = FindViewById<TextView>(Resource.Id.selectedColor);
            selectedColor.Text = radioButton.Text;
            selectedColor.SetTextColor(currentColor);
        }
    }
}

