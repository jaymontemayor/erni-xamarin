using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDetailsPage : ContentPage
    {
        public UserDetailsPage(UserModel usermodel)
        {
            InitializeComponent();

            nameLabel.Text = usermodel.name;

            imageUrlImage.Source = usermodel.imageUrl;
        }
    }
}