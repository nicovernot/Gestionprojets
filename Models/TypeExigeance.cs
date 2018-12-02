
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exigeances.Models;
using Projets.Models;
using System.ComponentModel.DataAnnotations;

namespace TypeExigeances.Models
{
public class TypeExigeance {

   
    public int TypeExigeanceID {get;set;}
    [Required]
    public string nom {get;set;}

    public virtual Projet Projet {get;set;}
    
    public virtual ICollection<Exigeance> Exigeance { get; set; }

}


}

