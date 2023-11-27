using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDesktop.Models;

public class Person
{
    [Required]
    [StringLength(15, ErrorMessage = "Login is too long.")]
    public string? Login { get; set; }

    [Required]
    [StringLength(20, ErrorMessage = "Password is too long.")]
    public string? Password { get; set; }
}
