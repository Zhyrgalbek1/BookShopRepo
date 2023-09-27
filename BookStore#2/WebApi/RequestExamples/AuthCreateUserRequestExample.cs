using Application.Users.Commands;
using Domain.Entities;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.AuthRequestExample;

internal class AutchCreateUserRequestExample : IExamplesProvider<CreateUserCommandExample>
{
    public CreateUserCommandExample GetExamples()
    {
        return new CreateUserCommandExample
        {
            Username = "Actor",
            Password = "password",
            FirstName = "Mike",
            LastName = "Leon",
            Email = "email@gmail.com",
            Role = "Admin = 1, User =  2",      
        };
    }
}
