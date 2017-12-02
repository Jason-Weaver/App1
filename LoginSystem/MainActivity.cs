using Android.App;
using Android.Widget;
using Android.OS;
using System.Threading;

namespace LoginSystem
{
    [Activity(Label = "LoginSystem", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private Button mButtonSignUp;
        private ProgressBar mProgressBar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            mButtonSignUp = FindViewById<Button>(Resource.Id.emailButton);
            mProgressBar = FindViewById<ProgressBar>(Resource.Id.progressBar);
            mButtonSignUp.Click += MButtonSignUp_Click;
        }

        private void MButtonSignUp_Click(object sender, System.EventArgs e)
        {
            // Pull up dialog
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            DialogSignUp signUpDialog = new DialogSignUp();
            signUpDialog.Show(transaction, "Dialog Fragment");

            signUpDialog.mOnSignUpComplete += SignUpDialog_mOnSignUpComplete;
        }

        private void SignUpDialog_mOnSignUpComplete(object sender, OnSignUpEventArgs e)
        {
            mProgressBar.Visibility = Android.Views.ViewStates.Visible;
            Thread thread = new Thread(ActLikeRequest);
            thread.Start();
        }

        private void ActLikeRequest()
        {
            //System.Console.WriteLine("First Name: " + e.FirstName + "\nEmail: " + e.Email + "\nPassword: " + e.Password);
            Thread.Sleep(3000);

            RunOnUiThread(() => { mProgressBar.Visibility = Android.Views.ViewStates.Invisible; });
        }
    }
}

