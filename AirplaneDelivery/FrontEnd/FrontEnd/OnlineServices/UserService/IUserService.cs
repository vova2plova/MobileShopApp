﻿using DAL.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.OnlineServices.UserService
{
    public interface IUserService
    {
        [Get("/User/SignIn?login={login}&password={password}")]
        Task<ApiResponse<User>> SignIn(string login, string password);

        [Post("/User/SignUp")]
        Task<ApiResponse<User>> SignUp(
            [Body] User newUser);

        [Get("/User/GetUserById/{id}")]
        Task<ApiResponse<User>> GetUserById(int id);

        [Put("/User/UpdateData")]
        Task<ApiResponse<User>> UpdateData(
            [Body] User newUser);
    }
}