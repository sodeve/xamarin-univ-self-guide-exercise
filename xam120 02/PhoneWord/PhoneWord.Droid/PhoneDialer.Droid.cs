using Xamarin.Forms;
using System;
using System.Linq;
using Android.Content;
using Android.Telephony;
using PhoneWord.Droid;
using Uri = Android.Net.Uri;


[assembly: Dependency(typeof(PhoneDialer))]
namespace PhoneWord.Droid
{
    
    class PhoneDialer : IDialer
    {
        public bool Dial(string number)
        {
            var context = Forms.Context;
            if (context == null)
                return false;

            var intent = new Intent(Intent.ActionCall);
            intent.SetData(Uri.Parse("tel:" + number));

            if (IsIntentAvailable(context, intent))
            {
                context.StartActivity(intent);
                return true;
            }
            return false;
        }

        private bool IsIntentAvailable(Context context, Intent intent)
        {
            var packageManager = context.PackageManager;
            var list =
                packageManager.QueryIntentServices(intent, 0).Union(packageManager.QueryIntentActivities(intent, 0));
            if (list.Any())
            {
                return true;
            }

            TelephonyManager mgr = TelephonyManager.FromContext(context);
            return mgr.PhoneType != PhoneType.None;
        }
    }
}