
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
using MvvmCross.Droid.Views;
using SpectrumCC.ViewModels;

namespace SpectrumCC.Droid.Views
{
    [Activity(Label = "AccountSuccessfullyCreatedView")]
    public class AccountSuccessfullyCreatedView : MvxActivity<AccountSuccessfullyCreatedViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AccountSuccessfullyCreatedView);
            // Create your application here
        }
    }
}