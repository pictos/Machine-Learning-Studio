using MLCL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MLCL.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MLPage : ContentPage
    {
        public MLPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.MLViewModel();
        }

     
    }
}