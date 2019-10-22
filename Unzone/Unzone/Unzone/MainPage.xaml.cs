using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unzone.ViewModels;
using Xamarin.Forms;

namespace Unzone
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
#if DEBUG
            //Xamarin.Forms.DebugRainbows.DebugRainbow.SetIsDebug(this, true);
#else

#endif
            this.BindingContext = new MainViewModel();
        }
    }
}
