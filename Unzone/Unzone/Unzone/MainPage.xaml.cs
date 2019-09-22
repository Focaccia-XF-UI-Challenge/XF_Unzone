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

            Xamarin.Forms.DebugRainbows.DebugRainbow.SetIsDebug(this, true);

            this.BindingContext = new MainViewModel();
        }
    }
}
