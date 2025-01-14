﻿using DAL.Models;
using FrontEnd.OnlineServices;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using FrontEnd.Views;
using Acr.UserDialogs;
using Xamarin.Essentials;

namespace FrontEnd.ViewsModels
{
    class LoginPageViewModel
    {
        public ICommand EnterCommand => new Command<User>(async value =>
        {
            var response = await MainService.UserService.SignIn(value.Number,value.Password);
            if (response.IsSuccessStatusCode)
            {
                using (UserDialogs.Instance.Loading("Страница загружается", null, null, true, MaskType.Black)) { 
                Application.Current.MainPage = new NavigationPage(new MainPage()); }
                Preferences.Set("user_id", response.Content.Id);
            }
            else
                UserDialogs.Instance.Toast("Введены неверные данные!");
        });

        public ICommand EnterCommand2 => new Command<User>(async value =>
        {
            var response = await MainService.UserService.SignUp(value);
            if (response.IsSuccessStatusCode)
            {
                UserDialogs.Instance.Toast("Вы успешно зарегестрировались!");
                using (UserDialogs.Instance.Loading("Страница загружается", null, null, true, MaskType.Black))
                {
                    Application.Current.MainPage = new NavigationPage(new MainPage());
                }
                Preferences.Set("user_id", response.Content.Id);
            }
            else
                UserDialogs.Instance.Toast("Пользовтаель с таким номером телефона уже зарегистрирован!");
        });
    }

}
