
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Projets.Models;
using TypeExigeances.Models;
using Exigeance_Taches.Models;
using Resps.Models;
using System.ComponentModel.DataAnnotations;

namespace Exigeances.Models


{
public class Exigeance {

   
    public int ExigeanceID {get;set;}
[Required]
    public string nom {get;set;}
[Required]
    public string description {get;set;}
    [Required]
    public int ProjetID {get;set;}

    public virtual Projet Projet {get;set;}
  [Required]
    public int TypeExigeanceID {get;set;}

    public virtual TypeExigeance TypeExigeance{ get;set;}
    public ICollection<Exigeance_Tache> Exigeance_Tache { get; set; }

}


}


