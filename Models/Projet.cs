
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exigeances.Models;
using Jalons.Models;
using System.ComponentModel.DataAnnotations;
using Resps.Models;

namespace Projets.Models
{

public class Projet {

   
    public int ProjetID {get;set;}

    public string nom {get;set;}

    
     [MaxLength(3)]
    public string trigrame {get;set;}


    public string description {get;set;}
   [Required]
   public int RespID {get;set;}
    public virtual Resp resp {get;set;}

    public ICollection<Exigeance> Exigeance { get; set; }

    public ICollection<Jalon> Jalon { get; set; }
}

}

