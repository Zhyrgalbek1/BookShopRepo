using Application.Users.Commands;
using Domain.Entities;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.AuthRequestExample;

internal class AuthLoginRequestExample : IExamplesProvider<LoginCommand>
{
    public LoginCommand GetExamples()
    {
        return new LoginCommand
        {
            Username = "Пользователь",
            Password = "qwerty123",
        };
    }
}
