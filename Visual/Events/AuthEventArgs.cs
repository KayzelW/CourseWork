using System;

namespace Visual.Events;

public class AuthEventArgs : EventArgs
{
    public string UserLogin { get; }
    public string UserPassword { get; }

    public AuthEventArgs(string userLogin, string userPassword)
    {
        UserLogin = userLogin;
        UserPassword = userPassword;
    }
}