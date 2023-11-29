using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDesktop.Models;

public class Person
{
    [StringLength(15, ErrorMessage = "Login is too long."), Required]
    public string? Login { get; set; }

    [StringLength(20, ErrorMessage = "Password is too long."), Required]
    public string? Password { get; set; }
}
