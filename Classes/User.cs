using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Classes;

public class User : INotifyPropertyChanged
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Login { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public int PermissionLvl { get; set; }
    public User(int id, string name, string email = "", string password = "") : this() => 
        (this.Id, this.Login, this.Email, this.Password) = (id, name, email, password);

    public virtual List<Log> Logs { get; set; } = new();

    public User()
    {
        
    }

    public override string ToString()
    {
        return PermissionLvl switch
        {
            0 => "root",
            1 => "Администратор",
            2 => "Сотрудник",
            _ => "???"
        };
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void Dirty(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Login)));
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Email)));
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PermissionLvl)));
    }
}
