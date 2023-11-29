using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes;

public class Log
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id {  get; set; }
    public string Operation { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    public Log() { }
}
