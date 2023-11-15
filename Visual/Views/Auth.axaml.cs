using Avalonia.Controls;
using Avalonia.Input;
using System;
using Visual.Events;
using Visual.ViewModels;

namespace Visual.Views;

public partial class Auth : UserControl
{
    public event EventHandler<AuthEventArgs>? AuthCompleted;
    public Auth()
    {
        InitializeComponent();
        loginTextBox.KeyDown += EnterPress_KeyDown;
        passwordTextBox.KeyDown += EnterPress_KeyDown;
    }

    private void EnterPress_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            ProceedAuth();
        }
    }

    private void AuthButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        ProceedAuth();
    }

    private void ProceedAuth()
    {
        if (DataContext is UserAuthViewModel userData)
        {
            if (userData.UserPassword != "" &&  userData.UserPassword != "")
            {
                AuthCompleted?.Invoke(this, new AuthEventArgs(userData.UserLogin, userData.UserPassword));
            }
        }
    }
}


