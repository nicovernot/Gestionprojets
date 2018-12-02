
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exigeance_Taches.Models;
using System.ComponentModel.DataAnnotations;
using Resps.Models;
using Jalons.Models;

namespace Taches.Models
{

public class Tache {
  
    public int TacheID {get;set;}
    [Required]
    public string nom {get;set;}
    [Required]
    public string description {get;set;}
    
    [Display(Name = "datedemarage")]
     [DataType(DataType.Date)]
    public DateTime datedemarage {get;set;}

    [Key]
    public virtual Tache TachePrece{get;set;}

    [Required]
    public int nbjours {get;set;}

    public virtual Resp Resps {get;set;}

    
    [Display(Name = "datedebuttache")]
     [DataType(DataType.Date)]
    public DateTime? datedebuttache {get;set;}

    [Display(Name = "Date de fin de tache")]
     [DataType(DataType.Date)]
    public DateTime? datefintache {get;set;}
    [Required]
    public int JalonID {get;set;}
    public virtual Jalon Jalons {get;set;}
    public ICollection<Exigeance_Tache> Exigeance_Tache { get; set; }

}

}

