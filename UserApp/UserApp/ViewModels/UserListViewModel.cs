using MvvmHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UserApp.Models;
using UserApp.Services;
using UserApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace UserApp.ViewModels
{
    public class UserListViewModel
    {
        public ObservableRangeCollection<UserModel> Users { get; set; }

        public Command SelectCommand { get; }

        private readonly IUserService _userService;

        public UserListViewModel()
        {
            Users = new ObservableRangeCollection<UserModel>();

            SelectCommand = new Command<UserModel>(OnSelectCommand);

            _userService = DependencyService.Get<IUserService>();

            Task.Run(async () =>
            {
                await GetUsers();
            });
        }

        private async void OnSelectCommand(UserModel userModel)
        {
            await App.Current.MainPage.Navigation.PushAsync(new UserDetailsPage(userModel));
        }

        private async Task GetUsers()
        {
            Users.Clear();

            var users = await _userService.GetUsers();

            Users.AddRange((IEnumerable<UserModel>)users);
        }

    }
}
