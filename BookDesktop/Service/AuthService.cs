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

    public AuthService(AppDbContext dbContext, NavigationManager Navigation)
    {
        this.dbContext = dbContext;
        navigation = Navigation;
    }

    public void Login(string login, string password)
    {
        var user = dbContext.Users.FirstOrDefault(x => x.Login == login);
        if (user == null)
            return;
        navigation.NavigateTo("books");
    }
}
