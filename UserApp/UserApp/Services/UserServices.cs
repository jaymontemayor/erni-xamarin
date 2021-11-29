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
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly:Dependency(typeof(UserServices))]
namespace UserApp.Services
{
    public class UserServices : IUserService
    {
        private const string userUrl = "https://gist.githubusercontent.com/erni-ph-mobile-team/c5b401c4fad718da9038669250baff06/raw/7e390e8aa3f7da4c35b65b493fcbfea3da55eac9/test.json";
        private readonly HttpClient httpClient = new HttpClient();

        async Task Init()
        {
            var current = Connectivity.NetworkAccess;

            if (current != NetworkAccess.Internet)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "No internet connection.", "Ok");
                return;
            }
        }

        public async Task<List<UserModel>> GetUsers()
        {
            await Init();

            List<UserModel> Users = new List<UserModel>();

            var userJson = await httpClient.GetStringAsync(userUrl);
            var users = JsonConvert.DeserializeObject<UserModel[]>(userJson);

            foreach (var user in users)
                {
                    if (Users.Any(p => p.id == user.id) == false)
                    {
                        Users.Add(user);
                    }
                }

            return Users;
        }
    }
}
