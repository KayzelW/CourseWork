using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;

namespace Visual.ViewModels;

public class UserAuthViewModel : ObservableObject, INotifyPropertyChanged
{
    private string _userLogin = string.Empty;
    private string _userPassword = string.Empty;

    public string UserLogin
    {
        get => _userLogin;
        set
        {
            if (_userLogin != value)
            {
                _userLogin = value;
                Dirty(nameof(UserLogin));
            }
        }
    }

    public string UserPassword
    {
        get => _userPassword;
        set
        {
            if (_userPassword != value)
            {
                _userPassword = value;
                Dirty(nameof(UserPassword));
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void Dirty(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
