using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Java.Lang;

namespace calcApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity 
    {
        string operator1 = null;
        TextView calcDisplay;
        int num1 = 0, num2 = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            calcDisplay = FindViewById<TextView>(Resource.Id.resultEditText);
        }
        public void OnClick(View v)
        {
            Button b = (Button)v;
            if ("0123456789".Contains(b.Text)&&operator1==null)
            {
                num1 = num1 + int.Parse(b.Text);
                UpdateDisplay(b.Text);
            }

            if ("0123456789".Contains(b.Text) && operator1 != null)
            {
                num2 = num2 + int.Parse(b.Text);
                UpdateDisplay(b.Text);
            }

            else if (b.Text=="+")
            {
                operator1 = "+";
                UpdateDisplayOp(b.Text);
            }

            else if (b.Text == "-")
            {
                operator1 = "-";
                UpdateDisplayOp(b.Text);
            }

            else if (b.Text == "/")
            {
                operator1 = "/";
                UpdateDisplayOp(b.Text);
            }

            else if (b.Text == "*")
            {
                operator1 = "*";
                UpdateDisplayOp(b.Text);
            }
            else if (b.Text == "=")
            {
                Calculate(num1, num2, operator1);
            }
            if (b.Text == "C")
            {
                Clear();
            }
        }

        public void Clear()
        {
            calcDisplay.Text = "";
            num1 = 0;
            num2 = 0;
        }

        public void Calculate(int num1, int num2, string op)
        {
            double res = 0;
            if (op == "+")
            {
                res = num1 + num2;
            }
            else if (op == "-")
            {
                res = num1 - num2;
            }
            else if (op == "*")
            {
                res = num1 * num2;
            }
            else if (op == "/")
            {

                res = (double)(num1 / num2);
            }
            calcDisplay.Text = res.ToString();
        }

        public void UpdateDisplay(string value)
        {
            calcDisplay.Text += value;
        }

        public void UpdateDisplayOp(string value)
        {
            calcDisplay.Text += " " + value + " ";
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}