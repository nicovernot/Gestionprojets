
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Projets.Models;
using Taches.Models;
using System.ComponentModel.DataAnnotations;

namespace Jalons.Models 
{

public class Jalon {

   
    public int JalonID {get;set;}
[Required]
    public string nom {get;set;}
[Required]
    public int ProjetiD {get;set;}

    public virtual Projet Projet { get;set;}

    public ICollection<Tache> Tache { get; set; }

}



}

