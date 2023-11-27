using Classes;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDesktop.Service;

public class AuthService
{
    private readonly AppDbContext dbContext;
    private readonly NavigationManager navigation;
    public static User CurrentUser{ get; set; }
    public AuthService(AppDbContext dbContext, NavigationManager Navigation)
    {
        this.dbContext = dbContext;
        navigation = Navigation;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="login"></param>
    /// <param name="password"></param>
    public void Login(string login, string password)
    {
        var user = dbContext.Users.FirstOrDefault(x => x.Login == login && x.Password == password);
        if (user == null)
            return;
        CurrentUser = user;
        navigation.NavigateTo("personal_page");
    }
}
