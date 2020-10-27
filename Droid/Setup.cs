using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using SpectrumCC.Interfaces;
using MvvmCross.Platform;

namespace SpectrumCC.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializeFirstChance()
        {
            Mvx.LazyConstructAndRegisterSingleton<ISQLiteDb, SQLiteDb>();
            Mvx.LazyConstructAndRegisterSingleton<IDialogService,DialogService>();
            //Mvx.RegisterSingleton<IDialogService>(() => new DialogService());
        }
    }
}
