using Application.Users.Commands;
using Swashbuckle.AspNetCore.Filters;

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
