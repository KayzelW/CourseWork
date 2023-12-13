using Classes;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BookDesktop.Service;

public class BookChangeService
{
    private AppDbContext dbContext { get; set; }
    private NavigationManager navigation { get; set; }

    public BookChangeService(AppDbContext DbContext, NavigationManager Navigation)
    {
        dbContext = DbContext;
        navigation = Navigation;
    }
}
