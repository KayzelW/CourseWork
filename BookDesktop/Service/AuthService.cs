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
    private AppDbContext dbContext { get; set; }
    public User? CurrentUser { get; set; }

    public AuthService(AppDbContext DbContext)
    {
        dbContext = DbContext;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="login"></param>
    /// <param name="password"></param>
    public void Login(NavigationManager navigation, string login, string password)
    {
        var user = dbContext.Users.FirstOrDefault(x => x.Login == login && x.Password == password);
        if (user == null)
            return;
        CurrentUser = user;
        navigation.NavigateTo("personal_page");
    }
}