using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unzone.Content
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimeCell : ContentView
    {
        public TimeCell()
        {
            InitializeComponent();
        }
    }
}