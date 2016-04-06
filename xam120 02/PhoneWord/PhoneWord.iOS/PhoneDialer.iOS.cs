using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using UIKit;

namespace PhoneWord.iOS
{
    class PhoneDialer:IDialer
    {
        public bool Dial(string number)
        {
            return UIApplication.SharedApplication.OpenUrl(new NSUrl("tel:" + number));
        }
    }
}
