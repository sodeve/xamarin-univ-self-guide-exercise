using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace PhoneWord
{
    public class MainPage : ContentPage
    {
        Entry phoneNumberText;
        Button translateButton;
        Button callButton;
        private string translatedNumber;

        public MainPage()
        {
            this.Padding = new Thickness(
                20, Device.OnPlatform<double>(40,20,20), 20, 20
            );

            StackLayout panel = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Spacing = 15
            };
            panel.Children.Add(phoneNumberText = new Entry
            {
                Text = "1-855-XAMARIN"
            });
            panel.Children.Add(translateButton = new Button
            {
                Text = "Translate"
            });
            panel.Children.Add(callButton = new Button
            {
                Text = "Call",
                IsEnabled = false
            });
            translateButton.Clicked += OnTranslate;
            callButton.Clicked += OnCall;
            Content = panel;
        }

        private async void OnCall(object sender, EventArgs eventArgs)
        {
            if (await this.DisplayAlert("Dial a Number",
                "Would you like to call " + translatedNumber + " ?",
                "Yes",
                "No"))
            {
                var dialer = DependencyService.Get<IDialer>();
                if (dialer != null)
                    dialer.Dial(translatedNumber);
            };
        }

        private void OnTranslate(object sender, EventArgs eventArgs)
        {
            var enteredNumber = phoneNumberText.Text;
            translatedNumber = PhonewordTranslator.ToNumber(enteredNumber);
            if (!String.IsNullOrEmpty(translatedNumber))
            {
                // TODO:
                callButton.IsEnabled = true;
                callButton.Text = "Call " + translatedNumber;
            }
            else
            {
                // TODO:
                callButton.IsEnabled = false;
                callButton.Text = "Call";
            }
        }
    }
}
