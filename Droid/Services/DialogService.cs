using System;
using Android.App;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using SpectrumCC.Interfaces;

namespace SpectrumCC.Droid
{
    public class DialogService : IDialogService
    {
        public void ShowDialog(string title, string message, string buttonText)
        {
            var top = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
            var act = top.Activity;

            var adb = new AlertDialog.Builder(act);
            adb.SetTitle(title);
            adb.SetMessage(message);
            adb.SetPositiveButton(buttonText, (sender, args) => { /* some logic */ });
            adb.Create().Show();
        }
    }
}
